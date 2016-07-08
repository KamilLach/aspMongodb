using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoIntegration.Framework;
using MongoIntegration.Model;

namespace MongoIntegration.WebApi.Payment.Queries
{
    public class AddInvoiceQueryHandler : IQueryHandler<AddInvoiceQuery, Invoice>
    {
        private readonly IMongoDatabase _dbContext;

        public AddInvoiceQueryHandler(IMongoDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public Invoice Handle(AddInvoiceQuery query)
        {
            var collection = _dbContext.GetCollection<BsonDocument>("invoice");
            var generator = new Random();
            var invoice = new Invoice
            {
                InvoiceNumber = query.InvoiceNumber + generator.Next(),
                IssueDate = DateTime.Now,
                Summary = query.Summary
            };

            collection.InsertOne(invoice.ToBsonDocument());
            return invoice;
        }
    }
}