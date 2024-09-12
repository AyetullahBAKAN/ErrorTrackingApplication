using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class ErrorSubGroupController : Controller
    {

        private readonly ErrorSubGroupService _service;
        private readonly IMapper _mapper;

        public ErrorSubGroupController(ErrorSubGroupService errorSubGroupService, IMapper mapper)
        {
            _service = errorSubGroupService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetErrorSubGroupsAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var errorSubGroupList = await _service.GetAllAsync();
            var errorSubGroupListDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroupList.ToList());

            return View(CustomResponseDto<List<ErrorSubGroupDto>>.Success(200, errorSubGroupListDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var errorSubGroupList = await _service.GetAllAsync();
            var errorSubGroupListDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroupList.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ErrorSubGroupDto errorSubGroupListDto)
        {

            var errorSubGroupList = await _service.AddAsync(_mapper.Map<ErrorSubGroup>(errorSubGroupListDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var errorSubGroupList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorSubGroupDto>(errorSubGroupList));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(ErrorSubGroupDto errorSubGroupListDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorSubGroup>(errorSubGroupListDto));

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> ShowErrorSubGroup(Guid id)
        {
            var errorSubGroupList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorSubGroupDto>(errorSubGroupList));
        }


        [HttpPost]
        public async Task<IActionResult> ShowErrorSubGroup(ErrorSubGroupDto errorSubGroupListDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorSubGroup>(errorSubGroupListDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteErrorSubGroup(Guid id)
        {
            var errorSubGroupList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorSubGroupDto>(errorSubGroupList));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteErrorSubGroup(ErrorSubGroupDto errorSubGroupListDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorSubGroup>(errorSubGroupListDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var errorSubGroupList = await _service.GetByIdAsync(id);
            errorSubGroupList.IsDeleted = true;
            await _service.UpdateAsync(errorSubGroupList);
            return RedirectToAction(nameof(Index));
        }
    }
}
