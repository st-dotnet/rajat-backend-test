using Angular_CRUD_Test.Models;

namespace Angular_CRUD_Test.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
