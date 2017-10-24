using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class SessionData
    {
        private string Session;

        public string GetSession(string name)
        {
            this.Session = Convert.ToString(HttpContext.Current.Session[name]);

            return Session;
        }
        public void SetSession(String name, String data)
        {
            HttpContext.Current.Session[name] = data;
        }

        public void terminarSession()
        {
            HttpContext.Current.Session.Abandon(); // este termina la session
        }
    }
}