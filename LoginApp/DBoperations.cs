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
using System.Reflection;

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
        }

        public static void CreateProfile(Modelli.Profilo profilo, out string info)
        {            
            info = string.Empty ;
            try
            {
                if (File.Exists(pathProfili))
                {
                    string infoListaProfili = File.ReadAllText(pathProfili);
                    var letturaFile = JsonConvert.DeserializeObject<List<Modelli.Profilo>>(infoListaProfili);                    

                    var exists = letturaFile.Exists(lf => lf.Tipo.ToLower() == profilo.Tipo.ToLower());
                    if (exists)
                    {
                        info = $"Profile Already Exists of Type{profilo.Tipo} ";
                    }
                    else
                    {
                        letturaFile.Add(profilo);
                        using (StreamWriter sw = new StreamWriter(pathProfili, false))
                        {
                            sw.WriteLine(JsonConvert.SerializeObject(letturaFile));
                            sw.Close();
                        }
                    }                  
                    
                }
                
                else
                {
                    File.Create(pathProfili).Close();
                    List<Modelli.Profilo> listaProfili = new List<Modelli.Profilo>();
                    listaProfili.Add(profilo);
                    using (StreamWriter sw = new StreamWriter(pathProfili, false))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(listaProfili));
                        sw.Close();
                    }                    
                }                
            }
            catch (Exception ex)
            {
               info = $"Errore: {ex.Message}\n {ex.StackTrace}";
                
            }            
        }

        public static int GetIdProfili()
        {
            int Id = 0;
            if (File.Exists(pathProfili))
            {
                string infoListaProfili = File.ReadAllText(pathProfili);
                List<Modelli.Profilo> lista = JsonConvert.DeserializeObject<List<Modelli.Profilo>>(infoListaProfili);
                Id = lista.Max(l => l.ID + 1);
            }
            return Id + 1;
        }

        #endregion
        //#region Utenti       
        //public static ResponseModel.Response_Utenti GetListaUtenti()
        //{
        //    ResponseModel.Response_Profili responseProfili = new ResponseModel.Response_Profili();
        //    try
        //    {
        //        if (File.Exists(pathProfili))
        //        {
        //            string infoListaProfili = File.ReadAllText(pathProfili);
        //            responseProfili.ListaProfili = JsonConvert.DeserializeObject<List<Modelli.Profilo>>(infoListaProfili);
        //            responseProfili.Info = string.Empty;

        //        }
        //        else
        //        {
        //            responseProfili.ListaProfili = null;
        //            responseProfili.Info = "Non Esiste nessun profilo ...";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //MessageBox.Show(string.Format("Attenzione: {0}\n{1}",e.Message, e.StackTrace), "Errore di lettura", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        responseProfili.ListaProfili = new List<Modelli.Profilo>();
        //        responseProfili.Info = e.Message + "\n" + e.StackTrace;
        //    }
        //    return responseProfili;

        //}
        //#endregion
    }
}
