using DatinApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatinApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }
        public DbSet<Value> Value { get; set; }
         public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }

    }
}