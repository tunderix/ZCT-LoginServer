using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ZCTLoginServer.Models
{
    public class LFAccount
    {
        [BsonId]
        public ObjectId AccountId { get; set; }
        [BsonRequired]
        public string Name { get; set; }

        public string FirstName  { get; set; }
        public string Password { get; set; }

    }
}
