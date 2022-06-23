using Interxarifado.Models;
using Microsoft.AspNetCore.Mvc;
using Interxarifado.Repositories;

namespace Interxarifado.Controllers
{
    public class EstoqueController : Controller
    {
        private IEstoqueRepository repository;
        public EstoqueController(IEstoqueRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult IndexEstoque()
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            List<Estoque> produtos = repository.ReadEstoque();
            return View(produtos);
        }

        [HttpGet]
        public ActionResult CreateEstoque()
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            return View();
        }

        [HttpPost]
        public ActionResult CreateEstoque(Estoque produto)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.CreateEstoque(produto);
            return RedirectToAction("IndexEstoque");
        }

        public ActionResult DeleteEstoque(int idProduto)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.DeleteEstoque(idProduto);
            return RedirectToAction("IndexEstoque");
        }

        [HttpGet]
        public ActionResult UpdateEstoque(int idProduto)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            var produto = repository.ReadEstoque(idProduto);
            return View(produto);
        }

        [HttpPost]
        public ActionResult UpdateEstoque(int idProduto, Estoque produto)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.UpdateEstoque(idProduto, produto);
            return RedirectToAction("IndexEstoque");
        } 
    }
}