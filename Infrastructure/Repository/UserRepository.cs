using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Application.Exceptions;
using Application.Wrappers;
using Domain.Enums;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public IGenericRepository<User> _userRepository;
        public IGenericRepository<UserSkillSets> _userSkillSets;

        public UserRepository(IGenericRepository<User> userRepository, IGenericRepository<UserSkillSets> userSkillSets) 
        {
            _userRepository = userRepository;
            _userSkillSets = userSkillSets;

        }

        public async Task<PagedResponse<IReadOnlyList<User>>> GetPagedReponse(int pageNumber,int pageSize)
        {
            var users = await _userRepository.GetPagedReponse(pageNumber,pageSize , q=>q.Include(x=>x.UserSkillSets).ThenInclude(x=>x.SkillSets));
            var usersCount = await _userRepository.GetCount();
            return new PagedResponse<IReadOnlyList<User>>(users,pageNumber,pageSize, usersCount, null, null);
        }

        public async Task<Response<User>> GetUsersById(int id)
        {
            var user = await _userRepository.GetById(id, q=>q.Include(x=>x.UserSkillSets).ThenInclude(x=>x.SkillSets));
            return new Response<User>(user);
        }

        public async Task<Response<int>> AddUser(User user)
        {
            await _userRepository.Add(user);
            return new Response<int>(user.Id);
        }
        public async Task<Response<int>> UpdateUser(User user)
        {
            var userRequest = await _userRepository.GetById(user.Id);
        
            if (userRequest == null)
            {
                throw new ApiException($"user Not Found.");
            }

            await _userRepository.Update(user);
            return new Response<int>(user.Id);

        }

        public async Task<Response<int>> DeleteUser(int id)
        {
            var userRequest = await _userRepository.GetById(id);
      
            if (userRequest == null)
            {
                throw new ApiException($"user Not Found.");
            }
            userRequest.IsActive = StatusEnum.Deactive;
           
            await _userRepository.Update(userRequest);
            return new Response<int>(id);
        }
    }
}
