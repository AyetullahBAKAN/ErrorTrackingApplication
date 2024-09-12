using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllerss
{
	[Authorize]

	public class MoneyTypeController : Controller
    {
        private readonly MoneyTypeService _service;
        private readonly IMapper _mapper;
        public MoneyTypeController(MoneyTypeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetMoneyTypeListAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }

        public async Task <IActionResult> All()
        {
            var moneyType= await _service.GetAllAsync();
            var moneyTypeDto=  _mapper.Map<List<MoneyTypeDto>>(moneyType.ToList());

            return View(CustomResponseDto<List<MoneyTypeDto>>.Success(200, moneyTypeDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var moneyType = await _service.GetAllAsync();
            var moneyTypeDto = _mapper.Map<List<MoneyTypeDto>>(moneyType.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(MoneyTypeDto moneyTypeDto)
        {
            var moneyType = await _service.AddAsync(_mapper.Map<MoneyType>(moneyTypeDto));
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        public async Task <IActionResult> Edit(Guid id)
        {
            var moneyType = await _service.GetByIdAsync(id);
            return View(_mapper.Map<MoneyTypeDto>(moneyType));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(MoneyTypeDto moneyTypeDto)
        {
            var moneyType = _service.UpdateAsync(_mapper.Map<MoneyType>(moneyTypeDto));
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ShowMoneyType(Guid id)
        {
            var moneyType = await _service.GetByIdAsync(id);
            return View(_mapper.Map<MoneyTypeDto>(moneyType));
        }

        [HttpPost]
        public async Task<IActionResult> ShowMoneyType(MoneyTypeDto moneyTypeDto)
        {
            var moneyType = _service.UpdateAsync(_mapper.Map<MoneyType>(moneyTypeDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteMoneyType(Guid id)
        {
            var moneyType = await _service.GetByIdAsync(id);
            return View(_mapper.Map<MoneyTypeDto>(moneyType));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteMoneyType(MoneyTypeDto moneyTypeDto)
        {
            var moneyType = _service.UpdateAsync(_mapper.Map<MoneyType>(moneyTypeDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var moneyType =  await _service.GetByIdAsync(id);
            moneyType.IsDeleted = true;
            await _service.UpdateAsync(moneyType);
            return RedirectToAction(nameof(Index));
        }
     }
}
