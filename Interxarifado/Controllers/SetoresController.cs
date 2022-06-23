using Interxarifado.Models;
using Microsoft.AspNetCore.Mvc;
using Interxarifado.Repositories;

namespace Interxarifado.Controllers
{
    public class SetoresController : Controller
    {
        private ISetoresRepository repository;
        private IResponsavelRepository responsavelRepository;
        public SetoresController(ISetoresRepository repository, IResponsavelRepository responsavelRepository)
        {
            this.repository = repository;
            this.responsavelRepository = responsavelRepository;
        }

        public ActionResult IndexSetores()
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ViewBag.ResponsavelSetor = responsavelRepository.ReadResponsavel();
            List<Setores> setores = repository.ReadSetores();
            return View(setores);
        }
        public ActionResult FilterByResponsavel(int id)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ViewBag.ResponsavelSetor = responsavelRepository.ReadResponsavel();
            List<Setores> setores = repository.ReadByResponsavel(id);
            return View("IndexSetores", setores);
        }
        [HttpGet]
        public ActionResult CreateSetores()
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ViewBag.ResponsavelSetor = responsavelRepository.ReadResponsavel();
            return View();
        }

        [HttpPost]
        public ActionResult CreateSetores(Setores setores)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.CreateSetores(setores);
            return RedirectToAction("IndexSetores");
        }

        public ActionResult DeleteSetores(int IdSetor)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.DeleteSetores(IdSetor);
            return RedirectToAction("IndexSetores");
        }

        [HttpGet]
        public ActionResult UpdateSetores(int IdSetor)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ViewBag.ResponsavelSetor = responsavelRepository.ReadResponsavel();
            var setor = repository.ReadSetores(IdSetor);
            return View(setor);
        }

        [HttpPost]
        public ActionResult UpdateSetores(int IdSetor, Setores setores)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.UpdateSetores(IdSetor, setores);
            return RedirectToAction("IndexSetores");
        } 
        
    }
}