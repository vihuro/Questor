using Microsoft.EntityFrameworkCore;
using Questor.Domain.Interface;
using Questor.Domain.Model;
using Questor.Persistence.Context;

namespace Questor.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteById(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<T>()
                         .Where(x => x.Id == id)
                         .FirstOrDefaultAsync(cancellationToken);

            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual async Task<T> GetById(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public virtual T Insert(T entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            entity.DateUpdated = DateTime.UtcNow;
            _context.Set<T>().Add(entity);
            return entity;
        }
    }
}
