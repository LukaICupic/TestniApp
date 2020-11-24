using System;
using TestniApp.Interfaces;
using TestniApp.Models.Data;
using System.ComponentModel.Composition;


namespace BiH
{
    [Export(typeof(IInvoice))]
    public class taxBiH : IInvoice
    {
        public string Id => "BiH";

        public string Name => "Bosnia and Herzegovina";

        public decimal CalculateTotal(decimal total)
        {
            return total * 0.17M;
        }
    }
}
