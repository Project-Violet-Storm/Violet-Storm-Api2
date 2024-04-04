using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using violet.storm.data;

namespace violet.storm.Data;

public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
{
    public StoreContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
        optionsBuilder.UseSqlite("Data Source-../Registrar.sqlite");

        return new StoreContext(optionsBuilder.Options);
    }
}