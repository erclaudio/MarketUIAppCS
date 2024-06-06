using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    internal class Ausiliare
    {
        public static void loadForm(Form frm, Panel pnl)
        {
            foreach (Control ctrl in pnl.Controls.OfType<Form>())
            {
                pnl.Controls.Remove(ctrl);
            }
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            pnl.Controls.Add(frm);
            frm.Show();
           
        }

        public static void DataGridViewStyle(DataGridView grid) {
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkTurquoise;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            grid.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable; 
            }
        }
}
}
