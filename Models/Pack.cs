using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeosApp.Models
{
	public class Pack
	{
		[BsonIgnoreIfNull, BsonIgnore]
		public MongoDB.Bson.ObjectId? Id { get; set; }

		[BsonElement("Pack_ID")]
		public string PackID { get; set; }

		[BsonElement("Pack_Name")]
		public string PackName { get; set; }

		[BsonElement("Pack_Description")]
		public string PackDescription { get; set; }

		[BsonElement("Price")]
		public string Price { get; set; }

		[BsonElement("Image")]
		public string Image { get; set; }

		[BsonElement("Item_ID")]
		public string ItemID { get; set; }

	}
}
