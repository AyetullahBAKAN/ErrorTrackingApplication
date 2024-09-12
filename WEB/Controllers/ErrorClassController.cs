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

	public class ErrorClassController : Controller
    {
        private readonly ErrorClassService _service;
        private readonly ErrorMainTitleService _errorMainTitleService;
        private readonly ErrorSubGroupService _errorSubGroupService;
        private readonly IMapper _mapper;
        public ErrorClassController(ErrorClassService service, ErrorMainTitleService mainTitleService, 
            ErrorSubGroupService subGroupService, IMapper mapper)
        {
            _service = service;
            _errorMainTitleService = mainTitleService;
            _errorSubGroupService = subGroupService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetErrorClassListAsync();
            if (result == null )
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var errorClassList = await _service.GetAllAsync();
            var errorClassListDto = _mapper.Map<List<ErrorClassDto>>(errorClassList.ToList());

            return View(CustomResponseDto<List<ErrorClassDto>>.Success(200, errorClassListDto));
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create()
        {
            var errorMainTitleList = await _errorMainTitleService.GetAllAsync();
            var errorMainTitleListDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainTitleList.Where(x => !x.IsDeleted));
            ViewBag.errorMainTitleList = new SelectList(errorMainTitleListDto, "Id", "ErrorMainTitleName");

            var errorSubGroupList = await _errorSubGroupService.GetAllAsync();
            var errorSubGroupListDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroupList.Where(x => !x.IsDeleted));
            ViewBag.errorSubGroupList = new SelectList(errorSubGroupListDto, "Id", "ErrorSubGroupName");


            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(ErrorClassDto errorClassDto)
        {

            var errorClass = await _service.AddAsync(_mapper.Map<ErrorClass>(errorClassDto));
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var errorClassList = await _service.GetByIdAsync(id);

            var errorMainTitleList = await _errorMainTitleService.GetAllAsync();
            var errorMainTitleListDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainTitleList.Where(x => !x.IsDeleted));
            ViewBag.errorMainTitleList = new SelectList(errorMainTitleListDto, "Id", "ErrorMainTitleName", errorClassList.ErrorMainTitleId);

            var errorSubGroupList = await _errorSubGroupService.GetAllAsync();
            var errorSubGroupListDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroupList.Where(x => !x.IsDeleted));
            ViewBag.errorSubGroupList = new SelectList(errorSubGroupListDto, "Id", "ErrorSubGroupName", errorClassList.ErrorSubGroupId);

            return View(_mapper.Map<ErrorClassDto>(errorClassList));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(ErrorClassDto errorClassDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorClass>(errorClassDto));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ShowErrorClass(Guid id)
        {
            var errorClassList = await _service.GetByIdAsync(id);

            var errorMainTitleList = await _errorMainTitleService.GetAllAsync();
            var errorMainTitleListDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainTitleList.Where(x => !x.IsDeleted));
            ViewBag.errorMainTitleList = new SelectList(errorMainTitleListDto, "Id", "ErrorMainTitleName", errorClassList.ErrorMainTitleId);

            var errorSubGroupList = await _errorSubGroupService.GetAllAsync();
            var errorSubGroupListDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroupList.Where(x => !x.IsDeleted));
            ViewBag.errorSubGroupList = new SelectList(errorSubGroupListDto, "Id", "ErrorSubGroupName", errorClassList.ErrorSubGroupId);

            return View(_mapper.Map<ErrorClassDto>(errorClassList));
        }

        [HttpPost]
        public async Task<IActionResult> ShowErrorClass(ErrorClassDto errorClassDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorClass>(errorClassDto));

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> DeleteErrorClass(Guid id)
        {
            var errorClassList = await _service.GetByIdAsync(id);

            var errorMainTitleList = await _errorMainTitleService.GetAllAsync();
            var errorMainTitleListDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainTitleList.Where(x => !x.IsDeleted));
            ViewBag.errorMainTitleList = new SelectList(errorMainTitleListDto, "Id", "ErrorMainTitleName", errorClassList.ErrorMainTitleId);

            var errorSubGroupList = await _errorSubGroupService.GetAllAsync();
            var errorSubGroupListDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroupList.Where(x => !x.IsDeleted));
            ViewBag.errorSubGroupList = new SelectList(errorSubGroupListDto, "Id", "ErrorSubGroupName", errorClassList.ErrorSubGroupId);

            return View(_mapper.Map<ErrorClassDto>(errorClassList));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteErrorClass(ErrorClassDto errorClassDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorClass>(errorClassDto));

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var errorClassList = await _service.GetByIdAsync(id);
            errorClassList.IsDeleted = true;
            await _service.UpdateAsync(errorClassList);
            return RedirectToAction(nameof(Index));
        }
    }
}
