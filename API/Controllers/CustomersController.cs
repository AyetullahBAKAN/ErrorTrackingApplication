using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class CustomersController : CustomBaseController
    {
        private readonly IService<Customer> _customerService;
        private readonly IMapper _mapper;

        public CustomersController(IMapper mapper, IService<Customer> customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            var customersDto = _mapper.Map<List<CustomerDto>>(customers.ToList());
            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customersDto));

        }

        //[HttpGet("[action]/{customerId}")]

        //public async Task<IActionResult> GetCustomerByIdWithProjectListAsync(Guid customerId)
        //{
        //    return CreateActionResult(await _customerService.GetCustomerByIdWithProjectListAsync(customerId));
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customers = await _customerService.GetByIdAsync(id);
            var customersDto = _mapper.Map<ErrorDefineDto>(customers);
            return CreateActionResult(CustomResponseDto<ErrorDefineDto>.Success(200, customersDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            var customers = await _customerService.AddAsync(_mapper.Map<Customer>(customerDto));
            customers.IsDeleted = false;
            var customersDto = _mapper.Map<CustomerDto>(customers);

            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(201, customersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            await _customerService.UpdateAsync(_mapper.Map<Customer>(customerDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var customers = await _customerService.GetByIdAsync(id);
            customers.IsDeleted = true;

            await _customerService.UpdateAsync(customers);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
