using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Common
{
    public class MasterDataViewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string id { get; set; }
        public List<dynamic> data { get; set; }
        public string tablename { get; set; }
        public string tenant { get; set; }
    }

    public class MasterDataMetaViewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string id { get; set; }
        public List<dynamic> data { get; set; }
        public List<Columns> columns { get; set; }
        public string tablename { get; set; }
        public string tenant { get; set; }

    }
    public class Columns
    {
        public string name { get; set; }
        public string datatypeid { get; set; }

    }

    public class SaveMasterDataViewModel
    {
        public List<dynamic> data { get; set; }
        public string tablename { get; set; }
        public string tenant { get; set; }

    }
}
