using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    

    public class RegistrarseVO
    {
        

        [Required(ErrorMessage ="El Nombre es requerido")]
        [Display(Name = "Nombres")]

        public string nombre { get; set; }


        [Required(ErrorMessage = "El Apellido es requerido")]
        [Display(Name = "Apellidos")]

        public string apellido { get; set; }

        
        [Required(ErrorMessage = "El Nombre de usuario es requerido")]
        [Display(Name = "Nombre Usuario")]

        public string Nombreusuario { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "El correo electronico es requerido")]
        [Display(Name = "CorreoElectronico")]

        public string CorreoElectronico { get; set; }

        [StringLength(100,ErrorMessage = "El numero de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        [Required(ErrorMessage = "El tipo de documento es requerido")]
        [Display(Name = "Contraseña")]

        public string contraseña { get; set; }


        [Required(ErrorMessage = "La fecha de nacimientos es requerida")]
        [Display(Name = "Fecha de nacimiento")]

        public DateTime fechaNacimiento  { get; set; }


        [Display(Name = "Ciudad de residencia")]

        public string ubicacion { get; set; }



        DataeEasyDataContext usuario = new DataeEasyDataContext();

        Usuario obj = new Usuario();

        public bool Registrarse()
        {
            var consulta = from a in usuario.Usuario
                           where a.Correo_Electronico_Usuario == CorreoElectronico ||
                           a.Alias_Usuario == Nombreusuario
                           select a;
            if (consulta.Count() > 0)
            {
                return false;
            }
            else
            {
                obj.Nombre_Usuario = nombre;
                obj.Apellidos_Usuario = apellido;
                obj.Alias_Usuario = Nombreusuario;
                obj.Correo_Electronico_Usuario = CorreoElectronico;
                obj.Clave_Usuario = contraseña;

                usuario.Usuario.InsertOnSubmit(obj); // insert
                usuario.SubmitChanges();
                return true;
            }
        }

    }
}