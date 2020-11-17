using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestniApp.Models.Data
{
    public class Product
    {
        internal Product(string name, decimal price)
        {
            Name = name;
            SetPrice(price);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductTax> Taxes { get; set; }
        public ICollection<InvoiceProduct> Items { get; set; }

        public Product SetPrice(decimal price)
        {
            if (price < 0 )
                throw new ArgumentOutOfRangeException(nameof(price));

            Price = price;
            return this;
        }
    }
}