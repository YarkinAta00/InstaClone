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
        /*
        public IActionResult Index()
        {
            IEnumerable<Interview> objInterviewList = _db.InterviewDetails;
            return View(objInterviewList);
        }
        */
        public IActionResult Index()
        {
          
            return View(selectedOptions());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Main()
        {
            return View(selectedOptions());
        }

        public IActionResult Result()
        {
            return View(selectedOptions());
        }

        private List<InterviewInf> selectedOptions()
        {
            IQueryable<InterviewInf> interviewList =
                         (from ApplInf in _db.Applications
                          join IntInf in _db.InterviewDetails
                          on ApplInf.ApplicationId equals IntInf.ApplicationId
                          join CndInf in _db.Candidates
                          on ApplInf.CandidateId equals CndInf.CandidateId
                          join UserInf in _db.Users
                          on CndInf.UserId equals UserInf.UserId
                          join JobInf in _db.Jobs
                          on ApplInf.JobId equals JobInf.JobId

                          select new InterviewInf()
                          {
                              FirstName = UserInf.FirstName,
                              LastName = UserInf.LastName,
                              JobTitle = JobInf.JobTitle,
                              State = IntInf.State,
                              Type = IntInf.Type,
                              InterviewDate = IntInf.InterviewDate,
                              SalaryExpectation = IntInf.SalaryExpectation,
                              AlternateRole = IntInf.AlternateRole,
                              Participants = IntInf.Participants,
                              FoundFrom = ApplInf.FoundFrom,


                          });
            return interviewList.ToList();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Interview obj)
        {
            if (obj.InterviewId != null)
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
