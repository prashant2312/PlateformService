namespace PlateformService.Data
{
    public static class PrepDB
    {
         public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope=app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if(!context.Plateforms.Any())
            {
                Console.WriteLine("--> Seeding data...");
                context.Plateforms.AddRange(
                    new Models.Plateform() { Name="Dotnet",Publisher="Microsoft",Cost="Free"},
                    new Models.Plateform() { Name="Sql server expresss",Publisher="Microsoft",Cost="Free"},
                    new Models.Plateform() { Name="Docker",Publisher="Microsoft",Cost="Free"},
                    new Models.Plateform() { Name="Kubernetes",Publisher="Google",Cost="Free"}
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
