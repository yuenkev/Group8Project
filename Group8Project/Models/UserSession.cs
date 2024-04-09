// Author: Sebastian Villafane Ramos
// Description: Handles current logged user

namespace Group8Project.Models
{
    public class UserSession
    {
        //Class holds current user logged in to limit accessibility to pages, with one user object and appropriate getter/setter

        private static User? _currentUser;

        public static void setCurrentUser(User user)
        {
            _currentUser = user;
        }

        public static User getCurrentUser() => _currentUser;

        public static String getFullName() => _currentUser.FName + " " + _currentUser.LName;
    }
}
