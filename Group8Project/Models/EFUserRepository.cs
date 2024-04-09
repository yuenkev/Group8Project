// Author: Sebastian Villafane Ramos
// Description: Implements all the IUserRepository Interface methods

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

        public IQueryable<User> Users => context.Users;

        public User addUser(User us)
        {
            var existingUser = context.Users.FirstOrDefault(u => u.UserId == us.UserId);

            if (existingUser != null)
            {
                // Update existing user properties
                existingUser.Email = us.Email;
                existingUser.FName = us.FName;
                existingUser.LName = us.LName;
                existingUser.PNumber = us.PNumber;
                existingUser.Password = us.Password;

                // Save changes to the existing user
                context.SaveChanges();

                return existingUser;
            }
            else
            {
                // Add new user to the database
                context.Users.Add(us);
                context.SaveChanges();

                return us;
            }
        }
        public void removeUser(int id)
        {
            var userToRemove = context.Users.FirstOrDefault(u => u.UserId == id);

            if (userToRemove != null)
            {
                context.Users.Remove(userToRemove);
                context.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(u => u.UserId == id);
        }

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

        public User UpdateUser(User user)
        {
            return addUser(user);
        }

    }
}
