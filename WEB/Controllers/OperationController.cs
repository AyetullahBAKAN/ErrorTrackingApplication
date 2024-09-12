using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class OperationController : Controller
    {
        private readonly OperationService _service;
        private readonly IMapper _mapper;
        public OperationController(OperationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetOperaiontListAsync();
            if (result == null || !result.Any())
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var operation = await _service.GetAllAsync();
            var operationDto = _mapper.Map<List<OperationDto>>(operation.ToList());

            return View(CustomResponseDto<List<OperationDto>>.Success(200, operationDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var operation = await _service.GetAllAsync();
            var operationDto = _mapper.Map<List<OperationDto>>(operation.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(OperationDto operationDto)
        {

            var operation = await _service.AddAsync(_mapper.Map<Operation>(operationDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var operation = await _service.GetByIdAsync(id);

            return View(_mapper.Map<OperationDto>(operation));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(OperationDto operationDto)
        {

            await _service.UpdateAsync(_mapper.Map<Operation>(operationDto));

            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> ShowOperation(Guid id)
        {
            var operation = await _service.GetByIdAsync(id);

            return View(_mapper.Map<OperationDto>(operation));
        }


        [HttpPost]
        public async Task<IActionResult> ShowOperation(OperationDto operationDto)
        {

            await _service.UpdateAsync(_mapper.Map<Operation>(operationDto));

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteOperation(Guid id)
        {
            var operation = await _service.GetByIdAsync(id);

            return View(_mapper.Map<OperationDto>(operation));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteOperation(OperationDto operationDto)
        {

            await _service.UpdateAsync(_mapper.Map<Operation>(operationDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var operation = await _service.GetByIdAsync(id);
            operation.IsDeleted = true;
            await _service.UpdateAsync(operation);
            return RedirectToAction(nameof(Index));
        }
    }
}
