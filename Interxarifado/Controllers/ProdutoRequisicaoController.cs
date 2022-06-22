using Interxarifado.Models;
using Microsoft.AspNetCore.Mvc;
using Interxarifado.Repositories;

namespace Interxarifado.Controllers
{
    public class ProdutoRequisicaoController : Controller
    {
        private IProdutoRequisicaoRepository repository;
        public ProdutoRequisicaoController(IProdutoRequisicaoRepository repository)
        {
            this.repository = repository;
        }
         public ActionResult IndexProdutoRequi()
        {
            List<ProdutoRequisicao> preq = repository.ReadProdutoRequi();
            return View(preq);
        }

        [HttpGet]
        public ActionResult CreateProdutoRequi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProdutoRequi(ProdutoRequisicao preq)
        {
            repository.CreateProdutoRequi(preq);
            return RedirectToAction("IndexProdutoRequi");
        }

        [HttpGet]
        public ActionResult UpdateProdutoRequi(int idPreq)
        {
            var preq = repository.ReadProdutoRequi(idPreq);
            return View(preq);
        }

        [HttpPost]
        public ActionResult UpdateProdutoRequi(int idPreq, ProdutoRequisicao preq)
        {
            repository.UpdateProdutoRequi(idPreq, preq);
            return RedirectToAction("IndexProdutoRequi");
        } 
    }
}