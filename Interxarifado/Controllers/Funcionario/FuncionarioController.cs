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
            ViewBag.Setores = setoresRepository.ReadSetores(); 
            List<Funcionario> funcionarios = repository.ReadFuncionario();
            return View(funcionarios);
        } 
        public ActionResult FilterBySetores(int IdSetor)
        {
            ViewBag.Setores = setoresRepository.ReadSetores();
            List<Funcionario> funcionarios = repository.ReadBySetores(IdSetor);
            return View("IndexFuncionario", funcionarios);
        }

        [HttpGet]
        public ActionResult CreateFuncionario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFuncionario(Funcionario funcionario)
        {
            repository.CreateFuncionario(funcionario);
            return RedirectToAction("IndexFuncionario");
        }

        public ActionResult DeleteFuncionario(int id)
        {
            repository.DeleteFuncionario(id);
            return RedirectToAction("IndexFuncionario");
        }

        // public ActionResult Login()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public ActionResult Login(FuncionarioLoginViewModel model)
        // {
            

        //     if(ModelState.IsValid)
        //     {
        //         Funcionario funcionario = new Funcionario();

        //         // Adiciona dados na Session
        //         HttpContext.Session.SetInt32("id", funcionario.id);
        //         HttpContext.Session.SetString("nome", funcionario.nome);

        //         return RedirectToAction("Login/IndexLogin");
        //     }

        //     ViewBag.Message = "Usuário não encontrado";
        //     return View(model);
        // }

        [HttpGet]
        public ActionResult UpdateFuncionario(int id)
        {
            //ViewBag.Setores = setoresRepository.ReadSetores();
            var funcionario = repository.ReadFuncionario(id);
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult UpdateFuncionario(int id, Funcionario funcionario)
        {
            repository.UpdateFuncionario(id, funcionario);
            return RedirectToAction("IndexFuncionario");
        } 



    }
}