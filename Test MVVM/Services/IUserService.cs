using Test_MVVM.Models;

namespace Test_MVVM.Services
{
    public interface IUserService
    {
        bool AddUser(User user);
        List<User> GetUsers();
        event Action<User> UserAdded;
    }
}