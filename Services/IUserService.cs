using Lab11_KazanovAlexandr.Models;

namespace Lab11_KazanovAlexandr.Services
{
    public interface IUserService
    {
        public void AddUser(User user);
        public IEnumerable<User> GetAllUsers();
        public User GetUser(int id);
        public void UpdateUser(User user, AddUserViewModel updateUser);
        public void DeleteUser(User user);
    }
}
