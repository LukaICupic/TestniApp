using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestniApp.Models.Data
{
    public class InvoiceTax
    {
        internal InvoiceTax(Invoice invoice, Tax tax, decimal _base)
        {
            InvoiceId = invoice.Id;
            Invoice = invoice;
            TaxId = tax.Id;
            Tax = tax;
            SetBase(_base);
            SetRate(tax.Rate);
        }

        public int InvoiceId { get; set; }
        public int TaxId { get; set; }
        public Invoice Invoice { get; set; }
        public Tax Tax { get; set; }
        public decimal Base { get; set; } //cijena proizvoda bez poreza
        public decimal Rate { get; set; }
        public decimal Total { get; set; } //(base * rate)

        void CalculateTotal() => Total = Base * Rate;


        public InvoiceTax SetBase(decimal _base)
        {
            if (_base < 0)
                throw new ArgumentOutOfRangeException(nameof(_base));

            Base = _base;
            CalculateTotal();
            return this;
        }

        public InvoiceTax SetRate(decimal rate)
        {
            if (rate < 0)
                throw new ArgumentOutOfRangeException(nameof(rate));

            Rate = rate;
            CalculateTotal();
            return this;
        }
    }
}