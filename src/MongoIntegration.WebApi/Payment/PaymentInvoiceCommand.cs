using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoIntegration.Core;
using MongoIntegration.Model;

namespace MongoIntegration.WebApi.Payment
{
    public class PaymentInvoiceCommand : IPaymentInvoiceCommand
    {
        private readonly IMongoDatabase _dbContext;

        public PaymentInvoiceCommand(IMongoDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute()
        {
            var collection = _dbContext.GetCollection<BsonDocument>("invoice");
            var generator = new Random();
            var invoice = new Invoice
            {
                InvoiceNumber = "FA13423/2016/03/" + generator.Next(),
                IssueDate = DateTime.Now,
                Summary = "For all procuts"
            };

            collection.InsertOne(invoice.ToBsonDocument());
        }
    }

    public interface IPaymentInvoiceCommand : ICommand
    {
    }
}