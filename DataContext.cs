using Microsoft.EntityFrameworkCore;
using BuisnessReBOT.Entities;

namespace BuisnessReBOT
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
