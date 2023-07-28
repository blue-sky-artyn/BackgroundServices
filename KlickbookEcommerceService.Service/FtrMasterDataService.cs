using KlickbookEcommerceService.Common;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace KlickbookEcommerceService.Service
{
    public interface IFtrMasterDataService
    {
        MasterDataMetaViewModel GetDataTableMeta(string tablename);
    }

    public class FtrMasterDataService : IFtrMasterDataService
    {
        protected IMongoCollection<MasterDataMetaViewModel> _db;
        public FtrMasterDataService(IMongoClient mongoClient)
        {
            var db = mongoClient.GetDatabase("SAASv2");
            _db = db.GetCollection<MasterDataMetaViewModel>("ftrmasterdata");
        }

        public MasterDataMetaViewModel GetDataTableMeta(string tablename)
        {
            return _db.Find(x => x.tablename == tablename).FirstOrDefault();
        }
    }
}
