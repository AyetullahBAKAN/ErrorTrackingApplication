using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class RoleController : Controller
    {
        private readonly RoleService _service;
        private readonly IMapper _mapper;
        public RoleController(RoleService roleService, IMapper mapper)
        {
            _service = roleService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetRoleListAsync();
            if (result == null )
                return BadRequest();

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var roleList = await _service.GetAllAsync();
            var roleListDto = _mapper.Map<List<RoleDto>>(roleList.ToList());

            return View(CustomResponseDto<List<RoleDto>>.Success(200, roleListDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var roleList = await _service.GetAllAsync();
            var roleListDto = _mapper.Map<List<RoleDto>>(roleList.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(RoleDto roleListDto)
        {

            var roleList = await _service.AddAsync(_mapper.Map<Role>(roleListDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var roleList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<RoleDto>(roleList));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(RoleDto roleListDto)
        {


            await _service.UpdateAsync(_mapper.Map<Role>(roleListDto));

            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> ShowRole(Guid id)
        {
            var roleList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<RoleDto>(roleList));
        }


        [HttpPost]
        public async Task<IActionResult> ShowRole(RoleDto roleListDto)
        {
            await _service.UpdateAsync(_mapper.Map<Role>(roleListDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var roleList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<RoleDto>(roleList));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteRole(RoleDto roleListDto)
        {
            await _service.UpdateAsync(_mapper.Map<Role>(roleListDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var roleList = await _service.GetByIdAsync(id);
            roleList.IsDeleted = true;
            await _service.UpdateAsync(roleList);
            return RedirectToAction(nameof(Index));
        }
       
    }
}
