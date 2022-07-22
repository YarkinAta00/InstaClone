using HRManagementv2.Data;
using HRManagementv2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRManagementv2.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            IQueryable<UserInf> userList =
               (from UserInf in _db.Users
                join CndInf in _db.Candidates
                on UserInf.UserId equals CndInf.UserId
                join MedInf in _db.Media
                on CndInf.CandidateId equals MedInf.CandidateId 
                

                select new UserInf()
                {
                    FirstName   = UserInf.FirstName,
                    LastName    = UserInf.LastName,
                    Email       = UserInf.Email,  
                    CandidateId = CndInf.CandidateId,
                    UserId      = CndInf.UserId,
                    Photo       = MedInf.Photo,

                });
            return View(userList);
        }
   
        /*
        public IActionResult Index()
        {
            IEnumerable<User> objUserList = _db.Users;
            return View(objUserList);
        } 
        */
        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {

            if (ModelState.IsValid) 
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);   
        }

    }
}
