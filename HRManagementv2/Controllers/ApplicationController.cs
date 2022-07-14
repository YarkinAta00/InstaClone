using HRManagementv2.Data;
using HRManagementv2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementv2.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ApplicationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Create()
        {
            return View();
        }
        

        public IActionResult Index()
        {
            return View(selectedOptions());
        }

        public List<ApplicationInf> selectedOptions()
        {
            IQueryable<ApplicationInf> applicationList =
                         (from ApplInf in _db.Applications
                          join CandInf in _db.Candidates
                          on ApplInf.CandidateId equals CandInf.CandidateId
                          join JobInf in _db.Jobs
                          on ApplInf.JobId equals JobInf.JobId
                          join UserInf in _db.Users
                          on CandInf.UserId equals UserInf.UserId
                          

                          select new ApplicationInf()
                          {
                              FirstName = UserInf.FirstName,
                              LastName = UserInf.LastName,
                              JobTitle = JobInf.JobTitle,
                              ApplicationId = ApplInf.ApplicationId,
                              

                          });
            return applicationList.ToList();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Application obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Applications.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Create");
            }
            return RedirectToAction("Index");
        } 

    
        

    }
}
