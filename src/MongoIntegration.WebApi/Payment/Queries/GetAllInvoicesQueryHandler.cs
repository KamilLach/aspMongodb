using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoIntegration.Framework;
using MongoIntegration.Model;

namespace MongoIntegration.WebApi.Payment.Queries
{
    public class GetAllInvoicesQueryHandler : IQueryHandler<GetAllInvoicesQuery, IEnumerable<Invoice>>
    {
        private readonly IMongoDatabase _dbContext;

        public GetAllInvoicesQueryHandler(IMongoDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Invoice> Handle(GetAllInvoicesQuery query)
        {
            var filter = new BsonDocument();
            var collection = _dbContext.GetCollection<Invoice>("invoice");
            return collection.Find(filter).ToEnumerable(); ;
        }
    }
}