using DataLayer;
using DataLayer.Entities;
using MathTeach.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MathTeach.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<HomeController> _logger;
        public MathDbContext _context;

        public AccountController(SignInManager<IdentityUser> signInManager, ILogger<HomeController> logger, MathDbContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new StartModel { Result = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(StartModel model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login.Equals(model.Login));
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
            StudentModel model = new StudentModel() { Name = user.FIO };
            return View("StudentView", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
