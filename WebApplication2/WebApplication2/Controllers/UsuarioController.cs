using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UsuarioController : Controller
    {
        DataeEasyDataContext modelo = new DataeEasyDataContext();
        EstadoSessionVO obj = new EstadoSessionVO();

        // GET: Usuario
        public ActionResult MiCuenta()
        {
            return View();
        }
        public ActionResult Matematicas()
        { 
            //Session["IdMateria"] = 
            obj.asiganaMateria(1);
            obj.IdUsuario = (int)Session["IdUsuarioActivo"];
            obj.RegistroUsuarioAndMateria();
            return View();
        }




    }
}