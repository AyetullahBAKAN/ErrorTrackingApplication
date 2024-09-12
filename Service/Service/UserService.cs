using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class UserService : Service<User>
    {
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {

            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetUserListAsync()
        {
            try
            {
                var userList = await GetListAsync(x => !x.IsDeleted, null, "UserRoles,UserRoles.Role");

                var userListDto = _mapper.Map<List<UserDto>>(userList.ToList());
                return userListDto;
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama veya isteğe bağlı diğer işlemler yapılabilir
                return null;
            }
        }
    }
}
