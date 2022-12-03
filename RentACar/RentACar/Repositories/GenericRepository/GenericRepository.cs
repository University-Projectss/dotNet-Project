using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RentACar.DataBase;
using RentACar.Models.Base;

namespace RentACar.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DataBaseContext _dataBaseContext;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
            _table = _dataBaseContext.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _dataBaseContext.SaveChangesAsync() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ceva nu e bine");
                Console.WriteLine(ex);
            }

            return false;
        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public async IAsyncEnumerable<TEntity> GetAll()
        {
            var res = await _table.AsNoTracking().ToListAsync();
            foreach(var i in res)
            {
                yield return i;
            }
        }

        public async Task Delete(TEntity entity)
        {
             _table.Remove(entity);
        }

        //to be implemented
    }
}
