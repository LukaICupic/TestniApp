using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestniApp.Models.Data
{
    public class Invoice
    {
        public Invoice() { }
        internal Invoice(string title, string createdBy, string sendingTo = default)
        {
            SetTitle(title);
            SetDates();
            SetCreatedBy(createdBy);
            SendingTo = sendingTo;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset PaymentDue { get; set; } 
        public decimal ProductTotal { get; set; } 
        public decimal TaxTotal { get; set; } 
        public decimal Total { get; set; } 
        public string CreatedBy { get; set; }
        public string SendingTo { get; set; }
        public ICollection<InvoiceProduct> Items { get; set; }
        public ICollection<InvoiceTax> Taxes { get; set; }

        public Invoice SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();

            Title = title;

            return this;
        }

        public Invoice SetDates()
        {
            CreationDate = DateTimeOffset.Now;
            PaymentDue = DateTimeOffset.Now.AddDays(7.0);

            return this;
        }

        public Invoice SetCreatedBy(string createdBy)
        {
            if (string.IsNullOrWhiteSpace(createdBy))
                throw new ArgumentNullException(nameof(createdBy));

            CreatedBy = createdBy;
            return this;
        }

        public Invoice SetProductTotal(decimal price, decimal quantity)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price));

            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            ProductTotal = price * quantity;
            return this;
        }

        public Invoice SetTaxTotal(decimal taxTotal)
        {
            TaxTotal = taxTotal;
            return this;
        }

       public void SetTotal()
        {
            Total = ProductTotal + TaxTotal;
        }
    }
}