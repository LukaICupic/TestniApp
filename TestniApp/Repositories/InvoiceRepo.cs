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
    public class InvoiceRepo : IDocument
    {
        private readonly AppDbContext _context;

        public InvoiceRepo(AppDbContext context)
        {
            _context = context;
        }

        public Invoice GetInvoice(int Id)
        {
            var invoice = _context.Invoices.SingleOrDefault(i => i.Id == Id);

            if (invoice == null)
                throw new Exception($"Invoice with the given Id {Id} was not found.");

            return invoice;
        }

        public IEnumerable<Invoice> GetInvoices()
        {
            return _context.Invoices;

        }

        public Invoice AddInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);

            _context.SaveChanges();
            return invoice;

        }

        public Invoice EditInvoice(Invoice invoice)
        {
            var newInvoice = _context.Invoices.Single(i => i.Id == invoice.Id);
                  

            newInvoice.Title = invoice.Title;
            newInvoice.CreationDate = invoice.CreationDate;
            newInvoice.PaymentDue = invoice.PaymentDue;
            newInvoice.ProductTotal = invoice.ProductTotal;
            newInvoice.TaxTotal = invoice.TaxTotal;
            newInvoice.Total = invoice.Total;
            newInvoice.CreatedBy = invoice.CreatedBy;
            newInvoice.SendingTo = invoice.SendingTo;
            newInvoice.Items = invoice.Items;
            newInvoice.Taxes = invoice.Taxes;

            _context.SaveChanges();
            return newInvoice;
        }
    }
}