using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class ProjectController : Controller
    {
        private readonly CustomerService _customerService;
        private readonly ProjectService _service;
        private readonly IMapper _mapper;
        public ProjectController(ProjectService service, IMapper mapper, CustomerService customerService)
        {
            _service = service;
            _mapper = mapper;
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetProjectListAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var projects = await _service.GetAllAsync();
            var projectDto = _mapper.Map<List<ProjectDto>>(projects.ToList());

            return View(CustomResponseDto<List<ProjectDto>>.Success(200, projectDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var customer = await _customerService.GetAllAsync();
            var customerDto = _mapper.Map<List<CustomerDto>>(customer.Where(x => !x.IsDeleted));
            ViewBag.customer = new SelectList(customerDto, "Id", "CustomerName");
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(ProjectDto projectdto)
        {

            var pro = await _service.AddAsync(_mapper.Map<Project>(projectdto));
            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var project = await _service.GetByIdAsync(id);

            var customer = await _customerService.GetAllAsync();

            var customerDto = _mapper.Map<List<CustomerDto>>(customer.ToList());
            ViewBag.customer = new SelectList(customerDto, "Id", "CustomerName", project.CustomerId);

            return View(_mapper.Map<ProjectDto>(project));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectDto projectdto)
        {


            await _service.UpdateAsync(_mapper.Map<Project>(projectdto));

            return RedirectToAction(nameof(Index));

            //var customer = await _customerService.GetAllAsync();
            //var customerDto = _mapper.Map<List<CustomerDto>>(customer);
            //ViewBag.customer = new SelectList(customerDto, "Id", "CustomerName");
            //return View(projectdto);
        }
        public async Task<IActionResult> ShowProject(Guid id)
        {
            var project = await _service.GetByIdAsync(id);

            var customer = await _customerService.GetAllAsync();

            var customerDto = _mapper.Map<List<CustomerDto>>(customer.ToList());
            ViewBag.customer = new SelectList(customerDto, "Id", "CustomerName", project.CustomerId);

            return View(_mapper.Map<ProjectDto>(project));
        }

        [HttpPost]
        public async Task<IActionResult> ShowProject(ProjectDto projectdto)
        {


            await _service.UpdateAsync(_mapper.Map<Project>(projectdto));

            return RedirectToAction(nameof(Index));

            //var customer = await _customerService.GetAllAsync();
            //var customerDto = _mapper.Map<List<CustomerDto>>(customer);
            //ViewBag.customer = new SelectList(customerDto, "Id", "CustomerName");
            //return View(projectdto);
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var project = await _service.GetByIdAsync(id);

            var customer = await _customerService.GetAllAsync();

            var customerDto = _mapper.Map<List<CustomerDto>>(customer.ToList());
            ViewBag.customer = new SelectList(customerDto, "Id", "CustomerName", project.CustomerId);

            return View(_mapper.Map<ProjectDto>(project));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteProject(ProjectDto projectdto)
        {


            await _service.UpdateAsync(_mapper.Map<Project>(projectdto));

            return RedirectToAction(nameof(Index));

          
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var pro = await _service.GetByIdAsync(id);
            pro.IsDeleted = true;
            await _service.UpdateAsync(pro);
            return RedirectToAction(nameof(Index));
        }

    }
}
