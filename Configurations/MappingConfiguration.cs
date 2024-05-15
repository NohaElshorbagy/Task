using AutoMapper;
using Task.DTOs;
using Task.Migrations;
using Task.Repositories.Repos;

namespace Task.Configurations
{
	public class MappingConfiguration: Profile
	{
        public MappingConfiguration()
        {
			CreateMap<CustomerData, GetCustomerTabeDTO>().ReverseMap();

		}
	}
}
