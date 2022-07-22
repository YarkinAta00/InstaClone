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

        public IActionResult Candidates()
        {
           IQueryable<CandidateInf> candidate2List =

            (from CandInf in _db.Candidates
             join UsrInf in _db.Users
             on CandInf.UserId equals UsrInf.UserId into UsrCnd

             from uc in UsrCnd.DefaultIfEmpty()
             join m in _db.Media
             on CandInf.CandidateId equals m.CandidateId into UsrCndMed

             from ucm in UsrCndMed.DefaultIfEmpty()
             select new CandidateInf()
             {
                 CandidateId = CandInf.CandidateId,
                 FirstName = uc.FirstName,
                 LastName = uc.LastName,
                 City = CandInf.City,
                 Province = CandInf.Province,
                 Gender = CandInf.Gender,
                 PhoneNumber = CandInf.PhoneNumber,
                 Email = uc.Email,
                 Photo = ucm.Photo,

             });

            return View(candidate2List);
        }
        
        public IActionResult Index()
        {
            return View(selectedOptions());
        }
        

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Candidate objCnd)
        {


            if (objCnd.PhoneNumber != null )
            {
                _db.Candidates.Add(objCnd);
                /*
                foreach (var obj in _db.Candidates)
                {
                    if (obj.CandidateId == )
                    {
                        candidateObj = obj;
                    }
                }
                */

                
                //_db.Languages.Add(objLang);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objCnd);
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

        public IActionResult Create2()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create2(Language obj, int id)
        {
            obj.CandidateId = id;
            if (obj.CandidateId != null) {
                _db.Languages.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        
            return View(obj);
        }
            
        public ActionResult Details(int? id)
        {
            //var candidateFromDb = _db.Candidates.Find(id);    


            var candidateObj = new CandidateInf();

            foreach(var obj in selectedOptions())
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

        private List<CandidateInf> selectedOptions()
        {
           IQueryable<CandidateInf> candidateList =
             (from CandInf in _db.Candidates.DefaultIfEmpty()
             join UsrInf in _db.Users
             on CandInf.UserId equals UsrInf.UserId into UsrCnd

             from uc in UsrCnd.DefaultIfEmpty()
             join m in _db.Media
             on CandInf.CandidateId equals m.CandidateId into UsrCndMed
              
             from ucm in UsrCndMed.DefaultIfEmpty()
             join l in _db.Languages
             on CandInf.CandidateId equals l.CandidateId into UsrCndMedLang
             
             from ucml in UsrCndMedLang.DefaultIfEmpty()
             join a in _db.Applications
             on CandInf.CandidateId equals a.CandidateId into UsrCndMedLangAp
             
             from ucmla in UsrCndMedLangAp.DefaultIfEmpty()
             select new CandidateInf()
             {
                 CandidateId = CandInf.CandidateId,
                 PhoneNumber = CandInf.PhoneNumber,
                 Gender = CandInf.Gender,
                 PersonalityTest = CandInf.PersonalityTest,
                 AddressLine = CandInf.AddressLine,
                 City = CandInf.City,
                 Province = CandInf.Province,
                 Skills = CandInf.Skills,
                 Hobbies = CandInf.Hobbies,
                 FirstName = uc.FirstName,
                 LastName = uc.LastName,
                 Email = uc.Email,
                 CreatedDate = uc.CreatedDate,
                 Photo = ucm.Photo,
                 Resume = ucm.Resume,
                 LanguageName = ucml.LanguageName,
                 LanguageLevel = ucml.LanguageLevel,
                 AppCreatedDate = ucmla.CreatedDate,
                 AppStatus = ucmla.Status,
                 FoundFrom = ucmla.FoundFrom,
             });
            
            return candidateList.ToList();

        } 
        
        private List<CandidateInf> onlyBasic()
        {
            IQueryable<CandidateInf> candidateBasicList =
                 (from CndInf in _db.Candidates
                  join UsrInf in _db.Users
                 on CndInf.UserId equals UsrInf.UserId
                 

                  select new CandidateInf()
                  {
                      FirstName = UsrInf.FirstName,
                      LastName  = UsrInf.LastName,
                      City     = CndInf.City,
                      Province     = CndInf.Province,
                      PhoneNumber     = CndInf.PhoneNumber,
                      Gender = CndInf.Gender,   
                      CandidateId = CndInf.CandidateId,
                      Email     = UsrInf.Email,
                  });
            return candidateBasicList.ToList();

        }



    }

}


