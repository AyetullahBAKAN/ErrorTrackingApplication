using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class FieldService : Service<Field>
    {
        private readonly IMapper _mapper;
        public FieldService(IGenericRepository<Field> repository, IUnitOfWork unitOfWork, 
                            IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<FieldDto>> GetFieldListAsync()
        {
            try
            {
                var fieldList = await GetListAsync(x => !x.IsDeleted);
                var fieldListDto = _mapper.Map<List<FieldDto>>(fieldList.ToList());
                return fieldListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
