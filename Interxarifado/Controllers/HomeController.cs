using Interxarifado.Models;
using Microsoft.AspNetCore.Mvc;
using Interxarifado.Repositories;

namespace Interxarifado.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
             return RedirectToAction("Login","Responsavel");

        }
        // public ActionResult Teste()
        // {
        //     try
        //     {
        //         int? id = HttpContext.Session.GetInt32("id") as int?;
        //         if(id == null)
        //         {
        //             return RedirectToAction("Login", "Responsavel");
        //         }
        //          return View();
                
        //     }
        //     catch
        //     {
        //         return RedirectToAction("Home","Login");

        //     }
        //     finally
        //     {
        //         Dispose();

        //     }        
        // }
    }
}