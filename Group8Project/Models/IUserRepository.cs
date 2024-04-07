namespace Group8Project.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        bool EmailExists(string email);
        bool VerifyEmail(User user);
        public bool VerifyPassword(User user);
        public User addUser(User us);
        public void removeUser(string email);
        User UpdateUser(User user);
        User GetUserByEmail(string email);



    }
}
