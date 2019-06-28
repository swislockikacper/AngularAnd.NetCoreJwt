using Backend.Models;

namespace Backend.Interfaces
{
    public interface IAuthService
    {
        TokenModel Login(User user);
    }
}