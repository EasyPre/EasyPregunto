using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class UsuarioVO
    {
        [EmailAddress]
        [Required(ErrorMessage = "El correo electronico es requerido")]
        [Display(Name = "CorreoElectronico")]

        public string Correo_Electronico_Usuario { get; set; }

        
        [StringLength(100,ErrorMessage = "El numero de caracteres de contraseña debe ser al menos 100.</font>",MinimumLength =3)]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]

        public string Clave_Usuario { get; set; }



        public string Alias_Usuario { get; set; }
        public int IdUsuarioActivo { get; set; }

        DataeEasyDataContext usuario = new DataeEasyDataContext(); // se instancia un objeto de la clase linq mejor dicho de la base de datos

        public bool login() // Se crea un metodo que retorne un booleano
        {
            // esta es la consulta que valida
            var consultaLogin = from a in usuario.Usuario
                           where a.Correo_Electronico_Usuario == Correo_Electronico_Usuario && a.Clave_Usuario == Clave_Usuario
                           select a;

            if (consultaLogin.Count() > 0)
            {
                //var consultaLogin2 = from a in usuario.Usuario
                                     //where a.Correo_Electronico_Usuario == Correo_Electronico_Usuario
                                     //select a;
                var datos = consultaLogin.ToList();
                foreach (var Data in datos)
                {
                    Alias_Usuario = Data.Alias_Usuario;
                    IdUsuarioActivo = Data.Id_Usuario;

                }
                return true;
            }
            else
            {
                return false;
            }
        }





    }
}