using MongoIntegration.Framework;
using MongoIntegration.Model;

namespace MongoIntegration.WebApi.Payment.Queries
{
    public class AddInvoiceQuery : IQuery<Invoice>
    {
        public string InvoiceNumber { get; set; }
        public string Summary { get; set; }
    }
}