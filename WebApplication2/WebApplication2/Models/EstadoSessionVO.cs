using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class EstadoSessionVO
    {
        public String Estado { get; set; }
        public int IdUsuario { get; set; }
        public int IdTutor { get; set; }
        public int Materia { get; set; }

        public EstadoSessionVO()
        {
            
        }

        DataeEasyDataContext modelo = new DataeEasyDataContext();
        Estado_Sesion obj = new Estado_Sesion();

        public bool RegistroUsuarioAndMateria()
        {
            obj.Estado = "Validación";
            obj.Usuario = IdUsuario;
            obj.idarea = Materia;

            modelo.Estado_Sesion.InsertOnSubmit(obj);
            modelo.SubmitChanges();

            return true;
        }


        public int asiganaMateria(int materia)
        {
            Materia = materia;
            SessionData session = new SessionData();
            return Materia;
        }


    }
}