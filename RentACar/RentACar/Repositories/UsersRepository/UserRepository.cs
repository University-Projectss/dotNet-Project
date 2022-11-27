using RentACar.DataBase;
using RentACar.Models;
using RentACar.Repositories.GenericRepository;

namespace RentACar.Repositories.UsersRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context) { }

        public User FindByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email == email);
        }
    }
}
