using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RootAnalysisController : CustomBaseController
    {
        private readonly IService<RootAnalysis> _service;
        private readonly IMapper _mapper;

        public RootAnalysisController(IService<RootAnalysis> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var root = await _service.GetAllAsync();
            var rootDto = _mapper.Map<List<RootAnalysisDto>>(root.ToList());

            return CreateActionResult(CustomResponseDto<List<RootAnalysisDto>>.Success(200, rootDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var root = await _service.GetByIdAsync(id);
            var rootDto = _mapper.Map<RootAnalysisDto>(root);
            return CreateActionResult(CustomResponseDto<RootAnalysisDto>.Success(200, rootDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(RootAnalysisDto rootAnalysisDto)
        {
            var root = await _service.AddAsync(_mapper.Map<RootAnalysis>(rootAnalysisDto));
            root.IsDeleted = false;
            var rootDto = _mapper.Map<RootAnalysisDto>(root);

            return CreateActionResult(CustomResponseDto<RootAnalysisDto>.Success(201, rootDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(RootAnalysisDto rootAnalysisDto)
        {
            await _service.UpdateAsync(_mapper.Map<RootAnalysis>(rootAnalysisDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var root = await _service.GetByIdAsync(id);

            root.IsDeleted = true;

            await _service.UpdateAsync(root);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
