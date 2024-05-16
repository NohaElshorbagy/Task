
using Microsoft.EntityFrameworkCore;
using Task.Configurations;
using Task.Models;
using Task.Repositories.IRepos;
using Task.Repositories.Repos;

namespace Task
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

			// Add services to the container.

			builder.Services.AddDbContext<TaskDBContext>(options =>

				options.UseSqlServer(connectionString)
			);

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: "angularlocalhost",
								  policy =>
								  {
									  policy.AllowAnyHeader();
									  //policy.AllowAnyOrigin();
									  policy.WithOrigins("http://localhost:4200"); //angular origin 
									  policy.AllowAnyMethod();
								  });
			});
			//automapper 
			builder.Services.AddAutoMapper(typeof(MappingConfiguration));

			builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();


			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseCors("angularlocalhost");

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
