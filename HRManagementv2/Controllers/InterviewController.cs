using HRManagementv2.Data;
using HRManagementv2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementv2.Controllers
{
    public class InterviewController : Controller
    {
        private readonly ApplicationDbContext _db;

        public InterviewController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Interview> objInterviewList = _db.InterviewDetails;
            return View(objInterviewList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult Result()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Interview obj)
        {
            if (obj.ApplicationId != null)
            {
                _db.InterviewDetails.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }
    }
}
