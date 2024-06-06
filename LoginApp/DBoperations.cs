using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using System.Globalization;

namespace LoginApp
{
    internal class DBoperations
    {
        static string pathProfili = AppDomain.CurrentDomain.BaseDirectory + @"\Database\Profili.json";

        #region Profili
        public static ResponseModel.Response_Profili GetListaProfili(out string Info )
        {
            ResponseModel.Response_Profili responseProfili = new ResponseModel.Response_Profili();
            try
            {
                if(File.Exists(pathProfili))
                {
                    string infoListaProfili = File.ReadAllText(pathProfili);
                    responseProfili.ListaProfili = JsonConvert.DeserializeObject<List<Modelli.Profilo>>(infoListaProfili);
                    
                }
                else
                {
                    responseProfili.ListaProfili = null;
                    responseProfili.Info = "Non Esiste nessun profilo ...";
                }
            }
            catch (Exception e)
            {
                responseProfili.
                MessageBox.Show(string.Format("Attenzione: {0}\n{1}",e.Message, e.StackTrace), "Errore di lettura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            return listaProfili;
        }        
        #endregion
    }
}
