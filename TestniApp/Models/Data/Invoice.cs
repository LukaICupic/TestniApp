using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestniApp.Models.Data
{
    public class Invoice
    {
        internal Invoice(DateTimeOffset created, DateTimeOffset paymentDue, string createdBy, string sendingTo = default)
        {
            SetDates(created, paymentDue);
            SetCreatedBy(createdBy);
            SendingTo = sendingTo;
        }
        public int Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset PaymentDue { get; set; } //datetime picker?
        public decimal ProductTotal { get; set; } //svi proizvodi bez poreza cijena (cijena * kvantiteta) - TaxTotal
        public decimal TaxTotal { get; set; } //izdatak sveukupni na porez(e) (cijena * porez)
        public decimal Total { get; set; } //ItemTotal + TaxTotal
        public string CreatedBy { get; set; }
        public string SendingTo { get; set; }
        public ICollection<InvoiceProduct> Items { get; set; }
        public ICollection<InvoiceTax> Taxes { get; set; }

        public Invoice SetDates(DateTimeOffset created, DateTimeOffset paymentDue)
        {
            if (created != null && created < paymentDue)
                throw new ArgumentException($"The payment date of the invoice is set to a time before the invoice was actually created");

            CreationDate = created;
            PaymentDue = paymentDue;

            return this;
        }

        public Invoice SetCreatedBy(string createdBy)
        {
            if (string.IsNullOrWhiteSpace(createdBy))
                throw new ArgumentNullException(nameof(createdBy));

            CreatedBy = createdBy;
            return this;
        }
    }
}