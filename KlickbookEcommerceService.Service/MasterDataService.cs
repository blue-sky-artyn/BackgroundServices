using KlickbookEcommerceService.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KlickbookEcommerceService.Service
{
    public interface IMasterDataService
    {
        MasterDataViewModel GetTableDataByTenant(string tenant, string tablename);
        MasterDataViewModel SaveMasterData(SaveMasterDataViewModel viewmodel);
    }

    public class MasterDataService : IMasterDataService
    {
        protected IMongoCollection<MasterDataViewModel> _db;
        protected IMongoCollection<BsonDocument> _dbBson;
        public MasterDataService(IMongoClient mongoClient)
        {
            var db = mongoClient.GetDatabase("MasterData");
            _db = db.GetCollection<MasterDataViewModel>("data");
            _dbBson = db.GetCollection<BsonDocument>("data");
        }

        public MasterDataViewModel GetTableDataByTenant(string tenant, string tablename)
        {
            return _db.Find(x => x.tablename == tablename && x.tenant == tenant).FirstOrDefault();
        }

        public MasterDataViewModel SaveMasterData(SaveMasterDataViewModel viewmodel)
        {
            var builder = new FilterDefinitionBuilder<BsonDocument>();
            var filter = builder.Eq("tenant", viewmodel.tenant) & builder.Eq("tablename", viewmodel.tablename);
            var options = new FindOneAndReplaceOptions<BsonDocument, BsonDocument>
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            };
            _dbBson.FindOneAndReplaceAsync(filter, BsonSerializer.Deserialize<BsonDocument>(JsonConvert.SerializeObject(viewmodel)), options).Wait();
            return _db.Find(x => x.tablename == viewmodel.tablename && x.tenant == viewmodel.tenant).FirstOrDefault();
        }
    }
}
