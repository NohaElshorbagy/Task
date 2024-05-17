using Task.DTOs;
using Task.Models;

namespace Task.Repositories.IRepos
{
	public interface ICustomerRepo
	{
		Task<IEnumerable<GetCustomerTabeDTO>> GetAllCustomer();

		Task<GetCustomerTabeDTO> UpdateCustomerAsync(int id, GetCustomerTabeDTO CustomerUpdate);

		Task<UserManagerResponse> AddCustomerAsync(GetCustomerTabeDTO model);

		Task<CustomerData> GetCustomerById(int id);

		Task<bool> DeleteCustomerAsync(int id);

		Task<IEnumerable<GetCustomerCallDTO>> GetAllCustomerCallAsync(int id);

		Task<UserManagerResponse> AddCustomerCallAsync(GetCustomerCallDTO model);




	}
}
