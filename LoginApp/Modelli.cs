using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp
{
    public class Modelli
    {
        public class Profilo
        {
            public int ID { get; set; }
            public string Tipo { get; set; }
            public string Descrzione { get; set; }
        }
        public class Utente
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public string Utenza { get; set; }
            public string Passaparole { get; set; }
            public int Profilo { get; set; }
            public bool Attivo { get; set; }
        }
    }
}
