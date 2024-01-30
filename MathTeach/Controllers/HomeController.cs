using DataLayer;
using DataLayer.Entities;
using MathTeach.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace MathTeach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public MathDbContext _context;
        private readonly ILogger<HomeController> _helper;

        public HomeController(ILogger<HomeController> logger, MathDbContext context, ILogger<HomeController> helper)
        {
            _logger = logger;
            _context = context;
            _helper = helper;
        }

        public IActionResult Index()
        {
            return View("StartPage");

        }

        public IActionResult Authorize(StartModel model)
        {
            var user = _context.Users.FirstOrDefault(x=> x.Login.Equals(model.Login));
            if (user == null)
            {
                model.Result = "Такого пользователя не существует";
                return View("StartPage", model);
            }
            if (!user.Password.Equals(model.Password))
            {
                model.Result = "Вы ввели неверный пароль";
                return View("StartPage", model);
            }
            if (user.RoleId == 1)
            {
                return RedirectToAction("StudentPage", user);
            }
            if (user.RoleId == 2)
            {
                return RedirectToAction("TeachPage", user);
            }
            return View();
        }

        public IActionResult TeachPage(User user) 
        {
            TeachModel model = new TeachModel() { Name = user.FIO };
            return View("TeacherView", model);
        }

        public IActionResult StudentPage(User user) 
        {
            StudentModel model = new StudentModel() { Name = user.FIO};
            return View("StudentView", model);
        }

        public IActionResult NewUser()
        {
            return View("Register");
        }

        public IActionResult Register(RegisterModel model)
        {
            User user = new User();
            //model.Password = PasswordSalt.CalculateHash(model.Password);
            if (model.RoleId == "Студент")
            {
                user = new User()
                {
                    FIO = model.FIO,
                    Login = model.Login,
                    Password = model.Password,
                    RoleId = 1
                };
            }
            if (model.RoleId == "Преподаватель")
            {
                user = new User()
                {
                    FIO = model.FIO,
                    Login = model.Login,
                    Password = model.Password,
                    RoleId = 2
                };
            }
            _context.Users.Add(user);
            _context.SaveChanges();

            return View("StartPage");

        }

        public IActionResult LogoutAction(LogoutModel model)
        {
            return View("StartPage");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
