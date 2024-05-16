using Task.DTOs;
using Task.Models;

namespace Task.Repositories.IRepos
{
	public interface ICustomerRepo
	{
		Task<IEnumerable<GetCustomerTabeDTO>> GetAllCustomer();

		Task<GetCustomerTabeDTO> UpdateCustomerAsync(int id, GetCustomerTabeDTO CustomerUpdate);

		Task<UserManagerResponse> AddCustomerAsync(GetCustomerTabeDTO model);

	}
}
