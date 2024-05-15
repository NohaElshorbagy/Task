using Task.DTOs;

namespace Task.Repositories.IRepos
{
	public interface ICustomerRepo
	{
		Task<IEnumerable<GetCustomerTabeDTO>> GetAllCustomer();
	}
}
