using AppDatabaseDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var metodosUsuario = new UsuarioDAO();
            var TodosUsuarios = metodosUsuario.Select();
            return View(TodosUsuarios);
        }


    }
}