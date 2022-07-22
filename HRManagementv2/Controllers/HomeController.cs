using HRManagementv2.Data;
using HRManagementv2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRManagementv2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;



        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User p)
        {
            ApplicationDbContext c = new ApplicationDbContext();
            var userinfo=c.Users.FirstOrDefault(x=>x.Email == p.Email && x.Password == p.Password);
            if (userinfo != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            return RedirectToAction("Login");
        }
        
        public IActionResult Index()
        {
                
            return View(selectedOptions());
        }

        public IActionResult Auth()
        {
            return View();

        }

        public IActionResult Help()
        {
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public List<UserInf> selectedOptions()
        {
            IQueryable<UserInf> candList =
                         (from j in _db.Jobs

                            select new UserInf()
                          {
                              JobId = (from a in _db.Jobs select a).Count(),                  
                              CandidateId = (from b in _db.Candidates select b).Count(),                  
                              ApplicationId = (from c in _db.Applications select c).Count(),                  
                          });


            return candList.ToList();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}