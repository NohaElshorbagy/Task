using Microsoft.EntityFrameworkCore;

namespace Task.Models
{
	public class TaskDBContext : DbContext
	{
		public DbSet<CustomerData> CustomerDatas { get; set; }
		public DbSet<CustomerCall> CustomerCalls { get; set; }
		public TaskDBContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CustomerData>()
				.HasMany(c => c.CustomerCalls)
				.WithOne(e => e.CustomerData)
				.OnDelete(DeleteBehavior.Cascade); // This enables cascading delete
		}
	}
}
