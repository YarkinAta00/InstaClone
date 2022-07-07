using HRManagementv2.Data;
using HRManagementv2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementv2.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext _db;

        public JobController(ApplicationDbContext db)
        {
            _db = db;   
        }

        public IActionResult Index()
        {
            IEnumerable<Job> objJobList = _db.Jobs;
            return View(objJobList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Job obj)
        {
            _db.Jobs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
