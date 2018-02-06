using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using ZCTLoginServer.Models;
using System.Threading.Tasks;
namespace ZCTLoginServer.Services
{
    public class MongoDbService
    {
        private IMongoCollection<LFAccount> accountCollection { get; }

        public MongoDbService(string dataBaseName, string collectionName, string dataBaseUrl){
            var mongoClient = new MongoClient(dataBaseUrl);
            var mongoDataBase = mongoClient.GetDatabase(dataBaseName);

            accountCollection = mongoDataBase.GetCollection<LFAccount>(collectionName);
        }

        public async Task InsertAccount(LFAccount account) => await accountCollection.InsertOneAsync(account);

        public async Task<List<LFAccount>> GetAllAccounts(){
            var accounts = new List<LFAccount>();

            var allDocuments = await accountCollection.FindAsync(new BsonDocument());
            await allDocuments.ForEachAsync(doc => accounts.Add(doc));
            return accounts;
        }
    }
}
