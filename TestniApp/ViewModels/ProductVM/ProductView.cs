using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestniApp.Models.Data;

namespace TestniApp.Models.ViewModels.ProductVM
{
    public class ProductView
    {
        public ProductView(Product product)
        {
            ProductId = product.Id;
            Name = product.Name;
            Price = product.Price;
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }
}