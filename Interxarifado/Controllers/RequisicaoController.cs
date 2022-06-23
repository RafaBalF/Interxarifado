using Interxarifado.Models;
using Microsoft.AspNetCore.Mvc;
using Interxarifado.Repositories;

namespace Interxarifado.Controllers
{
    public class RequisicaoController : Controller
    {
        private IRequisicaoRepository repository;
        private ISetoresRepository setoresRepository;
        private IResponsavelRepository responsavelRepository; 
        public RequisicaoController(IRequisicaoRepository repository, ISetoresRepository setoresRepository,IResponsavelRepository responsavelRepository)
        {
            this.repository = repository;
            this.setoresRepository = setoresRepository;
            this.responsavelRepository = responsavelRepository;
        }

        public ActionResult IndexRequisicao()
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ViewBag.Setores = setoresRepository.ReadSetores();
            List<Requisicao> requisicoes = repository.ReadRequisicao();
            return View(requisicoes);
        }
        public ActionResult FilterBySetor(int IdSetor)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ViewBag.Setores = setoresRepository.ReadSetores();
            List<Requisicao> requisicoes = repository.ReadBySetor(IdSetor);
            return View("IndexRequisicao", requisicoes);
        }

        [HttpGet]
        public ActionResult CreateRequisicao()
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ViewBag.Setores = setoresRepository.ReadSetores();
            ViewBag.Responsavel = responsavelRepository.ReadResponsavel();
            return View();
        }

        [HttpPost]
        public ActionResult CreateRequisicao(Requisicao requisicao)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.CreateRequisicao(requisicao);
            return RedirectToAction("CreateProdutoRequi","ProdutoRequisicao");
        }

        public ActionResult DeleteRequisicao(int idRequisicao)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.DeleteRequisicao(idRequisicao);
            return RedirectToAction("IndexRequisicao");
        }

        [HttpGet]
        public ActionResult UpdateRequisicao(int id)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ViewBag.Setores = setoresRepository.ReadSetores();
            var requisicoes = repository.ReadRequisicao(id);
            return View(requisicoes);
        }

        [HttpPost]
        public ActionResult UpdateRequisicao(int id, Requisicao requisicao)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.UpdateRequisicao(id, requisicao);
            return RedirectToAction("IndexRequisicao");
        }
    }
}