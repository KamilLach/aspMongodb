using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MongoIntegration.Model
{
    public class Invoice
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string Summary { get; set; }
    }
}