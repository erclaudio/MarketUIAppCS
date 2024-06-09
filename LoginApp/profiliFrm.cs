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
    public partial class profiliFrm : Form
    {
        public profiliFrm()
        {
            InitializeComponent();
            Ausiliare.DataGridViewStyle(this.dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void profiliFrm_Load(object sender, EventArgs e)
        {
            var result = DBoperations.GetListaProfili();
            if(string.IsNullOrEmpty(result.Info))
            {
                if (result.ListaProfili.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var row in result.ListaProfili)
                    {
                        dataGridView1.Rows.Add(row.id, row.Tipo, row.Descrzione);
                    }
                    dataGridView1.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show(result.Info, "Lettura Profili", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new manageProfileFrm().Show();
        }

        private void grbSearch_SizeChanged(object sender, EventArgs e)
        {
            grbSearch.Location = new Point((this.Width - grbSearch.Width) / 2, grbSearch.Location.Y);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
