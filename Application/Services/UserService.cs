using Application.Interfaces;
using Application.Services.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService: IUserService
    {

        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedResponse<IReadOnlyList<User>>> GetAllUsers(int pageNumber, int pageSize)
        {
            return await _userRepository.GetPagedReponse( pageNumber,  pageSize);
        }

        public async Task<Response<User>> GetUsersById(int id)
        {
            return await _userRepository.GetUsersById(id);
        }

        public async Task<Response<int>> AddUser(User user)
        {
            return await _userRepository.AddUser(user);
        }
        public async Task<Response<int>> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }
        public async Task<Response<int>> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}
