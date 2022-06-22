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
            List<Estoque> produtos = repository.ReadEstoque();
            return View(produtos);
        }

        [HttpGet]
        public ActionResult CreateEstoque()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEstoque(Estoque produto)
        {
            repository.CreateEstoque(produto);
            return RedirectToAction("IndexEstoque");
        }

        public ActionResult DeleteEstoque(int idProduto)
        {
            repository.DeleteEstoque(idProduto);
            return RedirectToAction("IndexEstoque");
        }

        [HttpGet]
        public ActionResult UpdateEstoque(int idProduto)
        {
            var produto = repository.ReadEstoque(idProduto);
            return View(produto);
        }

        [HttpPost]
        public ActionResult UpdateEstoque(int idProduto, Estoque produto)
        {
            repository.UpdateEstoque(idProduto, produto);
            return RedirectToAction("IndexEstoque");
        } 
    }
}