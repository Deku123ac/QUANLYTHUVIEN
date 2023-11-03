using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void thốngKêSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongKeSach TK = new ThongKeSach();
            TK.Show();
        }

        private void thốngKêĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongKeDocGia TK = new ThongKeDocGia();
            TK.Show();
        }

        private void tìmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimkiemSach TK = new TimkiemSach();
            TK.Show();
        }

        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLySach QLSACH = new QuanLySach();
            QLSACH.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void trảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTraSach PT = new FormTraSach();
            PT.Show();
        }

        private void mượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhieuMuon PM = new PhieuMuon();
            PM.Show();
        }

        private void danhMụcSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTheLoai qltl = new QuanLyTheLoai();
            qltl.Show();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTroGiup gt = new FormTroGiup();
            gt.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocGia dg = new DocGia();   
            dg.Show();
        }
    }
}
