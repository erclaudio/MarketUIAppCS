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
    public partial class dashboardFrm : Form
    {
        public dashboardFrm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            new loginFrm().Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void topPnl_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void slogan_Click(object sender, EventArgs e)
        {

        }

        private void dashboardFrm_SizeChanged(object sender, EventArgs e)
        {
            this.sloganLbl.Location = new Point((this.topPnl.Width-this.sloganLbl.Width)/2, this.sloganLbl.Location.Y);
            this.copyrightLbl.Location = new Point((this.bottomPnl.Width - this.copyrightLbl.Width) / 2, this.copyrightLbl.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ausiliare.loadForm(new adminFrm(), formPnl);;
        }
    }
}
