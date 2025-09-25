using ItalyShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ItalyShopAPI.Data
{
    public class ItalyShopDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Logs> Log { get; set; }
        public DbSet<Size> Size { get; set; }

        public ItalyShopDbContext(DbContextOptions<ItalyShopDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary keys
            modelBuilder.Entity<Client>().HasKey(c => c.idClient);
            modelBuilder.Entity<Employee>().HasKey(e => e.idEmp);
            modelBuilder.Entity<Title>().HasKey(t => t.idTitle);
            modelBuilder.Entity<Category>().HasKey(c => c.idCategory);
            modelBuilder.Entity<Good>().HasKey(g => g.article);
            modelBuilder.Entity<Order>().HasKey(o => o.idOrder);
            modelBuilder.Entity<OrderItem>().HasKey(oi => oi.idItems);
            modelBuilder.Entity<Logs>().HasKey(l => l.idLog);
            modelBuilder.Entity<Size>().HasKey(s => s.idSize);

            // Relations
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.jobTitle)
                .WithMany(t => t.employees)
                .HasForeignKey(e => e.jobTitleFk);

            modelBuilder.Entity<Good>()
                .HasOne(g => g.category)
                .WithMany(c => c.goods)
                .HasForeignKey(g => g.categoryFk);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.client)
                .WithMany(c => c.orders)
                .HasForeignKey(o => o.idClientFk);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.order)
                .WithMany(o => o.orderItems)
                .HasForeignKey(oi => oi.orderIdFk);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.good)
                .WithMany(g => g.orderItems)
                .HasForeignKey(oi => oi.articleFk);

            modelBuilder.Entity<Logs>()
                .HasOne(l => l.employee)
                .WithMany(e => e.logs)
                .HasForeignKey(l => l.idEmpFk);

            modelBuilder.Entity<Size>()
                .HasOne(s => s.good)
                .WithMany(g => g.sizes)
                .HasForeignKey(s => s.goodFk);
        }
    }
}
