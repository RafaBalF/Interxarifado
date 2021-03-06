using Interxarifado.Models;
using Microsoft.AspNetCore.Mvc;
using Interxarifado.Repositories;

namespace Interxarifado.Controllers
{
    public class ResponsavelController : Controller
    {
        private IResponsavelRepository repository;
        public ResponsavelController(IResponsavelRepository repository)
        {
            this.repository = repository;
        }
        
        public ActionResult Home()
        {
            
                int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
                 return View();
                
        }

        public ActionResult IndexResponsavel()
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            List<ResponsavelSetor> responsaveis = repository.ReadResponsavel();
            return View(responsaveis);
        }
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(ResponsavelViewModel model)
        {
            
            var responsavel =repository.ReadResponsavel(model.email, model.senha);

            try
            {
                if(model.email == responsavel.email && model.senha==responsavel.senha )
                {
                    HttpContext.Session.SetInt32("id", responsavel.id);
                    HttpContext.Session.SetString("nome", responsavel.nome);

                    return RedirectToAction("Home", "Login");
                }
                else{
                    return RedirectToAction("Index","Login");
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "login ou senha invalidos";
                return View();

            }
            finally
            {
                Dispose();

            }
        }

        [HttpGet]
        public ActionResult CreateResponsavel()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult CreateResponsavel(ResponsavelSetor responsavel)
        {
            
            repository.CreateResponsavel(responsavel);
            return RedirectToAction("IndexResponsavel");
        }

        public ActionResult DeleteResponsavel(int id)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.DeleteResponsavel(id);
            return RedirectToAction("IndexResponsavel");
        }

        [HttpGet]
        public ActionResult UpdateResponsavel(int id)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            var responsavel = repository.ReadResponsavel(id);
            return View(responsavel);
        }

        [HttpPost]
        public ActionResult UpdateResponsavel(int id, ResponsavelSetor responsavel)
        {
            int? idzz = HttpContext.Session.GetInt32("id") as int?;
                if(idzz == null)
                {
                    return RedirectToAction("Login", "Responsavel");
                }
            repository.UpdateResponsavel(id, responsavel);
            return RedirectToAction("IndexResponsavel");
        } 
    }
}