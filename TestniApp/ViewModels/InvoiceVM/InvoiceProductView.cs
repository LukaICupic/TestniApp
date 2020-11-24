using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestniApp.Models.Data;

namespace TestniApp.Models.ViewModels.InvoiceVM
{
    public class InvoiceProductView
    {
        public InvoiceProductView(InvoiceProduct ip)
        {
            Id = ip.Id;
            InvoiceId = ip.InvoiceId;
            ProductId = ip.ProductId;
            Title = ip.Title;
            Price = ip.Price;
            Quantity = ip.Quantity;
            Total = ip.Total;
        }

        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; } 
        public decimal Quantity { get; set; }
        public decimal Total { get; set; } 
    }
}