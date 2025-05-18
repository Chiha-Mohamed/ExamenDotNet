using Examen.ApplicationCore.Domain;
using Examen.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Examen.UI.Web.Controllers
{
    public class InfirmierController : Controller
    {
        private readonly AppDbContext _ctx;
        public InfirmierController(AppDbContext ctx) => _ctx = ctx;


        public IActionResult Index()
        {
            var list = _ctx.Infirmiers
                .Include(i => i.Laboratoire) 
                .ToList();

            return View(list);
        }

        
        public IActionResult Create()
        {
            ViewBag.Laboratoires = new SelectList(_ctx.Laboratoires, "LaboratoireId", "Intitule");
            ViewBag.Specialites = new SelectList(Enum.GetValues(typeof(Specialite)));
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Infirmier infirmier)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Laboratoires = new SelectList(_ctx.Laboratoires, "LaboratoireId", "Intitule", infirmier.LaboratoireId);
                ViewBag.Specialites = new SelectList(Enum.GetValues(typeof(Specialite)), infirmier.Specialite);
                return View(infirmier);
            }

            _ctx.Infirmiers.Add(infirmier);
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Patients(int id)
        {
            var patients = _ctx.Bilans
                .Include(b => b.Patient)
                .Where(b => b.InfirmierId == id)
                .Select(b => b.Patient)
                .Distinct()
                .ToList();

            return View(patients);
        }
    }
}
