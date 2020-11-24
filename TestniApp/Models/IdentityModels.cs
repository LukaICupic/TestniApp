using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TestniApp.Models.Data;

namespace TestniApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext() : base("AppDatabase")
        {
            Database.SetInitializer<AppDbContext>(new CreateDatabaseIfNotExists<AppDbContext>());
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
        public DbSet<InvoiceTax> InvoiceTaxes { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Invoice>().HasKey(i => i.Id);
            modelBuilder.Entity<InvoiceProduct>().HasKey(ip => ip.Id);
            modelBuilder.Entity<InvoiceTax>().HasKey(it => it.Id);

            //Relationships
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Items)
                .WithRequired(p => p.Product)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Invoice>()
              .HasMany(p => p.Items)
              .WithRequired(p => p.Invoice)
              .HasForeignKey(p => p.InvoiceId);

            modelBuilder.Entity<Invoice>()
              .HasMany(p => p.Taxes)
              .WithRequired(p => p.Invoice)
              .HasForeignKey(p => p.InvoiceId);
        }

    }
}