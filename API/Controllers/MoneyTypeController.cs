using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class MoneyTypeController : CustomBaseController
    {
        private readonly IService<MoneyType> _service;
        private readonly IMapper _mapper;

        public MoneyTypeController(IService<MoneyType> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var moneyType = await _service.GetAllAsync();
            var moneytypeDto = _mapper.Map<List<MoneyTypeDto>>(moneyType.ToList());

            return CreateActionResult(CustomResponseDto<List<MoneyTypeDto>>.Success(200, moneytypeDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var moneyType = await _service.GetByIdAsync(id);
            var moneytypeDto = _mapper.Map<MoneyTypeDto>(moneyType);
            return CreateActionResult(CustomResponseDto<MoneyTypeDto>.Success(200, moneytypeDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(MoneyTypeDto moneytypeDtos)
        {
            var moneyType = await _service.AddAsync(_mapper.Map<MoneyType>(moneytypeDtos));
            //moneyType.IsDeleted = false;
            var moneytypeDto = _mapper.Map<MoneyTypeDto>(moneyType);

            return CreateActionResult(CustomResponseDto<MoneyTypeDto>.Success(201, moneytypeDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(MoneyTypeDto moneytypeDto)
        {
            await _service.UpdateAsync(_mapper.Map<MoneyType>(moneytypeDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var moneyType = await _service.GetByIdAsync(id);

            //moneyType.IsDeleted = true;

            await _service.UpdateAsync(moneyType);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
