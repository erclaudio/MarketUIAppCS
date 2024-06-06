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
    public partial class adminFrm : Form
    {
        public adminFrm()
        {
            InitializeComponent();
            ManageStyleButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ausiliare.loadForm(new profiliFrm(), pnlForm);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void adminFrm_Load(object sender, EventArgs e)
        {

        }
        private void ManageStyleButton()
        { 
            foreach (Control control1 in flpButton.Controls.OfType<Button>()) 
            { 
                var obj1 = (Button) control1;
                
                obj1.Click += delegate
                {
                    foreach (Control control2 in flpButton.Controls.OfType<Button>())
                    {
                        var obj2 = (Button)control2;

                        obj2.BackColor = Color.White;
                        obj2.ForeColor = Color.LightBlue;
                    }
                    obj1.BackColor = Color.LightBlue;
                    obj1.ForeColor = Color.White;
                };
            }
        }

        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
