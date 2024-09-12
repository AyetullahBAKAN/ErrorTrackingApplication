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

	public class ErrorTypeController : Controller
    {
        private readonly ErrorTypeService _service;
        private readonly UserService _userService;
        private readonly ErrorMainTitleService _errorMainTitleService;
        private readonly ErrorSubGroupService _errorSubGroupService;
        private readonly ErrorDetailGroupService _errorDetailGroupService;
        private readonly IMapper _mapper;

        public ErrorTypeController(ErrorTypeService errorTypeService, UserService userService, ErrorMainTitleService errorMainTitleService, ErrorSubGroupService errorSubGroupService, ErrorDetailGroupService errorDetailGroupService, IMapper mapper)
        {
            _service = errorTypeService;
            _userService = userService;
            _errorMainTitleService = errorMainTitleService;
            _errorSubGroupService = errorSubGroupService;
            _errorDetailGroupService = errorDetailGroupService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetErrorTypeListAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var errorTypeList = await _service.GetAllAsync();
            var errorTypeListDto = _mapper.Map<List<ErrorTypeDto>>(errorTypeList.ToList());

            return View(CustomResponseDto<List<ErrorTypeDto>>.Success(200, errorTypeListDto));
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var users = await _userService.GetAllAsync();
            var UsersDto = _mapper.Map<List<UserDto>>(users.Where(x => !x.IsDeleted));
            ViewBag.users = new SelectList(UsersDto, "Id", "UserName");

            var errorMainTitleList = await _errorMainTitleService.GetAllAsync();
            var errorMainTitleListDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainTitleList.Where(x => !x.IsDeleted));
            ViewBag.errorMainTitleList = new SelectList(errorMainTitleListDto, "Id", "ErrorMainTitleName");

            var errorSubGroup = await _errorSubGroupService.GetAllAsync();
            var errorSubGroupDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroup.Where(x => !x.IsDeleted));
            ViewBag.errorSubGroup = new SelectList(errorSubGroupDto, "Id", "ErrorSubGroupName");

            var errorDetailList = await _errorDetailGroupService.GetAllAsync();
            var errorDetailListDto = _mapper.Map<List<ErrorDetailGroupDto>>(errorDetailList.Where(x => !x.IsDeleted));
            ViewBag.errorDetailList = new SelectList(errorDetailListDto, "Id", "ErrorDetailGroupName");

           

            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(ErrorTypeDto errorTypeDto)
        {


            var errorTypeList = _mapper.Map<ErrorType>(errorTypeDto);
            await _service.AddAsync(errorTypeList);

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var errorType = await _service.GetByIdAsync(id);


            var users = await _userService.GetAllAsync();
            var UsersDto = _mapper.Map<List<UserDto>>(users.Where(x => !x.IsDeleted));
            ViewBag.users = new SelectList(UsersDto, "Id", "UserName", errorType.UserId);

            var errorMainTitleList = await _errorMainTitleService.GetAllAsync();
            var errorMainTitleListDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainTitleList.Where(x => !x.IsDeleted));
            ViewBag.errorMainTitleList = new SelectList(errorMainTitleListDto, "Id", "ErrorMainTitleName", errorType.ErrorMainTitleId);

            var errorSubGroup = await _errorSubGroupService.GetAllAsync();
            var errorSubGroupDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroup.Where(x => !x.IsDeleted));
            ViewBag.errorSubGroup = new SelectList(errorSubGroupDto, "Id", "ErrorSubGroupName", errorType.ErrorSubGroupId);

            var errorDetailList = await _errorDetailGroupService.GetAllAsync();
            var errorDetailListDto = _mapper.Map<List<ErrorDetailGroupDto>>(errorDetailList.Where(x => !x.IsDeleted));
            ViewBag.errorDetailList = new SelectList(errorDetailListDto, "Id", "ErrorDetailGroupName", errorType.ErrorDetailGroupId);

            return View(_mapper.Map<ErrorTypeDto>(errorType));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(ErrorTypeDto patternDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorType>(patternDto));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ShowErrorType(Guid id)
        {
            var errorType = await _service.GetByIdAsync(id);


            var users = await _userService.GetAllAsync();
            var UsersDto = _mapper.Map<List<UserDto>>(users.Where(x => !x.IsDeleted));
            ViewBag.users = new SelectList(UsersDto, "Id", "UserName", errorType.UserId);

            var errorMainTitleList = await _errorMainTitleService.GetAllAsync();
            var errorMainTitleListDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainTitleList.Where(x => !x.IsDeleted));
            ViewBag.errorMainTitleList = new SelectList(errorMainTitleListDto, "Id", "ErrorMainTitleName", errorType.ErrorMainTitleId);

            var errorSubGroup = await _errorSubGroupService.GetAllAsync();
            var errorSubGroupDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroup.Where(x => !x.IsDeleted));
            ViewBag.errorSubGroup = new SelectList(errorSubGroupDto, "Id", "ErrorSubGroupName", errorType.ErrorSubGroupId);

            var errorDetailList = await _errorDetailGroupService.GetAllAsync();
            var errorDetailListDto = _mapper.Map<List<ErrorDetailGroupDto>>(errorDetailList.Where(x => !x.IsDeleted));
            ViewBag.errorDetailList = new SelectList(errorDetailListDto, "Id", "ErrorDetailGroupName", errorType.ErrorDetailGroupId);

            return View(_mapper.Map<ErrorTypeDto>(errorType));
        }

        [HttpPost]
        public async Task<IActionResult> ShowErrorType(ErrorTypeDto patternDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorType>(patternDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> DeletErrorType(Guid id)
        {
            var errorType = await _service.GetByIdAsync(id);


            var users = await _userService.GetAllAsync();
            var UsersDto = _mapper.Map<List<UserDto>>(users.Where(x => !x.IsDeleted));
            ViewBag.users = new SelectList(UsersDto, "Id", "UserName", errorType.UserId);

            var errorMainTitleList = await _errorMainTitleService.GetAllAsync();
            var errorMainTitleListDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainTitleList.Where(x => !x.IsDeleted));
            ViewBag.errorMainTitleList = new SelectList(errorMainTitleListDto, "Id", "ErrorMainTitleName", errorType.ErrorMainTitleId);

            var errorSubGroup = await _errorSubGroupService.GetAllAsync();
            var errorSubGroupDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroup.Where(x => !x.IsDeleted));
            ViewBag.errorSubGroup = new SelectList(errorSubGroupDto, "Id", "ErrorSubGroupName", errorType.ErrorSubGroupId);

            var errorDetailList = await _errorDetailGroupService.GetAllAsync();
            var errorDetailListDto = _mapper.Map<List<ErrorDetailGroupDto>>(errorDetailList.Where(x => !x.IsDeleted));
            ViewBag.errorDetailList = new SelectList(errorDetailListDto, "Id", "ErrorDetailGroupName", errorType.ErrorDetailGroupId);

            return View(_mapper.Map<ErrorTypeDto>(errorType));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeletErrorType(ErrorTypeDto patternDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorType>(patternDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var errorTypeList = await _service.GetByIdAsync(id);
            errorTypeList.IsDeleted = true;
            await _service.UpdateAsync(errorTypeList);
            return RedirectToAction(nameof(Index));
        }
    }
}
