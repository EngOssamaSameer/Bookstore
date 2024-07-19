using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Context
{
    public class AppDbContext : DbContext
    {
        virtual public DbSet<Book> TbBooks { get; set; }
        virtual public DbSet<Order> TbOrders { get; set; }

        public AppDbContext(DbContextOptions opt) : base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
