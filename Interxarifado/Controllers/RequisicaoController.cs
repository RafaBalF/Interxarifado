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
            ViewBag.Setores = setoresRepository.ReadSetores();
            List<Requisicao> requisicoes = repository.ReadRequisicao();
            return View(requisicoes);
        }
        public ActionResult FilterBySetores(int IdSetor)
        {
            ViewBag.Setores = setoresRepository.ReadSetores();
            List<Requisicao> requisicoes = repository.ReadBySetores(IdSetor);
            return View("IndexRequisicao", requisicoes);
        }

        [HttpGet]
        public ActionResult CreateRequisicao()
        {
            ViewBag.Setores = setoresRepository.ReadSetores();
            ViewBag.Responsavel = responsavelRepository.ReadResponsavel();
            return View();
        }

        [HttpPost]
        public ActionResult CreateRequisicao(Requisicao requisicao)
        {
            repository.CreateRequisicao(requisicao);
            return RedirectToAction("CreateProdutoRequi","ProdutoRequisicao");
        }

        public ActionResult DeleteRequisicao(int idRequisicao)
        {
            repository.DeleteRequisicao(idRequisicao);
            return RedirectToAction("IndexRequisicao");
        }

        [HttpGet]
        public ActionResult UpdateRequisicao(int id)
        {
            ViewBag.Setores = setoresRepository.ReadSetores();
            var requisicoes = repository.ReadRequisicao(id);
            return View(requisicoes);
        }

        [HttpPost]
        public ActionResult UpdateRequisicao(int id, Requisicao requisicao)
        {
            repository.UpdateRequisicao(id, requisicao);
            return RedirectToAction("IndexRequisicao");
        }
    }
}