using RentACar.Models.Base;

namespace RentACar.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity 
    {
        Task CreateAsync(TEntity entity);
        Task<bool> SaveAsync();
        TEntity FindById(object id);
        IAsyncEnumerable<TEntity> GetAll();

        void Delete(TEntity entity);

        //to be implemented
    }
}
