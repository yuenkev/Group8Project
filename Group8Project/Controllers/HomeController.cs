using Group8Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Group8Project.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUpPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUpPage(User us)
        {

            // Check if the email already exists in the repository

            if (_userRepository.EmailExists(us.Email))
            {
                // Email is not unique, return a message to the frontend
                var errorMessage = "A user with this email address already exists. "
                                 + "Do you want to login?";
                // Kevin: - Fix this output w/ customer validation
                ModelState.AddModelError(nameof(us.Email), errorMessage);
            }

            // Validation
            if (ModelState.IsValid)
            {
                _userRepository.addUser(us);
                return View("LoginPage", us);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(User us)
        {

            //Partial Validation
            ModelState.Remove("FName");
            ModelState.Remove("LName");
            ModelState.Remove("PNumber");
            ModelState.Remove("RePassword");


            // Kevin: - Check if email exists + check if password is correct

            if (!_userRepository.VerifyEmail(us))
            {
                // Email does not exist, return a message to the frontend
                var errorMessageEmail = "The Email Does Not Exist...Please Try Again.";
                ModelState.AddModelError(nameof(us.Email), errorMessageEmail);
            }
            else if (!_userRepository.VerifyPassword(us))
            {
                // Pass is incorrect, return a message to the frontend
                var errorMessagePassword = "The Password is Incorrect...Please Try Again.";
                ModelState.AddModelError(nameof(us.Password), errorMessagePassword);
            }

            // 
            if (ModelState.IsValid)
            {
                // Redirect to dashboard if user is valid
                // Assign the user object to a ViewBag
                // Check if the email and password exist and match in the repository
                User authenticatedUser = _userRepository.Users.FirstOrDefault(x => x.Email == us.Email);
                ViewBag.User = authenticatedUser;

                return View("DashboardPage");
                //return View("DashboardPage", new DViewModel
                //{
                //    Trucks = _truckRepository.Trucks,
                //    Routes = _routeRepository.Routes
                //});
            }
            else
            {
                // If validation fails or login is unsuccessful, return login view with errors
                return View();
            }

        }


    }
}
