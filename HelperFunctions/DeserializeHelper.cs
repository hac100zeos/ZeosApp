using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ZeosApp.HelperFunctions
{
	public class DeserializeHelper
	{
		public DeserializeHelper()
		{
		}

		public async Task<IEnumerable<BsonElement>> Deserialize(IMongoCollection<BsonDocument> collection)
		{
			IEnumerable<BsonElement> element = null;

			using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync(new BsonDocument()))
			{
				while (await cursor.MoveNextAsync())
				{
					IEnumerable<BsonDocument> batch = cursor.Current;
					foreach (BsonDocument document in batch)
					{

						element = document.Elements;
						return element;
					}
				}
			}
			return element;
		}
	}
}
