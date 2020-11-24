using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestniApp.Models.Data;

namespace TestniApp.Interfaces
{
    public interface IInvoice
    {
        string Id { get; }
        string Name { get; }
        decimal CalculateTotal(decimal total);
    }
}
