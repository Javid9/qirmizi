using Microsoft.EntityFrameworkCore;

namespace Infrastructure.CustomMigrations
{
    public static class DataSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            UserSeed.Seed(modelBuilder);

        }
    }
}
