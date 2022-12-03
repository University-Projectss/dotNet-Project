using RentACar.Models.Base;

namespace RentACar.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity 
    {
        Task CreateAsync(TEntity entity);
        Task<bool> SaveAsync();
        Task<TEntity> FindByIdAsync(object id);
        IAsyncEnumerable<TEntity> GetAll();

        Task Delete(TEntity entity);

        //to be implemented
    }
}
