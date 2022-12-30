using RentACar.Models;
using RentACar.Repositories.GenericRepository;

namespace RentACar.Repositories.UsersRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByEmail(string email);

        IEnumerable<User> GetEmployees();
    }
}
