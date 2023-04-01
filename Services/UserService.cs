using Lab11_KazanovAlexandr.Data;
using Lab11_KazanovAlexandr.Models;

namespace Lab11_KazanovAlexandr.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _context;
        public UserService(UserContext context) 
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public void UpdateUser(User user, AddUserViewModel updateUser)
        {
            user.Email = updateUser.Email;
            user.Name = updateUser.Name;
            user.Password = updateUser.Password;
            _context.SaveChanges();
        }
    }
}
