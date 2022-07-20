using HRManagementv2.Data;
using HRManagementv2.Models;
using Microsoft.AspNetCore.Mvc;
namespace HRManagementv2.Controllers
{
    public class MediaController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public IActionResult Index()
        {
            return View();
        }

        public MediaController (ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            this._hostEnvironment = hostEnvironment;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MediaId,CandidateId,photoFile,resumeFile")] Media mediaModel)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(mediaModel.photoFile.FileName);
                string extension = Path.GetExtension(mediaModel.photoFile.FileName);
                mediaModel.Photo =fileName =  fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/media/photo", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await mediaModel.photoFile.CopyToAsync(fileStream);
                }

                string resFileName = Path.GetFileNameWithoutExtension(mediaModel.resumeFile.FileName);
                string resExtension = Path.GetExtension(mediaModel.resumeFile.FileName);
                mediaModel.Resume = resFileName =  resFileName + DateTime.Now.ToString("yymmssfff") + resExtension;
                string resPath = Path.Combine(wwwRootPath + "/media/resume", resFileName);
                
                using (var resFileStream = new FileStream(resPath,FileMode.Create))
                {
                    await mediaModel.resumeFile.CopyToAsync(resFileStream);
                }

                _db.Add(mediaModel);
                await _db.SaveChangesAsync();
                return RedirectToAction("/Candidate/Index");
            }
            else
                return View();

        }


    }
}
