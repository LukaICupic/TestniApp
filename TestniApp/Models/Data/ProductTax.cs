using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestniApp.Models.Data
{
    public class ProductTax
    {
        internal ProductTax(Product product, Tax tax)
        {
            ProductId = product.Id;
            Product = product;
            TaxId = tax.Id;
            Tax = tax;
        }

        public int ProductId { get; set; }
        public int TaxId { get; set; }
        public Product Product { get; set; }
        public Tax Tax { get; set; }
    }
}