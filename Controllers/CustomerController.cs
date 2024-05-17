using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.DTOs;
using Task.Repositories.IRepos;
using Task.Repositories.Repos;

namespace Task.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerRepo _CustomerRepo;

		public CustomerController(ICustomerRepo CustomerRepo)
		{
			_CustomerRepo = CustomerRepo;
		}
		[HttpGet("GetAllCustomer")]
		public async Task<IActionResult> GetCustomerAsync()
		{

			if (ModelState.IsValid)
			{
				var result = await _CustomerRepo.GetAllCustomer();
				if (result != null && result.Any())
					return Ok(result);

				return NotFound("No customers found.");

			}
			return BadRequest("Something went wrong");
		}
		[HttpGet("GetCustomerCalls")]
		public async Task<IActionResult> GetCustomerCallAsync(int id)
		{

			if (ModelState.IsValid)
			{
				var result = await _CustomerRepo.GetAllCustomerCallAsync(id);
				if (result != null && result.Any())
					return Ok(result);

				return NotFound("No calls for this customer found.");

			}
			return BadRequest("Something went wrong");
		}

		[HttpGet("{id}" , Name ="GetCustomerById")]
		public async Task<IActionResult> GetCustomerByIdAsync(int id)
		{

			if (ModelState.IsValid)
			{
				var result = await _CustomerRepo.GetCustomerById(id);
				if (result != null )
					return Ok(result); 

				return NotFound("No customers found.");

			}
			return BadRequest("Something went wrong");
		}
		[HttpPut("{id}", Name = "UpdateCustomer")]
		public async Task<IActionResult> UpdateCustomerAsync(int id, [FromBody] GetCustomerTabeDTO customerUpdate)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid model state."); 
			}

			var updatedCustomer = await _CustomerRepo.UpdateCustomerAsync(id, customerUpdate);

			if (updatedCustomer != null)
			{
				return Ok(updatedCustomer); 
			}
			else
			{
				return NotFound("Customer not found.");
			}
		}
		[HttpPost("AddCustomer")]
		public async Task<IActionResult> AddCustomerAsync([FromBody] GetCustomerTabeDTO model)
		{


			if (ModelState.IsValid)
			{
				var result = await _CustomerRepo.AddCustomerAsync(model);
				if (result.IsSuccess)
					return Ok(result); // Status Code: 200
				return BadRequest(result);
			}
			return BadRequest("Some properties are not valid"); // Status code: 400
		}

		[HttpPost("AddCustomerCall")]
		public async Task<IActionResult> AddCustomerCallAsync([FromBody] GetCustomerCallDTO model)
		{


			if (ModelState.IsValid)
			{
				var result = await _CustomerRepo.AddCustomerCallAsync(model);
				if (result.IsSuccess)
					return Ok(result); // Status Code: 200
				return BadRequest(result);
			}
			return BadRequest("Some properties are not valid"); // Status code: 400
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCustomerAsync(int id)
		{
			var result = await _CustomerRepo.DeleteCustomerAsync(id);
			if (result)
			{
				return Ok("Customer deleted successfully."); 
			}
			else
			{
				return NotFound("Customer not found.");
			}
		}
	}
}
