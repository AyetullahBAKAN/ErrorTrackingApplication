using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class RoleController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Role> _service;

        public RoleController(IMapper mapper, IService<Role> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var role = await _service.GetAllAsync();
            var roleDto = _mapper.Map<List<RoleDto>>(role.ToList());

            return CreateActionResult(CustomResponseDto<List<RoleDto>>.Success(200, roleDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var role = await _service.GetByIdAsync(id);
            var roleDto = _mapper.Map<RoleDto>(role);
            return CreateActionResult(CustomResponseDto<RoleDto>.Success(200, roleDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(RoleDto roleDtos)
        {
            var role = await _service.AddAsync(_mapper.Map<Role>(roleDtos));
            role.IsDeleted = false;
            var roleDto = _mapper.Map<RoleDto>(role);

            return CreateActionResult(CustomResponseDto<RoleDto>.Success(201, roleDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleDto roleDto)
        {
            await _service.UpdateAsync(_mapper.Map<Role>(roleDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var role = await _service.GetByIdAsync(id);

            role.IsDeleted = true;

            await _service.UpdateAsync(role);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
