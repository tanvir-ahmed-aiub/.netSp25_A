namespace DAL.Migrations
{
    using DAL.EF.Tables;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.PMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.PMSContext context)
        {
            /*for (int i = 1; i <= 10; i++) {
                var c = new Category() { 
                    Name = Guid.NewGuid().ToString().Substring(0,6),
                };
                context.Categories.Add(c);
            }
            context.SaveChanges();

            Random rand = new Random();

            for (int i = 1; i <= 1000; i++)
            {
                var p = new Product()
                {
                    Name = Guid.NewGuid().ToString().Substring(0, 8),
                    Qty = rand.Next(1,101),
                    Price = rand.NextDouble(),
                    CatId = rand.Next(1,11) 
                };
                context.Products.Add(p);
            }
            context.SaveChanges();*/

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
