using System.Data.Entity;

namespace EntityWeb.DAL
{
    public class DataInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.SaveChanges();
        }
    }
}