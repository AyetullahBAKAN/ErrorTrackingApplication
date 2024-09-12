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

	public class ErrorDetailGroupController : Controller
    {
        private readonly ErrorDetailGroupService _service;
        private readonly IMapper _mapper;
        public ErrorDetailGroupController(ErrorDetailGroupService errorDetailGroupService, IMapper mapper)
        {
            _service = errorDetailGroupService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetErrorDetailGroupsAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var errorDetailGroupList = await _service.GetAllAsync();
            var errorDetailGroupListDto = _mapper.Map<List<ErrorDetailGroupDto>>(errorDetailGroupList.ToList());

            return View(CustomResponseDto<List<ErrorDetailGroupDto>>.Success(200, errorDetailGroupListDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var errorDetailGroupList = await _service.GetAllAsync();
            var errorDetailGroupListDto = _mapper.Map<List<ErrorDetailGroupDto>>(errorDetailGroupList.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(ErrorDetailGroupDto errorDetailGroupListDto)
        {

            var errorDetailGroupList = await _service.AddAsync(_mapper.Map<ErrorDetailGroup>(errorDetailGroupListDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var errorDetailGroupList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorDetailGroupDto>(errorDetailGroupList));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(ErrorDetailGroupDto errorDetailGroupListDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorDetailGroup>(errorDetailGroupListDto));

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ShowErrorDetail(Guid id)
        {
            var errorDetailGroupList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorDetailGroupDto>(errorDetailGroupList));
        }


        [HttpPost]
        public async Task<IActionResult> ShowErrorDetail(ErrorDetailGroupDto errorDetailGroupListDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorDetailGroup>(errorDetailGroupListDto));

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteErrorDetail(Guid id)
        {
            var errorDetailGroupList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorDetailGroupDto>(errorDetailGroupList));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteErrorDetail(ErrorDetailGroupDto errorDetailGroupListDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorDetailGroup>(errorDetailGroupListDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var errorDetailGroupList = await _service.GetByIdAsync(id);
            errorDetailGroupList.IsDeleted = true;
            await _service.UpdateAsync(errorDetailGroupList);
            return RedirectToAction(nameof(Index));
        }
    }

}
