using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ProjectController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Project> _service;

        public ProjectController(IMapper mapper,  IService<Project> service)
        {

            _mapper = mapper;
            _service = service;
        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetProjectWithCustomers()
        //{

        //    return CreateActionResult(await _service.GetProjectWithCustomers());
        //}


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var projects = await _service.GetAllAsync();
            var projectDto = _mapper.Map<List<ProjectDto>>(projects.ToList());

            return CreateActionResult(CustomResponseDto<List<ProjectDto>>.Success(200, projectDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var projects = await _service.GetByIdAsync(id);
            var projectDto = _mapper.Map<ProjectDto>(projects);
            return CreateActionResult(CustomResponseDto<ProjectDto>.Success(200, projectDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProjectDto projectDto)
        {
            var projets = await _service.AddAsync(_mapper.Map<Project>(projectDto));
            projets.IsDeleted = false;
            var projetsDto = _mapper.Map<ProjectDto>(projets);

            return CreateActionResult(CustomResponseDto<ProjectDto>.Success(201, projetsDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProjectDto projectDto)
        {
            await _service.UpdateAsync(_mapper.Map<Project>(projectDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var project = await _service.GetByIdAsync(id);

            project.IsDeleted = true;

            await _service.UpdateAsync(project);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
