namespace WebApplication1.Database.Extensions
{
    public static class MyDbContextExtensions
    {
        public static void Seed(this MyDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (dbContext.Products.Count() > 0)
            {
                return;
            }

            dbContext.Products.Add(new Product
            {
                Name = "Andrew Test 1",
                Description = "Andrew long desc 1",
                Price = 219.5m,
                Type = ProductType.Regular,
                Stock = 12,
                PhotoFileName = "1.jpg",
                IntroducedAt = DateTime.Now,
                Rating = 4
            });

            dbContext.Products.Add(new Product
            {
                Name = "Andrew Test 2",
                Description = "Andrew long desc 2",
                Price = 1.5m,
                Type = ProductType.Regular,
                Stock = 12,
                PhotoFileName = "2.jpg",
                IntroducedAt = DateTime.Now,
                Rating = 3
            });

            dbContext.Products.Add(new Product
            {
                Name = "Andrew Test 3",
                Description = "Andrew long desc 3",
                Price = 33.5m,
                Type = ProductType.Sale,
                Stock = 12,
                PhotoFileName = "3.jpg",
                IntroducedAt = DateTime.Now.AddYears(-1),
                Rating = 5
            });
        }
    }
}
