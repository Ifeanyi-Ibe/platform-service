using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {

        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if(dbContext == null)
                {
                    throw new ArgumentException("Context cannot be null");
                }
                SeedData(dbContext);
            }
        }

        private static void SeedData(ApplicationDbContext context)
        {
            if(!context.Platforms.Any())
            {
                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Mastering React", Publisher = "Frontend Masters", Cost = "Free" },
                    new Platform() { Name = "You Don't Know JavaScript", Publisher = "O'Reilly", Cost = "Free" }
                );

                context.SaveChanges();
            } else 
            {
                System.Console.WriteLine("Data already exist");
            }
        }
    }
}