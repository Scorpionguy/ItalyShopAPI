using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ItalyShopAPI.Data
{
    public class ItalyShopDbContextFactory : IDesignTimeDbContextFactory<ItalyShopDbContext>
    {
        public ItalyShopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ItalyShopDbContext>();

            // строку подключения замени на свою
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ItalyShop;Username=postgres;Password=1234");

            return new ItalyShopDbContext(optionsBuilder.Options);
        }
    }
}
