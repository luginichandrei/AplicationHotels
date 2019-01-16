using Models;

namespace BusinessLayer.Interfaces
{
    public interface IUserService : IService<User>
    {
        User FindByName(string name);

        User Authenticate(string username, string password);
    }
}