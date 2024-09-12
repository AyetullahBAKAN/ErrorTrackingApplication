using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ErrorCardController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<ErrorCard> _service;

        public ErrorCardController(IService<ErrorCard> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var errorCard = await _service.GetAllAsync();
            var errorCardDto = _mapper.Map<List<ErrorCardDto>>(errorCard.ToList());

            return CreateActionResult(CustomResponseDto<List<ErrorCardDto>>.Success(200, errorCardDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var errorCard = await _service.GetByIdAsync(id);
            var errorCardDto = _mapper.Map<ErrorCardDto>(errorCard);
            return CreateActionResult(CustomResponseDto<ErrorCardDto>.Success(200, errorCardDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ErrorCardDto errorCardDtos)
        {
            var errorCard = await _service.AddAsync(_mapper.Map<ErrorCard>(errorCardDtos));
            errorCard.IsDeleted = false;
            var errorCardDto = _mapper.Map<ErrorCardDto>(errorCard);

            return CreateActionResult(CustomResponseDto<ErrorCardDto>.Success(201, errorCardDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ErrorCardDto errorCardDto)
        {
            await _service.UpdateAsync(_mapper.Map<ErrorCard>(errorCardDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var errorCard = await _service.GetByIdAsync(id);

            errorCard.IsDeleted = true;

            await _service.UpdateAsync(errorCard);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
