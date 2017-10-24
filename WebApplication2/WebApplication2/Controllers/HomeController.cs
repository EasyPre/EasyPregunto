using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        SessionData session = new SessionData();

        // GET: Home
        public ActionResult Inicio()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            session.terminarSession();
            return View();
        }
        [AllowAnonymous]
        public ActionResult Usuarios()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Usuarios(UsuarioVO Datos) // Aca creo un objeto de la clase VO
        {


            if (ModelState.IsValid)
            {
                if (Datos.login() == true) //instancion el objeto Datos e invoco el metodo login
                {
                    session.SetSession("NombreUsuario", Datos.Alias_Usuario); // se instancia el objeto de la clase SessionData y el metodo asociado
                    Session["usuarioconectado"] = Datos.Alias_Usuario;
                    Session["IdUsuarioActivo"] = Datos.IdUsuarioActivo;
                    ViewBag.usuario = session.GetSession("NombreUsuario");
                    return View();
                }
                else
                {
                    ViewBag.Message = "Error";
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [AllowAnonymous] // metodo de registrarse normal
        public ActionResult Registrase()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Registrase(RegistrarseVO datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.Registrarse() == false)
                {
                    ViewBag.Message = "El Usuario o Email ya se encuentran registrados";
                    return View("Registrase", datos);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("Registrase");
            }
        }

        public ActionResult Legal()
        {
            return View();
        }


    }
}