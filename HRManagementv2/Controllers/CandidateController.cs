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


        IEnumerable<Candidate> objCandidateList = _db.Candidates;

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


            var candidateObj = new CandidateInf();

            foreach(var obj in selectedOptins())
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

}


