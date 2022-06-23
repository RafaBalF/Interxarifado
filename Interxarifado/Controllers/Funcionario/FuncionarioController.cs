using Interxarifado.Models;
using Microsoft.AspNetCore.Mvc;
using Interxarifado.Repositories;

namespace Interxarifado.Controllers
{
    public class FuncionarioController : Controller
    {
        private IFuncionarioRepository repository;
        private ISetoresRepository setoresRepository;

        public FuncionarioController(IFuncionarioRepository repository, ISetoresRepository setoresRepository)
        {
            this.repository = repository;
            this.setoresRepository = setoresRepository;
        }



        public ActionResult IndexFuncionario()
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            ViewBag.Setores = setoresRepository.ReadSetores(); 
            List<Funcionario> funcionarios = repository.ReadFuncionario();
            return View(funcionarios);
        } 
        public ActionResult FilterBySetores(int IdSetor)
        {
            ViewBag.Setores = setoresRepository.ReadSetores();
            List<Funcionario> funcionarios = repository.ReadBySetor(IdSetor);
            return View("IndexFuncionario", funcionarios);
        }

        [HttpGet]
        public ActionResult CreateFuncionario()
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            return View();
        }

        [HttpPost]
        public ActionResult CreateFuncionario(Funcionario funcionario)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.CreateFuncionario(funcionario);
            return RedirectToAction("IndexFuncionario");
        }

        public ActionResult DeleteFuncionario(int id)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.DeleteFuncionario(id);
            return RedirectToAction("IndexFuncionario");
        }


        [HttpGet]
        public ActionResult UpdateFuncionario(int id)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            //ViewBag.Setores = setoresRepository.ReadSetores();
            var funcionario = repository.ReadFuncionario(id);
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult UpdateFuncionario(int id, Funcionario funcionario)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.UpdateFuncionario(id, funcionario);
            return RedirectToAction("IndexFuncionario");
        } 



    }
}