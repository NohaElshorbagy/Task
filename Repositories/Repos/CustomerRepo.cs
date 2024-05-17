using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using Task.DTOs;
using Task.Models;
using Task.Repositories.IRepos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task.Repositories.Repos
{
	public class CustomerRepo : ICustomerRepo
	{
		private readonly TaskDBContext _db;
		private readonly IMapper _mapper;

		public CustomerRepo(TaskDBContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task<UserManagerResponse> AddCustomerAsync([FromBody] GetCustomerTabeDTO model)
		{
			if (model == null)
				throw new NullReferenceException("No Customer Added");

			var user = new CustomerData
			{
				Name = model.Name,
				Address = model.Address,
				District = model.District,
				Mobile = model.Mobile,
				PhoneNumber1 = model.PhoneNumber1,
				PhoneNumber2 = model.PhoneNumber2,
				Whatsapp_Number = model.Whatsapp_Number,
				Email = model.Email,
				Gender = model.Gender,
				residence = model.residence,
				Description = model.Description,
				Jop = model.Jop,
				Salesman = model.Salesman,
				Client_source = model.Client_source,
				Customer_rating = model.Customer_rating
			};
			_db.CustomerDatas.Add(user);
			await _db.SaveChangesAsync();
			return new UserManagerResponse
			{

				Message = "User created successfully!",
				IsSuccess = true,

			};
		}

		public async Task<UserManagerResponse> AddCustomerCallAsync([FromBody] GetCustomerCallDTO model)
		{
			if (model == null)
				throw new NullReferenceException("No Calls Added");

			// Retrieve the customer from the database based on the provided customer ID
			var customer = await _db.CustomerDatas.FindAsync(model.CustomerId);
			if (customer == null)
				throw new NullReferenceException("Customer not found");

			// Create a new customer call entity and populate it with the provided details
			var call = new CustomerCall
			{
				Description = model.Description,
				Call_Address = model.Call_Address,
				Date = model.Date,
				Employee = model.Employee,
				IsDone = model.IsDone,
				Call_Type = model.Call_Type,
				CustomerData = customer
			};

			// Add the new call to the database and save changes
			_db.CustomerCalls.Add(call);
			await _db.SaveChangesAsync();

			return new UserManagerResponse
			{
				Message = "Call Added successfully!",
				IsSuccess = true,
			};
		}

		public async Task<bool> DeleteCustomerAsync(int id)
		{
			var customerToDelete = await _db.CustomerDatas.FirstOrDefaultAsync(a => a.Id == id);
			if (customerToDelete == null) return false;

			_db.CustomerDatas.Remove(customerToDelete);
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<GetCustomerTabeDTO>> GetAllCustomer()
		{
			var customers = await _db.CustomerDatas.ToListAsync();
			var customerDtos = customers.Select(c => new GetCustomerTabeDTO
			{
				Id = c.Id,
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

		public async Task<IEnumerable<GetCustomerCallDTO>> GetAllCustomerCallAsync(int id)
		{
			var customers = await _db.CustomerCalls
									.Include(c => c.CustomerData) 
									.Where(c => c.CustomerData.Id == id)
									.ToListAsync();

			var customerDtos = customers.Select(c => new GetCustomerCallDTO
			{
				Id = c.Id,
				CustomerId = id ,
				Description = c.Description,
				Call_Address = c.Call_Address,
				Date = c.Date,
				Employee = c.Employee,
				IsDone = c.IsDone,
				Call_Type = c.Call_Type
			}).ToList();

			return customerDtos;
		}


		public async Task<CustomerData> GetCustomerById(int id)
		{
			CustomerData customer = await _db.CustomerDatas.FirstOrDefaultAsync(a => a.Id == id);
			if (customer == null)
			{
				return null;
			}

			return customer;
		}

		public async Task<GetCustomerTabeDTO> UpdateCustomerAsync(int id, GetCustomerTabeDTO CustomerUpdate)
		{
			CustomerData CustomerToUpdate = await _db.CustomerDatas.FirstOrDefaultAsync(a => a.Id == id); ;
			if (CustomerToUpdate == null) return null;

			CustomerToUpdate.Name = CustomerUpdate.Name;
			CustomerToUpdate.Address = CustomerUpdate.Address;
			CustomerToUpdate.District = CustomerUpdate.District;
			CustomerToUpdate.Mobile = CustomerUpdate.Mobile;
			CustomerToUpdate.PhoneNumber1 = CustomerUpdate.PhoneNumber1;
			CustomerToUpdate.PhoneNumber2 = CustomerUpdate.PhoneNumber2;
			CustomerToUpdate.Whatsapp_Number = CustomerUpdate.Whatsapp_Number;
			CustomerToUpdate.Email = CustomerUpdate.Email;
			CustomerToUpdate.Gender = CustomerUpdate.Gender;
			CustomerToUpdate.residence = CustomerUpdate.residence;
			CustomerToUpdate.Description = CustomerUpdate.Description;
			CustomerToUpdate.Jop = CustomerUpdate.Jop;
			CustomerToUpdate.Salesman = CustomerUpdate.Salesman;
			CustomerToUpdate.Client_source = CustomerUpdate.Client_source;
			CustomerToUpdate.Customer_rating = CustomerUpdate.Customer_rating;

			var result = await _db.SaveChangesAsync();
			if (result == null) return null;

			var updatedCustomerDTO = new GetCustomerTabeDTO
			{
				Id = CustomerToUpdate.Id,
				Name = CustomerToUpdate.Name,
				Address = CustomerToUpdate.Address,
				District = CustomerToUpdate.District,
				Mobile = CustomerToUpdate.Mobile,
				PhoneNumber1 = CustomerToUpdate.PhoneNumber1,
				PhoneNumber2 = CustomerToUpdate.PhoneNumber2,
				Whatsapp_Number = CustomerToUpdate.Whatsapp_Number,
				Email = CustomerToUpdate.Email,
				Gender = CustomerToUpdate.Gender,
				residence = CustomerToUpdate.residence,
				Description = CustomerToUpdate.Description,
				Jop = CustomerToUpdate.Jop,
				Salesman = CustomerToUpdate.Salesman,
				Client_source = CustomerToUpdate.Client_source,
				Customer_rating = CustomerToUpdate.Customer_rating
			};

			return updatedCustomerDTO;
		}
	}
}

