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
    public class CostController : Controller
    {
        private readonly CostService _service;
        private readonly FieldService _fieldService;
        private readonly MoneyTypeService _moneyTypeService;
        private readonly IMapper _mapper;
        public CostController(CostService service, FieldService fieldService, MoneyTypeService moneyTypeService, IMapper mapper)
        {
            _service = service;
            _fieldService = fieldService;
            _moneyTypeService = moneyTypeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetCostListAsync();
            if (result == null )
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var cost = await _service.GetAllAsync();
            var costDto = _mapper.Map<List<CostDto>>(cost.ToList());

            return View(CustomResponseDto<List<CostDto>>.Success(200, costDto));
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create()
        {
            var field = await _fieldService.GetAllAsync();
            var fieldDto = _mapper.Map<List<FieldDto>>(field.Where(x => !x.IsDeleted));
            ViewBag.field = new SelectList(fieldDto, "Id", "FieldName");

            var moneyTypes = await _moneyTypeService.GetAllAsync();
            var moneyTypesDto = _mapper.Map<List<MoneyTypeDto>>(moneyTypes.Where(x => !x.IsDeleted));
            ViewBag.moneyTypes = new SelectList(moneyTypesDto, "MoneyTypeId", "TypeOfMoney");

            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(CostDto costDto)
        {

            var cost = await _service.AddAsync(_mapper.Map<Cost>(costDto));
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var cost = await _service.GetByIdAsync(id);

            var field = await _fieldService.GetAllAsync();
            var fieldDto = _mapper.Map<List<FieldDto>>(field.Where(x => !x.IsDeleted));
            ViewBag.field = new SelectList(fieldDto, "Id", "FieldName", cost.FieldId);

            var moneyTypes = await _moneyTypeService.GetAllAsync();
            var moneyTypesDto = _mapper.Map<List<MoneyTypeDto>>(moneyTypes.Where(x => !x.IsDeleted));
            ViewBag.moneyTypes = new SelectList(moneyTypesDto, "MoneyTypeId", "TypeOfMoney", cost.MoneyTypeId);

            return View(_mapper.Map<CostDto>(cost));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(CostDto costDto)
        {

            await _service.UpdateAsync(_mapper.Map<Cost>(costDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> DeleteCost(Guid id)
        {
            var cost = await _service.GetByIdAsync(id);

            var field = await _fieldService.GetAllAsync();
            var fieldDto = _mapper.Map<List<FieldDto>>(field.Where(x => !x.IsDeleted));
            ViewBag.field = new SelectList(fieldDto, "Id", "FieldName", cost.FieldId);

            var moneyTypes = await _moneyTypeService.GetAllAsync();
            var moneyTypesDto = _mapper.Map<List<MoneyTypeDto>>(moneyTypes.Where(x => !x.IsDeleted));
            ViewBag.moneyTypes = new SelectList(moneyTypesDto, "MoneyTypeId", "TypeOfMoney", cost.MoneyTypeId);

            return View(_mapper.Map<CostDto>(cost));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteCost(CostDto costDto)
        {

            await _service.UpdateAsync(_mapper.Map<Cost>(costDto));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ViewCost(Guid id)
        {
            var cost = await _service.GetByIdAsync(id);

            var field = await _fieldService.GetAllAsync();
            var fieldDto = _mapper.Map<List<FieldDto>>(field.Where(x => !x.IsDeleted));
            ViewBag.field = new SelectList(fieldDto, "Id", "FieldName", cost.FieldId);

            var moneyTypes = await _moneyTypeService.GetAllAsync();
            var moneyTypesDto = _mapper.Map<List<MoneyTypeDto>>(moneyTypes.Where(x => !x.IsDeleted));
            ViewBag.moneyTypes = new SelectList(moneyTypesDto, "MoneyTypeId", "TypeOfMoney", cost.MoneyTypeId);

            return View(_mapper.Map<CostDto>(cost));
        }

        [HttpPost]
        public async Task<IActionResult> ViewCost(CostDto costDto)
        {

            await _service.UpdateAsync(_mapper.Map<Cost>(costDto));

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var cost = await _service.GetByIdAsync(id);
            cost.IsDeleted = true;
            await _service.UpdateAsync(cost);
            return RedirectToAction(nameof(Index));
        }


    }
}
