using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service.Service
{
    public class ErrorTypeService : Service<ErrorType>
    {
        private readonly IMapper _mapper;
        public ErrorTypeService(IGenericRepository<ErrorType> repository, IUnitOfWork unitOfWork,
                                IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<ErrorTypeDto>> GetErrorTypeListAsync()
        {
            try
            {
                var errorList = await GetListAsync(x => !x.IsDeleted
                     , null,
                    "User," +
                    "ErrorMainTitle," +
                    "ErrorSubGroup," +
                    "ErrorDetailGroup," 
                    );

                var errorListDto = _mapper.Map<List<ErrorTypeDto>>(errorList.ToList());
                return errorListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
