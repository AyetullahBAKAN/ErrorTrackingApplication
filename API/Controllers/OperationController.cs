using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class OperationController : CustomBaseController
    {
        private readonly IService<Operation> _operationService;
        private readonly IMapper _mapper;

        public OperationController(IMapper mapper, IService<Operation> operationService)
        {
            _mapper = mapper;
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var operation = await _operationService.GetAllAsync();
            var operationDto = _mapper.Map<List<OperationDto>>(operation.ToList());
            return CreateActionResult(CustomResponseDto<List<OperationDto>>.Success(200, operationDto));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var operation = await _operationService.GetByIdAsync(id);
            var operationDto = _mapper.Map<OperationDto>(operation);
            return CreateActionResult(CustomResponseDto<OperationDto>.Success(200, operationDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(OperationDto operationDto)
        {
            var operations = await _operationService.AddAsync(_mapper.Map<Operation>(operationDto));
            operations.IsDeleted = false;
            var operationDtos = _mapper.Map<OperationDto>(operations);

            return CreateActionResult(CustomResponseDto<OperationDto>.Success(201, operationDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(OperationDto operationDto)
        {
            await _operationService.UpdateAsync(_mapper.Map<Operation>(operationDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var operation = await _operationService.GetByIdAsync(id);
            operation.IsDeleted = true;

            await _operationService.UpdateAsync(operation);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}

