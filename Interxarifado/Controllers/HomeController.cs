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
    }
}