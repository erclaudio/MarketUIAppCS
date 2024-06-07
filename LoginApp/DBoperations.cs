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
        static string pathUtenti = AppDomain.CurrentDomain.BaseDirectory + @"\Database\Utenti.json";
        #region Profili
        public static ResponseModel.Response_Profili GetListaProfili()
        {
            ResponseModel.Response_Profili responseProfili = new ResponseModel.Response_Profili();
            try
            {
                if(File.Exists(pathProfili))
                {
                    string infoListaProfili = File.ReadAllText(pathProfili);
                    responseProfili.ListaProfili = JsonConvert.DeserializeObject<List<Modelli.Profilo>>(infoListaProfili);
                    responseProfili.Info = string.Empty;                    
                    
                }
                else
                {
                    responseProfili.ListaProfili = null;
                    responseProfili.Info = "Non Esiste nessun profilo ...";
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(string.Format("Attenzione: {0}\n{1}",e.Message, e.StackTrace), "Errore di lettura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                responseProfili.ListaProfili = new List<Modelli.Profilo>();
                responseProfili.Info = e.Message + "\n" + e.StackTrace;
            }
            return responseProfili;
        }
        #endregion
        #region Utenti
        public static ResponseModel.Response_Utenti GetListaUtenti()
        {
            ResponseModel.Response_Profili responseProfili = new ResponseModel.Response_Profili();
            try
            {
                if (File.Exists(pathProfili))
                {
                    string infoListaProfili = File.ReadAllText(pathProfili);
                    responseProfili.ListaProfili = JsonConvert.DeserializeObject<List<Modelli.Profilo>>(infoListaProfili);
                    responseProfili.Info = string.Empty;

                }
                else
                {
                    responseProfili.ListaProfili = null;
                    responseProfili.Info = "Non Esiste nessun profilo ...";
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(string.Format("Attenzione: {0}\n{1}",e.Message, e.StackTrace), "Errore di lettura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                responseProfili.ListaProfili = new List<Modelli.Profilo>();
                responseProfili.Info = e.Message + "\n" + e.StackTrace;
            }
            return responseProfili;

            #endregion
        }
}
