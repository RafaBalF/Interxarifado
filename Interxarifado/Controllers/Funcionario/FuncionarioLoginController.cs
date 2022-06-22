// using Microsoft.AspNetCore.Mvc;
// using Interxarifado.Models;


// namespace FuncionarioLogin.Controllers
// {
//     public class FuncionarioLoginController : Controller
//     {
//         public ActionResult Login()
//         {
//             return View();
//         }

//         [HttpPost]
//         public ActionResult Login(FuncionarioViewModel model)
//         {
            

//             if(ModelState.IsValid)
//             {
//                 Funcionario funcionario = new Funcionario();

//                 // Adiciona dados na Session
//                 HttpContext.Session.SetInt32("id", funcionario.id);
//                 HttpContext.Session.SetString("nome", funcionario.nome);

//                 return RedirectToAction("Login/IndexLogin");
//             }

//             ViewBag.Message = "Usuário não encontrado";
//             return View(model);
//         }
//     }
// }