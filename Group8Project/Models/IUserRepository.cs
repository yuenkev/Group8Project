// Author: Sebastian Villafane Ramos
// Description: Interface for the User Repository

namespace Group8Project.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        bool EmailExists(string email);
        bool VerifyEmail(User user);
        public bool VerifyPassword(User user);
        public User addUser(User us);
        public void removeUser(int id);
        User UpdateUser(User user);
        User GetUserById(int id);



    }
}
