using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestniApp.Models.Data
{
    public class Tax
    {
        internal Tax(string title, decimal rate)
        {
            Title = title;
            SetRate(rate);
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Rate { get; set; }
        public ICollection<InvoiceTax> Invoices { get; set; }
        public ICollection<ProductTax> Products { get; set; }

        public Tax SetRate(decimal rate)
        {
            if (rate < 0 || rate > 1)
                throw new ArgumentOutOfRangeException(nameof(rate));

            Rate = rate;
            return this;
        }
    }
}