using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestniApp.Models.Data;

namespace TestniApp.Interfaces
{
    public interface IProduct
    {
        Product GetProduct(int Id);
        IEnumerable<Product> GetProducts();
 
    }
}
