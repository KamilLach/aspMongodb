using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoIntegration.Core;
using MongoIntegration.Model;

namespace MongoIntegration.WebApi.Payment
{
    public class PaymentDataQuery : IPaymentDataQuery
    {
        private readonly IMongoDatabase _dbContext;

        public PaymentDataQuery(IMongoDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Invoice> Execute()
        {
            var filter = new BsonDocument();
            var collection = _dbContext.GetCollection<Invoice>("invoice");
            return collection.Find(filter).ToEnumerable();
        }
    }

    public interface IPaymentDataQuery : IQuery<IEnumerable<Invoice>>
    {
    }
}