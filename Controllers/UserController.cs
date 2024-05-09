using DenemeProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; 


namespace DenemeProject.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserCreateVM userCreateVM)
        {
            return View();
        }
        public IActionResult ındex()
        {
            return View();
        }




    }

     


}

 