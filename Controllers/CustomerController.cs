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
					return Ok(result); // Status Code: 200 with result in response body

				return NotFound("No customers found."); // Status Code: 404 if no customers found

			}
			return BadRequest("Something went wrong"); // Status code: 400
		}
	}
}
