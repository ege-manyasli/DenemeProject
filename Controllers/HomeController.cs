using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DenemeProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using DenemeProject.Models.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;




namespace DenemeProject.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;
        MyContext _db;
        private IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, MyContext db, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Profile()
        {
            int Id = Convert.ToInt32((HttpContext.User.Identity as ClaimsIdentity)?.FindFirst("Id")?.Value);
            User users = new User();
            if (_db.Users.Any(x => x.Id == Id))
            {
                users = _db.Users.FirstOrDefault(x => x.Id == Id);


                //users.ImagePath = "//C:/Temp/" + users.ImagePath;



                //string basePath = @"\\DESKTOP-8KF30RA\Temp";
                //string imagePath = users.ImagePath; 
                //string combinedPath = Path.Combine(basePath, imagePath);
                users.ImagePath = "/Temp/f986e823-e0a0-4a5e-852e-087fe76c6004.jpg";// + users.ImagePath;


            }


            return View(users);
        }



        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(IFormFile file)
        {
            int Id = Convert.ToInt32((HttpContext.User.Identity as ClaimsIdentity)?.FindFirst("Id")?.Value);
            User user = _db.Users.FirstOrDefault(x => x.Id == Id);

            if (file != null && file.Length > 0)
            {
                var tempPath = @"C:\Temp";
                //var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(tempPath, fileName);

                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }



                user.ImagePath = @"\\C:\Temp\" + fileName;
                _db.SaveChanges();
            }

            return View(user);
        }

        public IActionResult Calender()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View(new Contact());
        }

        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            contact.GonderimTarihi = DateTime.Now;
            _db.Contacts.Add(contact);
            _db.SaveChanges();

            TempData["SuccessMessage"] = "Mesajýnýz iletilmiþtir. Teþekkür ederiz!";

            return View();

        }


        public IActionResult Maps()
        {
            return View();
        }
        public IActionResult Shops()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Pricing()
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View();
        }



    }


}

