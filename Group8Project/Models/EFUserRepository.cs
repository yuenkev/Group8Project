using Group8Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Group8Projects.Models
{
    public class EFUserRepository : IUserRepository
    {
        private MBS_DBContext context;
        public EFUserRepository(MBS_DBContext ctx)
        {
            context = ctx;
        }

        public void addUser(User us)
        {
            context.Users.Add(us);
            context.SaveChanges();
        }
        public IQueryable<User> Users => context.Users;

        public bool EmailExists(string email)
        {
            return context.Users.Any(u => u.Email == email);
        }

        public bool VerifyEmail(User user)
        {
            //check if email exists and return true if it does
            bool validEmail = context.Users.Any(u => u.Email == user.Email);
            return validEmail;
        }

        public bool VerifyPassword(User user)
        {
            // loop thru list to grab the valid email and valid password associated with it
            bool validPassword = context.Users.Any(u => u.Email == user.Email && u.Password == user.Password);

            return validPassword;
        }

    }
}
