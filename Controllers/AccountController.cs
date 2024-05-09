using DenemeProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Http;
using DenemeProject.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using DenemeProject.Data;
using Microsoft.AspNetCore.Identity;


namespace DenemeProject.Controllers
{
    public class AccountController : BaseController
    {
        MyContext _db;
        private string connectionString;

        public AccountController(MyContext db)
        {
            _db = db;

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            //if (_db.Users.Where(x => x.Email == user.Email && x.Password == user.Password).Count()>0)
            //if (_db.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password) != null)
            //if (_db.Users.Any(x => x.Email == user.Email && x.Password == user.Password))
            //{

            //}
            if (_db.Users.Any(x => x.Email == user.Email && x.Password == user.Password ))
            {
                var users = _db.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                

                List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier,user.Email),
                new Claim("Id", users.Id.ToString()),
                new Claim("OtherProperties","Role")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    //AllowRefresh = true,
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(30)
                };


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index", "Home");


            }

            return View(new User());

            
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);                                                     
            return RedirectToAction("Login", "Account");

        }



        public IActionResult Register()

        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(UserCreateVM userCreateVM)
        {
            TempData.Clear();

            //Context.DataSource = _db.Users.ToList();

            var users = _db.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.UserName}, Password: {user.Password}, Email: {user.Email}");
            }

            var query = users.Where(user => user.UserName.Contains("s"));

            foreach (var user in query)
            {
                Console.WriteLine(user.UserName);
            }

            var query2 = _db.Users.FirstOrDefault(u => u.UserName == userCreateVM.UserName);

            foreach (var user in query)
            {
                Console.WriteLine();
            }


            var NameUser = _db.Users.FirstOrDefault(u => u.UserName == userCreateVM.UserName); //async olmayan yapı

            try
            {
                if (NameUser != null)
                {
                    TempData["Message"] = "Var olan Kullanıcı bilgisi ! ";
                    return RedirectToAction(nameof(Register));

                }

                if (!ParolaGecerliMi(userCreateVM.Password))
                {
                    TempData["Message"] = "Parola en az 8 karakterden oluşmalı ve büyük harf, küçük harf, rakam ve özel karakter içermelidir.";
                    return RedirectToAction(nameof(Register));
                }


                User user = new User();
                user.UserName = userCreateVM.UserName;
                user.Password = userCreateVM.Password;
                user.Email = userCreateVM.Email;
                user.Active = true;
                user.IpAdress = "";

                //email var mı , userame var mı bak. 

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Ege Manyaslı"),
                new Claim(ClaimTypes.Email, "ege@hotmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            };

                var identity = new ClaimsIdentity(claims, "MyAuthenticationType");

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                _db.Users.Add(user);
                _db.SaveChanges();

                TempData["SuccessMessage"] = "User added successfully!";
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction(nameof(Login));
        }
        private bool ParolaGecerliMi(string parola)
        {

            if (parola.Length < 8)
                return false;

            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");

            return regex.IsMatch(parola);

        }




        [HttpGet]
        public IActionResult UserInformation()
        {
            return View(new MusteriKayit());

        }

        [HttpPost]
        public IActionResult UserInformation(MusteriKayit musteriKayits)
        {

            musteriKayits.DogumTarihi = DateTime.Now;
            _db.MusteriKayits.Add(musteriKayits);
            _db.SaveChanges();

            TempData["SuccessMessage"] = "Müşteri kaydınız oluşturulmuştur. Teşekkür ederiz!";

            return View();

        }


    }
}



