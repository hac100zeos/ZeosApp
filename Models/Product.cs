using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ZeosApp.Models
{
	/// <summary>
	/// Product model for mongo. Use this model when inserting a new product into the database.
	/// </summary>

	[BsonIgnoreExtraElements]
	public class Product
	{
		[BsonIgnoreIfNull, BsonIgnore]
		public ObjectId? Id { get; set; }

		[BsonElement("ProductName")]
		public string Name { get; set; }

		[BsonElement("Description")]
		public string Description { get; set; }

		[BsonElement("Category")]
		public string Category { get; set; }
		
		[BsonElement("ProductImageUrl")]
		public string ImageUrl { get; set; }

		[BsonElement("Price")]
		public int Price { get; set; }

		[BsonElement("CategoryId")]
		public int CategoryId { get; set; }

	}
}
