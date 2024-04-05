namespace Group8Project.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        bool EmailExists(string email);
        bool VerifyEmail(User user);
        public bool VerifyPassword(User user);
        public void addUser(User us);


    }
}
