namespace TestniApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestniApp.Models.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<TestniApp.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TestniApp.Models.AppDbContext context)
        {
            var products = new List<Product>
            {
                new Product("Traktorska guma 540/65", 100),
                new Product("Prednji utovarivač", 200)
            };
            products.ForEach(i => context.Products.Add(i));
            context.SaveChanges();
        }
    }
}
