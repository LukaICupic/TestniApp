using System;
using TestniApp.Interfaces;
using TestniApp.Models.Data;
using System.ComponentModel.Composition;


namespace Croatia
{
    [Export(typeof(IInvoice))]
    public class taxCroatia : IInvoice
    {
        public string Id => "HR";

        public string Name => "Croatia";

        public decimal CalculateTotal(decimal total)
        {
            return total * 0.25M;
        }
    }
}
