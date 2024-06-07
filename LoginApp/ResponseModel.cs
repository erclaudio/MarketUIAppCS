using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp
{
    public class ResponseModel
    {
        public class Response_Profili
        {
            public List<Modelli.Profilo>  ListaProfili { get; set; }
            public string Info { get; set; }
        }
        public class Response_Utenti
        {
            public List<Modelli.Utente> ListaUtenti { get; set; }
            public string Info { get; set; }
        }
    }
}
