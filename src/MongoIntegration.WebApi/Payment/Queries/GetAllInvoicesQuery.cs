using System.Collections.Generic;
using MongoIntegration.Framework;
using MongoIntegration.Model;

namespace MongoIntegration.WebApi.Payment.Queries
{
    public class GetAllInvoicesQuery : IQuery<IEnumerable<Invoice>>
    {
        public string InvoiceNumber { get; set; }
    }
}