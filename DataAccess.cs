namespace ZeosApp
{
	using Microsoft.Extensions.Configuration;
	using MongoDB.Driver;

	public class DataAccess
	{
		private IConfiguration Configuration { get; }

		public DataAccess(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public MongoClient InitializeClient()
		{
			var connectionString = this.Configuration["MongoDB:ConnectionString"];

			var settings = new MongoClientSettings
			{
				Server = new MongoServerAddress(connectionString)
			};

			var client = new MongoClient(connectionString);

			return client;
		}

	}
}
