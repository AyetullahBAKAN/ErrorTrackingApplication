using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class CustomerController : Controller
    {
        private readonly CustomerService _service;
        private readonly IMapper _mapper;
        public CustomerController(CustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

       
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetCustomerListAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customer = await _service.GetAllAsync();
            var customerDto = _mapper.Map<List<CustomerDto>>(customer.ToList());

            return View(CustomResponseDto<List<CustomerDto>>.Success(200, customerDto));
        }
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> Create()
        {
            var customer = await _service.GetAllAsync();
            var customerDtos = _mapper.Map<List<CustomerDto>>(customer.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto customerDto)
        {

            var customers = await _service.AddAsync(_mapper.Map<Customer>(customerDto));
            return RedirectToAction(nameof(Index));

            //var customer = await _service.GetAllAsync();
            //var customerDtos = _mapper.Map<CustomerDto>(customer);

            //return View();
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var customer = await _service.GetByIdAsync(id);

            return View(_mapper.Map<CustomerDto>(customer));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerDto customerDto)
        {

            await _service.UpdateAsync(_mapper.Map<Customer>(customerDto));

            return RedirectToAction(nameof(Index));
        }
        

        public async Task<IActionResult> ShowCustomer(Guid id)
        {
            var customer = await _service.GetByIdAsync(id);

            return View(_mapper.Map<CustomerDto>(customer));
        }


        [HttpPost]
        public async Task<IActionResult> ShowCustomer(CustomerDto customerDto)
        {


            await _service.UpdateAsync(_mapper.Map<Customer>(customerDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customer = await _service.GetByIdAsync(id);

            return View(_mapper.Map<CustomerDto>(customer));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(CustomerDto customerDto)
        {

            await _service.UpdateAsync(_mapper.Map<Customer>(customerDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _service.GetByIdAsync(id);
            customer.IsDeleted = true;
            await _service.UpdateAsync(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
