using Microsoft.EntityFrameworkCore;
using models;

namespace _NET.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            

        }

        public DbSet<Movie> movies => Set<Movie>();
    }
}
