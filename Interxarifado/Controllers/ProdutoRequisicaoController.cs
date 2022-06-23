using Interxarifado.Models;
using Microsoft.AspNetCore.Mvc;
using Interxarifado.Repositories;

namespace Interxarifado.Controllers
{
    public class ProdutoRequisicaoController : Controller
    {
        private IProdutoRequisicaoRepository repository;
        private IRequisicaoRepository requisicaoRepository;
        public ProdutoRequisicaoController(IProdutoRequisicaoRepository repository,IRequisicaoRepository requisicaoRepository)
        {
            this.repository = repository;
            this.requisicaoRepository = requisicaoRepository;
        }
         public ActionResult IndexProdutoRequi()
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ProdutoRequisicao preq = repository.ReadProdutoRequi();
            return View(preq);
        }
        public ActionResult FilterByRequisicao(int idRequisicao)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ViewBag.Requisicao = requisicaoRepository.ReadRequisicao();
            List<ProdutoRequisicao> preq = repository.ReadByRequisicao(idRequisicao);
            return View("IndexProdutoRequi", preq);
        }

        [HttpGet]
        public ActionResult CreateProdutoRequi()
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ViewBag.Requisicao = requisicaoRepository.ReadRequisicao();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProdutoRequi(ProdutoRequisicao preq)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.CreateProdutoRequi(preq);
            ViewBag.Requisicao = requisicaoRepository.ReadRequisicao();
            return RedirectToAction("IndexProdutoRequi");
        }

        // [HttpGet]
        // public ActionResult UpdateProdutoRequi(int idPreq)
        // {
        //     var preq = repository.ReadProdutoRequi(idPreq);
        //     return View(preq);
        // }

        // [HttpPost]
        // public ActionResult UpdateProdutoRequi(int idPreq, ProdutoRequisicao preq)
        // {
        //     repository.UpdateProdutoRequi(idPreq, preq);
        //     return RedirectToAction("IndexProdutoRequi");
        // } 
    }
}