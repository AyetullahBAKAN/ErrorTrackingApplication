using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class CustomerService : Service<Customer>
    {
        private readonly IMapper _mapper;
        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        //public async Task<CustomResponseDto<List<ProjectDto>>> GetCustomerByIdWithProjectListAsync(Guid customerId)
        //{
        //    var projects = await _customerRepository.GetCustomerByIdWithProjectListAsync(customerId);

        //    var projectsDto = _mapper.Map<List<ProjectDto>>(projects);

        //    return CustomResponseDto<List<ProjectDto>>.Success(200, projectsDto);}

        public async Task<List<CustomerDto>> GetCustomerListAsync()
        {
            try
            {
                var customerList = await GetListAsync(x => !x.IsDeleted);
                var customerListDto = _mapper.Map<List<CustomerDto>>(customerList.ToList());
                return customerListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
