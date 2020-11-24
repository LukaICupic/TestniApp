using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestniApp.Models.Data;

namespace TestniApp.Models.ViewModels.InvoiceVM
{
    public class InvoiceView
    {
        public InvoiceView () { }
        public InvoiceView(Invoice i)
        {
            Id = i.Id;
            Title = i.Title;
            CreationDate = i.CreationDate;
            PaymentDue = i.PaymentDue;
            ProductTotal = i.ProductTotal;
            TaxTotal = i.TaxTotal;
            Total = i.Total;
            CreatedBy = i.CreatedBy;
            SendingTo = i.SendingTo;

            Items = i.Items;
            Taxes = i.Taxes;
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
    }
}