using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ZCTLoginServer.Models
{
    public class RegistrationInformation
    {
        [BsonRequired]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
