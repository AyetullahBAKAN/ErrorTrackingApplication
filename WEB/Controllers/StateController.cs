using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class StateController : Controller
    {
        private readonly StateService _service;
        private readonly IMapper _mapper;
        public StateController(StateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetStateListAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var stateList = await _service.GetAllAsync();
            var stateListDto = _mapper.Map<List<StateDto>>(stateList.ToList());

            return View(CustomResponseDto<List<StateDto>>.Success(200, stateListDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var stateList = await _service.GetAllAsync();
            var stateListDto = _mapper.Map<List<StateDto>>(stateList.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(StateDto montageDto)
        {
            var montage = await _service.AddAsync(_mapper.Map<State>(montageDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var stateList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<StateDto>(stateList));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(StateDto montageDto)
        {

            await _service.UpdateAsync(_mapper.Map<State>(montageDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var stateList = await _service.GetByIdAsync(id);
            stateList.IsDeleted = true;
            await _service.UpdateAsync(stateList);
            return RedirectToAction(nameof(Index));
        }
    }
}
