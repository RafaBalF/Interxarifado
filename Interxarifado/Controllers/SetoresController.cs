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
            ViewBag.ResponsavelSetor = responsavelRepository.ReadResponsavel();
            List<Setores> setores = repository.ReadSetores();
            return View(setores);
        }
        public ActionResult FilterByResponsavel(int id)
        {
            ViewBag.ResponsavelSetor = responsavelRepository.ReadResponsavel();
            List<Setores> setores = repository.ReadByResponsavel(id);
            return View("IndexSetores", setores);
        }
        [HttpGet]
        public ActionResult CreateSetores()
        {
            ViewBag.ResponsavelSetor = responsavelRepository.ReadResponsavel();
            return View();
        }

        [HttpPost]
        public ActionResult CreateSetores(Setores setores)
        {
            repository.CreateSetores(setores);
            return RedirectToAction("IndexSetores");
        }

        public ActionResult DeleteSetores(int IdSetor)
        {
            repository.DeleteSetores(IdSetor);
            return RedirectToAction("IndexSetores");
        }

        [HttpGet]
        public ActionResult UpdateSetores(int IdSetor)
        {
            ViewBag.ResponsavelSetor = responsavelRepository.ReadResponsavel();
            var setor = repository.ReadSetores(IdSetor);
            return View(setor);
        }

        [HttpPost]
        public ActionResult UpdateSetores(int IdSetor, Setores setores)
        {
            repository.UpdateSetores(IdSetor, setores);
            return RedirectToAction("IndexSetores");
        } 
        
    }
}