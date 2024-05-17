using Microsoft.EntityFrameworkCore;

namespace Task.Models
{
	public class TaskDBContext : DbContext
	{
		public DbSet<CustomerData> CustomerDatas { get; set; }
		public DbSet<CustomerCall> CustomerCalls { get; set; }
		public TaskDBContext(DbContextOptions options) : base(options) { }
	}
}
