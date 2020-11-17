using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestniApp.Models.Data
{
    public class InvoiceProduct
    {
        internal InvoiceProduct(Invoice invoice, Product product, decimal price, decimal quantity)
        {
            InvoiceId = invoice.Id;
            Invoice = invoice;
            ProductId = product.Id;
            Product = product;
            SetPrice(price);
            SetQuantity(quantity);
        }

        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }

        //title?
        public decimal Title { get; set; }
        public decimal Price { get; set; } // bez poreza
        public decimal Quantity { get; set; }
        public decimal Total { get; set; } //bez poreza

        void CalculateTotal()
        {
            Total = Price * Quantity;
        }

        public InvoiceProduct SetQuantity(decimal quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            if(Quantity != quantity)
            {
                Quantity = quantity;
                CalculateTotal();
            }

            return this;
        }

        public InvoiceProduct SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price));

            if(Price != price)
            {
                Price = price;
                CalculateTotal();
            }

            return this;
        }
    }
}