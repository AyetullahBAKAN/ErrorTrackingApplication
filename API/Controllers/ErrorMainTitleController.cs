using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ErrorMainTitleController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<ErrorMainTitle> _service;

        public ErrorMainTitleController(IMapper mapper, IService<ErrorMainTitle> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var errorMainTitle = await _service.GetAllAsync();
            var errorMainTitleDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainTitle.ToList());

            return CreateActionResult(CustomResponseDto<List<ErrorMainTitleDto>>.Success(200, errorMainTitleDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var errorMainTitle = await _service.GetByIdAsync(id);
            var errorMainTitleDto = _mapper.Map<ErrorMainTitleDto>(errorMainTitle);
            return CreateActionResult(CustomResponseDto<ErrorMainTitleDto>.Success(200, errorMainTitleDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ErrorMainTitleDto errorMainTitleDtos)
        {
            var errorMainTitle = await _service.AddAsync(_mapper.Map<ErrorMainTitle>(errorMainTitleDtos));
            errorMainTitle.IsDeleted = false;
            var errorMainTitleDto = _mapper.Map<ErrorMainTitleDto>(errorMainTitle);

            return CreateActionResult(CustomResponseDto<ErrorMainTitleDto>.Success(201, errorMainTitleDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ErrorMainTitleDto errorMainTitleDtos)
        {
            await _service.UpdateAsync(_mapper.Map<ErrorMainTitle>(errorMainTitleDtos));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var errorMainTitle = await _service.GetByIdAsync(id);

            errorMainTitle.IsDeleted = true;

            await _service.UpdateAsync(errorMainTitle);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
