using Microsoft.EntityFrameworkCore;
using Sales_Date_Prediction.DTO;
using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction
{
	public class AppDBContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Shipper> Shippers { get; set; }
		public DbSet<Product> Products { get; set; }

		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<PredictedOrderDTO>().HasNoKey();
			modelBuilder.Entity<Order>().ToTable("Orders", schema: "Sales");
			modelBuilder.Entity<Employee>().ToTable("Employees", schema: "HR");
			modelBuilder.Entity<Shipper>().ToTable("Shippers", schema: "Sales");

		}
	}

}
