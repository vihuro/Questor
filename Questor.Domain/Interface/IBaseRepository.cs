using Questor.Domain.Model;

namespace Questor.Domain.Interface
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T> GetById(int id, CancellationToken cancellationToken);
        Task<List<T>> GetAll(CancellationToken cancellationToken);
        T Insert(T entity);
        Task DeleteById(int id, CancellationToken cancellationToken);
    }
}
