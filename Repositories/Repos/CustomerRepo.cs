using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Policy;
using Task.DTOs;
using Task.Models;
using Task.Repositories.IRepos;

namespace Task.Repositories.Repos
{
	public class CustomerRepo : ICustomerRepo
	{
		private readonly TaskDBContext _db;
		private readonly IMapper _mapper;

		public CustomerRepo(TaskDBContext db , IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<IEnumerable<GetCustomerTabeDTO>> GetAllCustomer()
		{
			var customers = await _db.CustomerDatas.ToListAsync();
			var customerDtos = customers.Select(c => new GetCustomerTabeDTO
			{
				Name = c.Name,
				Address = c.Address,
				District = c.District,
				Mobile = c.Mobile,
				PhoneNumber1 = c.PhoneNumber1,
				PhoneNumber2 = c.PhoneNumber2,
				Whatsapp_Number = c.Whatsapp_Number,
				Email = c.Email,
				Gender = c.Gender,
				residence = c.residence,
				Description = c.Description,
				Jop = c.Jop,
				Salesman = c.Salesman,
				Client_source = c.Client_source,
				Customer_rating = c.Customer_rating

			}).ToList();

			return customerDtos;
		}
	}
}
