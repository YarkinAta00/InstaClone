using HRManagementv2.Data;
using HRManagementv2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRManagementv2.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CandidateController(ApplicationDbContext db)
        {
            _db = db;
        }


        /*
        public IActionResult Index()
        {
            IEnumerable<Candidate> objCandidateList = _db.Candidates;
            return View(objCandidateList);
        }
        */
        public IActionResult Index()
        {

            IQueryable<CandidateInf> candidateList =
                (from CndInf in _db.Candidates
                    join LngInf in _db.Languages
                    on CndInf.CandidateId equals LngInf.CandidateId
                    join UserInf in _db.Users
                    on CndInf.UserId equals UserInf.UserId
                    join MedInf in _db.Media
                    on CndInf.CandidateId equals MedInf.CandidateId 
                    

                    select new CandidateInf()
                    {
                        FirstName       = UserInf.FirstName,
                        LastName        = UserInf.LastName, 
                        CandidateId     = CndInf.CandidateId,
                        UserId          = CndInf.UserId,
                        PhoneNumber     = CndInf.PhoneNumber,
                        Gender          = CndInf.Gender,
                        PersonalityTest = CndInf.PersonalityTest,
                        AddressLine     = CndInf.AddressLine,
                        City            = CndInf.City,
                        Province        = CndInf.Province,
                        Skills          = CndInf.Skills,
                        Hobbies         = CndInf.Hobbies,
                        LanguageName    = LngInf.LanguageName,
                        LanguageLevel   = LngInf.LanguageLevel,
                        Photo           = MedInf.Photo,



                    }) ;
            return View(candidateList);
        }
        

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Candidate obj)
        {

            if (obj.PhoneNumber != null )
            {
                _db.Candidates.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(obj);
        } 
        
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var candidateFromDb = _db.Candidates.Find(id);
            //var candidateFromDbFirst = _db.Candidates.FirstOrDefault(u=>u.CandidateId==id);
            //var candidateFromDbSingle = _db.Candidates.SingleOrDefault(u=>u.CandidateId==CandidateId);

            if(candidateFromDb== null)
            {
                return NotFound();
            }
                return View(candidateFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Candidate obj)
        {
            if (obj.CandidateId != null) {
                _db.Candidates.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        
            return View(obj);
        }
            
        public ActionResult Details(int? id)
        {
            //var candidateFromDb = _db.Candidates.Find(id);    

             IQueryable<CandidateInf> candidateList =
                (from CndInf in _db.Candidates
                    join LngInf in _db.Languages
                    on CndInf.CandidateId equals LngInf.CandidateId
                    join UserInf in _db.Users
                    on CndInf.UserId equals UserInf.UserId
                    join ApplInf in _db.Applications
                    on CndInf.CandidateId equals ApplInf.CandidateId
                    join JobInf in _db.Jobs
                    on ApplInf.JobId equals JobInf.JobId
                    join MedInf in _db.Media
                    on CndInf.CandidateId equals MedInf.CandidateId

                    select new CandidateInf()
                    {
                        FirstName       = UserInf.FirstName,
                        LastName        = UserInf.LastName,
                        Email           = UserInf.Email,
                        CreatedDate     = UserInf.CreatedDate,
                        CandidateId     = CndInf.CandidateId,
                        UserId          = CndInf.UserId,
                        PhoneNumber     = CndInf.PhoneNumber,
                        Gender          = CndInf.Gender,
                        PersonalityTest = CndInf.PersonalityTest,
                        AddressLine     = CndInf.AddressLine,
                        City            = CndInf.City,
                        Province        = CndInf.Province,
                        Skills          = CndInf.Skills,
                        Hobbies         = CndInf.Hobbies,
                        LanguageName    = LngInf.LanguageName,
                        LanguageLevel   = LngInf.LanguageLevel,
                        AppCreatedDate = ApplInf.CreatedDate,
                        AppStatus = ApplInf.Status,
                        FoundFrom = ApplInf.FoundFrom,
                        JobTitle = JobInf.JobTitle,
                        Department = JobInf.Department,
                        Photo = MedInf.Photo,

                    }) ;

            var candidateObj = new CandidateInf();

            foreach(var obj in candidateList)
            {
                if(obj.CandidateId == id)
                {
                    candidateObj = obj;
                }
            }

            return View("Details", candidateObj);


            /*
            if (candidateFromDb == null)
                return View("NotFound");
            else
                return View("Details", candidateList);
            */
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var candidateFromDb = _db.Candidates.Find(id);

            if (candidateFromDb == null)
            {
                return NotFound();
            }
            return View(candidateFromDb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Candidates.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Candidates.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

      

    }

}


