using Microsoft.EntityFrameworkCore;
using MO_EDU.Data;
using MO_EDU.DTO;
using MO_EDU.Interfaces;
using MO_EDU.Model;

namespace MO_EDU.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) 
        {
            _context = context;
        }
        public ICollection<User> GetUsers() 
        {
            return _context.Users.OrderBy(p=>p.UserID).ToList();
        }

        public async Task<User> Login(UserDTO user) =>
            await _context.Users.FirstOrDefaultAsync<User>(f => f.userName == user.userName && f.password == user.password);


        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

       
    }
}
