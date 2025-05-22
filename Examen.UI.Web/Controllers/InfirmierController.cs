using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.UI.Web.Controllers
{
    public class InfirmierController : Controller
    {
        IServiceInfirmier inf;
        IServiceLaboratoire laboService; // You need a service to get Laboratoires

        public InfirmierController(IServiceInfirmier inf, IServiceLaboratoire laboService)
        {
            this.inf = inf;
            this.laboService = laboService;
        }
        // GET: InfirmierController
        public ActionResult Index()
        {
            var infirmiers = inf.GetAllWithLaboratoire();
            return View(infirmiers);
        }

        // GET: InfirmierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InfirmierController/Create
        public ActionResult Create()
        {
            var laboratoires = laboService.GetMany().ToList();
            ViewBag.Laboratoires = new SelectList(laboratoires, "LaboratoireId", "Intitule");

            var specialites = Enum.GetValues(typeof(Specialite))
                                  .Cast<Specialite>()
                                  .Select(s => new SelectListItem
                                  {
                                      Value = ((int)s).ToString(),
                                      Text = s.ToString()
                                  }).ToList();
            ViewBag.Specialites = specialites;

            return View();
        }

        // POST: InfirmierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Infirmier collection)
        {
            inf.Add(collection);
            inf.Commit();
            return RedirectToAction(nameof(Index));
        }

        // GET: InfirmierController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InfirmierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InfirmierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InfirmierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
