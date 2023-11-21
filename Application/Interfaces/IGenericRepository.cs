using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IGenericRepository<T> 
    {
        Task<T> GetById(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> expressions = null);
        Task<IReadOnlyList<T>> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> expressions = null);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IReadOnlyList<T>> GetPagedReponse(int PageNumber, int PageSize, Func<IQueryable<T>, IIncludableQueryable<T, object>> expressions = null);
        Task<int> GetCount();
    }
}
