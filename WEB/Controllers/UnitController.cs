using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class UnitController : Controller
    {
        private readonly UnitService _service;
        private readonly IMapper _mapper;
        public UnitController(UnitService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetUnitListAsync();
            if (result == null )
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var unitList = await _service.GetAllAsync();
            var unitListDto = _mapper.Map<List<UnitDto>>(unitList.ToList());

            return View(CustomResponseDto<List<UnitDto>>.Success(200, unitListDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var unitList = await _service.GetAllAsync();
            var unitListDto = _mapper.Map<List<UnitDto>>(unitList.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(UnitDto montageDto)
        {
            var unitList = await _service.AddAsync(_mapper.Map<Unit>(montageDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var unitList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<UnitDto>(unitList));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(UnitDto montageDto)
        {

            await _service.UpdateAsync(_mapper.Map<Unit>(montageDto));

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ShowUnit(Guid id)
        {
            var unitList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<UnitDto>(unitList));
        }


        [HttpPost]
        public async Task<IActionResult> ShowUnit(UnitDto montageDto)
        {

            await _service.UpdateAsync(_mapper.Map<Unit>(montageDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteUnit(Guid id)
        {
            var unitList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<UnitDto>(unitList));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteUnit(UnitDto montageDto)
        {

            await _service.UpdateAsync(_mapper.Map<Unit>(montageDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var unitList = await _service.GetByIdAsync(id);
            unitList.IsDeleted = true;
            await _service.UpdateAsync(unitList);
            return RedirectToAction(nameof(Index));
        }
    }
}
