using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestniApp.Interfaces;
using TestniApp.Models;
using TestniApp.Models.Data;
using TestniApp.Models.ViewModels.InvoiceVM;

namespace TestniApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController() 
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        [Route("/Home/Index")]
        public ActionResult Index()
        {
            IEnumerable<Invoice> model = _context.Invoices;

            return View(model);
        }

        [HttpGet]
        [Route("/Home/Details/{Id}")]
        public ViewResult Details(int Id)
        {
            Invoice invoice = _context.Invoices.SingleOrDefault(i => i.Id == Id);

            if (invoice == null)
            {
                ViewBag.ErrorMessage = $"Invoice with the Id = {Id} could not be found";
                return View("NotFound");
            }

            var items = _context.InvoiceProducts.Where(t => t.InvoiceId == invoice.Id).ToList();
            var taxes = _context.InvoiceTaxes.Where(t => t.InvoiceId == invoice.Id).ToList();

            InvoiceView newInvoice = new InvoiceView(invoice)
            {
                Items = items,
                Taxes = taxes,
            };
            return View(newInvoice);

        }

        [HttpGet] 
        public ActionResult AddInvoice()
        {
            IEnumerable<Product> products = _context.Products;

            var model = new Invoice();
      


            _context.Invoices.Add(model);
            _context.SaveChanges();

            InvoiceView viewInvoice = new InvoiceView(model);

            ViewBag.Products = (products);

            return View(viewInvoice);
        }

        [HttpPost]
        public ActionResult AddInvoice(string title, int invoiceId, int productId, decimal quantity, string tax)
        {
            if (quantity <= 0 || string.IsNullOrEmpty(title))
            {
                ViewBag.ErrorTitle = "Error whiel processing the request";
                ViewBag.ErrorMessage = "Either the quantity of the product was less or equal 0 or the title was not defined";

                var newInvoice =_context.Invoices.Single(i => i.Id == invoiceId);
                _context.Invoices.Remove(newInvoice);
                _context.SaveChanges();

                return View("Error");
            }

            if (ModelState.IsValid)
            {
                //ekstenzija
                var extensions = new AggregateCatalog();
                extensions.Catalogs.Add(new DirectoryCatalog("ekstenzije"));

                var container = new CompositionContainer(extensions);
                var invoiceExtensions = container.GetExports<IInvoice>();


                //dohvati podatke iz baze
                Invoice invoice = _context.Invoices.SingleOrDefault(i => i.Id == invoiceId);
                Product product = _context.Products.Single(i => i.Id == productId);
                IEnumerable<Product> products = _context.Products;

                if (invoice == null)
                {
                    ViewBag.ErrorMessage = $"Invoice with the Id = {invoiceId} could not be found";
                    return View("NotFound");
                }

                if (product == null)
                {
                    ViewBag.ErrorMessage = $"Product with the Id = {productId} could not be found";
                    return View("NotFound");
                }


                var invoiceExtension = invoiceExtensions.SingleOrDefault(x => x.Value.Id == tax)?.Value;
                if (invoiceExtension == null)
                    throw new ArgumentNullException(nameof(invoiceExtension));

                //unos
                invoice
                     .SetTitle(title)
                     .SetDates()
                     .SetCreatedBy(User.Identity.Name)
                     .SetProductTotal(product.Price, quantity)
                     .SetTaxTotal(invoiceExtension.CalculateTotal(invoice.ProductTotal))
                     .SetTotal();

                invoice.Items = new List<InvoiceProduct> { new InvoiceProduct(invoice, product, product.Price, quantity) { Title = product.Name} };
                invoice.Taxes = new List<InvoiceTax> { new InvoiceTax(invoice, invoice.TaxTotal) };


                _context.SaveChanges();

                var ili = _context.Invoices.SingleOrDefault(ip => ip.Id == invoice.Id);
                ViewBag.Products = new SelectList(products, nameof(Product.Id), nameof(Product.Name));

                return RedirectToAction("index");
            }

            return View("Error");
        }
    }
}