using MO_EDU.DTO;
using MO_EDU.Model;

namespace MO_EDU.Interfaces
{
    public interface IUserRepository
    {

        Task<User> Login(UserDTO user);
        ICollection<User> GetUsers();
        Task<User> GetUserById(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task SaveAsync();
    }
}
