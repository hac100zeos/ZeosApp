namespace ZeosApp.Models
{
	using System.Collections.Generic;
	using MongoDB.Bson.Serialization.Attributes;

	public class PackInstance
	{
		[BsonIgnoreIfNull, BsonIgnore]
		public MongoDB.Bson.ObjectId? Id { get; set; }

		[BsonElement("PackInstanceID")]
		public string PackInstanceID { get; set; }

		[BsonElement("Price")]
		public int Price { get; set; }

		[BsonElement("Products")]
		public List<Product> Products { get; set; }
	}
}
