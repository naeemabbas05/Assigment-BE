using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDBContext _dbContext;

        public GenericRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetById(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> expressions = null)
        {

            var result = _dbContext.Set<T>().AsNoTracking().AsQueryable();
            if (expressions != null)
            {
                result = expressions(result);
            }
            return await result.Where(x => x.IsActive == StatusEnum.Active).FirstOrDefaultAsync(x => x.IsActive == StatusEnum.Active && x.Id == id);

        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> expressions = null)
        {


            var result = _dbContext.Set<T>().AsNoTracking().AsQueryable();
            if (expressions != null)
            {
                result = expressions(result);
            }
            return await result.Where(x => x.IsActive == StatusEnum.Active).ToListAsync();
            

        }

        public async Task<IReadOnlyList<T>> GetPagedReponse(int PageNumber, int PageSize, Func<IQueryable<T>, IIncludableQueryable<T, object>> expressions = null)
        {
            var result = _dbContext.Set<T>().AsNoTracking().AsQueryable();
            if (expressions != null)
            {
                result = expressions(result);
            }
            return await result
                   .Skip((PageNumber - 1) * PageSize)
                   .Take(PageSize)
                   .Where(x => x.IsActive == StatusEnum.Active)
                   .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _dbContext
                 .Set<T>()
                 .CountAsync(x => x.IsActive == StatusEnum.Active);
        }

    }
}
