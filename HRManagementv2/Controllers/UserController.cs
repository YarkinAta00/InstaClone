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

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            var users = from s in _db.Users
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.FirstName.Contains(searchString)
                                    || s.LastName.Contains(searchString)); 
            }

            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.FirstName);
                    break;
                default:
                    users = users.OrderBy(s => s.FirstName);
                    break;
            }
            
            return View(await users.AsNoTracking().ToListAsync());
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
