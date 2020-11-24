using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestniApp.Models.Data;

namespace TestniApp.Interfaces
{
    public interface IDocument
    {
        Invoice GetInvoice(int Id);

        IEnumerable<Invoice> GetInvoices();

        Invoice AddInvoice(Invoice invoice);

        Invoice EditInvoice(Invoice invoice);

    }
}
