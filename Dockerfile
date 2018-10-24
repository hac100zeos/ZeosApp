FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

ENV NODE_VERSION 8.12.0
ENV NODE_DOWNLOAD_SHA 3df19b748ee2b6dfe3a03448ebc6186a3a86aeab557018d77a0f7f3314594ef6

# Install necessary utilities
RUN curl -SL "https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}-linux-x64.tar.gz" --output nodejs.tar.gz \
	&& echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \
	&& tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
	&& rm nodejs.tar.gz \
	&& ln -s /usr/local/bin/node /usr/local/bin/nodejs \
	&& npm i -g yarn

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ZeosApp.dll
