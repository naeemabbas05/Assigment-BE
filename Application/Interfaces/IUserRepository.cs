using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<PagedResponse<IReadOnlyList<User>>> GetPagedReponse(int pageNumber, int pageSize);
        Task<Response<User>> GetUsersById(int id);
        Task<Response<int>> AddUser(User user);
        Task<Response<int>> UpdateUser(User user);
        Task<Response<int>> DeleteUser(int id);
    }
}
