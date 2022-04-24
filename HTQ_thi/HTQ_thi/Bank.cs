using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQ_thi
{
    public partial class Bank : Form
    {
        public Bank()
        {
            InitializeComponent();
        }

        private void quanLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanly ql = new Quanly();
            this.Hide();
            ql.ShowDialog();
            this.Show();
        }

        private void giaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giaodich gd = new Giaodich();
            this.Hide();
            gd.ShowDialog();
            this.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhanvien nv = new nhanvien();
            this.Hide();
            nv.ShowDialog();
            this.Show();
        }

      

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongke tk = new thongke();
            this.Hide();
            tk.ShowDialog();
            this.Show();
        }

        private void Bank_Load(object sender, EventArgs e)
        {

        }
    }
}
