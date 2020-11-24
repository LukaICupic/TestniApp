using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestniApp.Interfaces;
using TestniApp.Models;
using TestniApp.Models.Data;

namespace TestniApp.Repositories
{
    public class ProductRepo : IProduct
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }

        public Product GetProduct(int Id)
        {
            var product = _context.Products.Single(p => p.Id == Id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

    }
}