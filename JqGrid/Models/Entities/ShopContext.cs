using System.Data.Entity;

namespace JqGrid.Models.Entities
{
    public class ShopContext : DbContext
    {
        public ShopContext()
        {

        }

        public ShopContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderQuestion> OrderQuestions { get; set; }
        public DbSet<OrderAnswer> OrderAnswers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.Name).HasMaxLength(100);
            base.OnModelCreating(modelBuilder);
        }
    }
}