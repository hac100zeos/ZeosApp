using MongoDB.Driver;

namespace ZeosApp
{
	public static class DataAccess
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Startup"/> class.
		/// </summary>
		/// <param name="configuration">IConfiguration injection.</param>

		public static MongoClient InitializeClient()
		{
			const string connectionString = "mongodb://10.0.2.2:27017";

			var settings = new MongoClientSettings
			{
				//Credential = new MongoCredential(), //this fails because no user has userAdmin or userAnyAdminDatabase rights
				Server = new MongoServerAddress(connectionString)
			};

			var client = new MongoClient(connectionString);

			return client;
		}

	}
}

