using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MongoIntegration.Framework;
using MongoIntegration.Model;
using MongoIntegration.WebApi.Payment.Queries;

namespace MongoIntegration.WebApi.Payment
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IQueryExecutor _queryExecutor;

        public PaymentController(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        [HttpGet]
        public IEnumerable<Invoice> Get()
        {
            return _queryExecutor.Execute(new GetAllInvoicesQuery
            {
                InvoiceNumber = "Not used - just param example"
            });
        }

        [HttpPost]
        public void Post()
        {
            _queryExecutor.Execute(new AddInvoiceQuery
            {
                InvoiceNumber = "FA/1562/12/05/2016",
                Summary = "Example invoice summary"
            });
        }
    }
}