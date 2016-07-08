using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MongoIntegration.Core;
using MongoIntegration.Model;

namespace MongoIntegration.WebApi.Payment
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentDataQuery _paymentQuery;
        private readonly IPaymentInvoiceCommand _paymentInvoiceCommand;

        public PaymentController(IPaymentDataQuery paymentQuery, IPaymentInvoiceCommand paymentInvoiceCommand)
        {
            _paymentQuery = paymentQuery;
            _paymentInvoiceCommand = paymentInvoiceCommand;
        }

        [HttpGet]
        public IEnumerable<Invoice> Get()
        {
            return _paymentQuery.Execute();
        }

        [HttpPost]
        public void Post()
        {
            _paymentInvoiceCommand.Execute();
        }
    }
}