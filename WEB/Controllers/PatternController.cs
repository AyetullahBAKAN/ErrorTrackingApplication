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

	public class PatternController : Controller
    {
        private readonly PatternService _service;
        private readonly CustomerService _customerService;
        private readonly ProjectService _projectService;
        private readonly MontageLetterService _montageLetterService;
        private readonly PartService _partService;
        private readonly OperationService _operationService;
        private readonly IMapper _mapper;
        public PatternController(PatternService service, IMapper mapper, CustomerService customerService,
               ProjectService projectService, MontageLetterService montageLetterService, PartService partService, OperationService operationService)
        {
            _service = service;
            _mapper = mapper;
            _customerService = customerService;
            _projectService = projectService;
            _montageLetterService = montageLetterService;
            _partService = partService;
            _operationService = operationService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetPatternListAsync();
            if (result == null )
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var pattern = await _service.GetAllAsync();
            var patternDto = _mapper.Map<List<PatternDto>>(pattern.ToList());

            return View(CustomResponseDto<List<PatternDto>>.Success(200, patternDto));
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var customers = await _customerService.GetAllAsync();
            var customerDto = _mapper.Map<List<CustomerDto>>(customers.Where(x => !x.IsDeleted));
            ViewBag.customers = new SelectList(customerDto, "Id", "CustomerName");

            var projects = await _projectService.GetAllAsync();
            var projectDto = _mapper.Map<List<ProjectDto>>(projects.Where(x => !x.IsDeleted));
            ViewBag.projects = new SelectList(projectDto, "Id", "ProjectName");

            var montageLetters = await _montageLetterService.GetAllAsync();
            var montageLetterDto = _mapper.Map<List<MontageLetterDto>>(montageLetters.Where(x => !x.IsDeleted));
            ViewBag.montageLetters = new SelectList(montageLetterDto, "Id", "MontageNumber");

            var operations = await _operationService.GetAllAsync();
            var operationsDto = _mapper.Map<List<OperationDto>>(operations.Where(x => !x.IsDeleted));
            ViewBag.operations = new SelectList(operationsDto, "Id", "OperationNo");

            var parts = await _partService.GetAllAsync();
            var partDto = _mapper.Map<List<PartDto>>(parts.Where(x => !x.IsDeleted));
            ViewBag.parts = new SelectList(partDto, "Id", "PartNo");

            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(PatternDto patternDto)
        {


            var pattern = _mapper.Map<Pattern>(patternDto);
            await _service.AddAsync(pattern);

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var pattern = await _service.GetByIdAsync(id);

            var customers = await _customerService.GetAllAsync();
            var customerDto = _mapper.Map<List<CustomerDto>>(customers.Where(x => !x.IsDeleted));
            ViewBag.Customers = new SelectList(customerDto, "Id", "CustomerName", pattern.CustomerId);

            var projects = await _projectService.GetAllAsync();
            var projectDto = _mapper.Map<List<ProjectDto>>(projects.Where(x => !x.IsDeleted));
            ViewBag.Projects = new SelectList(projectDto, "Id", "ProjectName", pattern.ProjectId);

            var montageLetters = await _montageLetterService.GetAllAsync();
            var montageLetterDto = _mapper.Map<List<MontageLetterDto>>(montageLetters.Where(x => !x.IsDeleted));
            ViewBag.MontageLetters = new SelectList(montageLetterDto, "Id", "MontageNumber", pattern.MontageLetterId);

            var operations = await _operationService.GetAllAsync();
            var operationsDto = _mapper.Map<List<OperationDto>>(operations.Where(x => !x.IsDeleted));
            ViewBag.operations = new SelectList(operationsDto, "Id", "OperationNo", pattern.OperationId);


            var parts = await _partService.GetAllAsync();
            var partDto = _mapper.Map<List<PartDto>>(parts.Where(x => !x.IsDeleted));
            ViewBag.Parts = new SelectList(partDto, "Id", "PartNo", pattern.PartId);

            return View(_mapper.Map<PatternDto>(pattern));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(PatternDto patternDto)
        {
       
            await _service.UpdateAsync(_mapper.Map<Pattern>(patternDto));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ShowPattern(Guid id)
        {
            var pattern = await _service.GetByIdAsync(id);

            var customers = await _customerService.GetAllAsync();
            var customerDto = _mapper.Map<List<CustomerDto>>(customers.Where(x => !x.IsDeleted));
            ViewBag.Customers = new SelectList(customerDto, "Id", "CustomerName", pattern.CustomerId);

            var projects = await _projectService.GetAllAsync();
            var projectDto = _mapper.Map<List<ProjectDto>>(projects.Where(x => !x.IsDeleted));
            ViewBag.Projects = new SelectList(projectDto, "Id", "ProjectName", pattern.ProjectId);

            var montageLetters = await _montageLetterService.GetAllAsync();
            var montageLetterDto = _mapper.Map<List<MontageLetterDto>>(montageLetters.Where(x => !x.IsDeleted));
            ViewBag.MontageLetters = new SelectList(montageLetterDto, "Id", "MontageNumber", pattern.MontageLetterId);

            var operations = await _operationService.GetAllAsync();
            var operationsDto = _mapper.Map<List<OperationDto>>(operations.Where(x => !x.IsDeleted));
            ViewBag.operations = new SelectList(operationsDto, "Id", "OperationNo", pattern.OperationId);


            var parts = await _partService.GetAllAsync();
            var partDto = _mapper.Map<List<PartDto>>(parts.Where(x => !x.IsDeleted));
            ViewBag.Parts = new SelectList(partDto, "Id", "PartNo", pattern.PartId);

            return View(_mapper.Map<PatternDto>(pattern));
        }

        [HttpPost]
        public async Task<IActionResult> ShowPattern(PatternDto patternDto)
        {

            await _service.UpdateAsync(_mapper.Map<Pattern>(patternDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> DeletePattern(Guid id)
        {
            var pattern = await _service.GetByIdAsync(id);

            var customers = await _customerService.GetAllAsync();
            var customerDto = _mapper.Map<List<CustomerDto>>(customers.Where(x => !x.IsDeleted));
            ViewBag.Customers = new SelectList(customerDto, "Id", "CustomerName", pattern.CustomerId);

            var projects = await _projectService.GetAllAsync();
            var projectDto = _mapper.Map<List<ProjectDto>>(projects.Where(x => !x.IsDeleted));
            ViewBag.Projects = new SelectList(projectDto, "Id", "ProjectName", pattern.ProjectId);

            var montageLetters = await _montageLetterService.GetAllAsync();
            var montageLetterDto = _mapper.Map<List<MontageLetterDto>>(montageLetters.Where(x => !x.IsDeleted));
            ViewBag.MontageLetters = new SelectList(montageLetterDto, "Id", "MontageNumber", pattern.MontageLetterId);

            var operations = await _operationService.GetAllAsync();
            var operationsDto = _mapper.Map<List<OperationDto>>(operations.Where(x => !x.IsDeleted));
            ViewBag.operations = new SelectList(operationsDto, "Id", "OperationNo", pattern.OperationId);


            var parts = await _partService.GetAllAsync();
            var partDto = _mapper.Map<List<PartDto>>(parts.Where(x => !x.IsDeleted));
            ViewBag.Parts = new SelectList(partDto, "Id", "PartNo", pattern.PartId);

            return View(_mapper.Map<PatternDto>(pattern));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeletePattern(PatternDto patternDto)
        {

            await _service.UpdateAsync(_mapper.Map<Pattern>(patternDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var pattern = await _service.GetByIdAsync(id);
            pattern.IsDeleted = true;
            await _service.UpdateAsync(pattern);
            return RedirectToAction(nameof(Index));
        }
    }
}

