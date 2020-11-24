using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestniApp.Models.Data
{
    public class InvoiceTax
    {
        InvoiceTax() { }
        internal InvoiceTax(Invoice invoice, decimal tax)
        {
            InvoiceId = invoice.Id;
            Invoice = invoice;
            Tax = tax;
        }

        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public decimal Tax { get; set; }
    }
}