using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class manageProfileFrm : Form
    {
        profiliFrm Frm;
        int Action, Id;
        string Tipo, Descrizione;
        public manageProfileFrm( profiliFrm frm, int action, string tipo, string descrizione, int id)
        {
            InitializeComponent();
            Frm = frm; 
            Action = action;
            Id = id;
            Tipo = tipo;
            Descrizione = descrizione;
        }
        private void onLoad()
        {
            switch ( Action )
            {
                case 1:
                    manageProfileBtn.Text = "Create Profile";
                    ManageProfileLbl.Text = "Create Profile";
                    manageProfileBtn.BackColor = Color.FromArgb(0, 192, 192);
                    break;
            }
        }
        private void onAction()
        {
            switch( Action )
            {
                case 1:
                    CreateProfile();
                break;
            }
        }
        private void CreateProfile()
        {
            try
            {
                Modelli.Profilo profilo = new Modelli.Profilo
                {
                    Tipo = txbType.Text,
                    Descrzione = txbDesc.Text,
                    ID = DBoperations.GetIdProfili()
                };
                string info;
                DBoperations.CreateProfile( profilo, out info );
                if(!string.IsNullOrEmpty( info ) )
                {
                    MessageBox.Show(info, "Error while creating profile", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message +"\n"+ ex.StackTrace), "Error Creating Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                txbDesc.Clear();
                txbType.Clear();
                Frm.ReadData();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           onAction();

                   
        }

        private void manageProfileFrm_Load(object sender, EventArgs e)
        {
            onLoad();
        }
    }
}
