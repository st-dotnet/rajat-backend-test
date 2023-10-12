using Angular_CRUD_Test.Context;
using Angular_CRUD_Test.Models;

namespace Angular_CRUD_Test.Services
{

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
