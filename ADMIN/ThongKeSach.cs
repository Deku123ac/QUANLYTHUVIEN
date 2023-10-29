using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMIN
{
    public partial class ThongKeSach : Form

    {
        Ham ham = new Ham();
        public SqlConnection conn = new SqlConnection();
        public ThongKeSach()
        {
            InitializeComponent();
        }

        private void ThongKeSach_Load(object sender, EventArgs e)
        {
            ham.KetNoi(conn);
            comboBox1.Text = "Tất cả sách";
            ham.HienThiDuLieuDG(dataGridView1, "SELECT A.SACH_MA,A.LOAISACH_MA,A.SACH_TENSACH,A.SACH_NXB,A.SACH_TENTG FROM SACH A,CHITIETMUON B WHERE A.SACH_MA = B.SACH_MA", conn);
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Tất cả sách")
                ham.HienThiDuLieuDG(dataGridView1, "SELECT A.SACH_MA,A.LOAISACH_MA,A.SACH_TENSACH,A.SACH_NXB,A.SACH_TENTG FROM SACH A,CHITIETMUON B WHERE A.SACH_MA = B.SACH_MA", conn);
            else if (comboBox1.Text == "Sách đang mượn")
                ham.HienThiDuLieuDG(dataGridView1, "SELECT A.SACH_MA,A.LOAISACH_MA,A.SACH_TENSACH,A.SACH_NXB,A.SACH_TENTG FROM SACH A,CHITIETMUON B WHERE A.SACH_MA = B.SACH_MA AND B.CHITIETMUON_NGAYTRA < GETDATE()", conn);
            else if(comboBox1.Text == "Sách đã trả")
                ham.HienThiDuLieuDG(dataGridView1, "SELECT A.SACH_MA,A.LOAISACH_MA,A.SACH_TENSACH,A.SACH_NXB,A.SACH_TENTG FROM SACH A,CHITIETMUON B WHERE A.SACH_MA = B.SACH_MA AND B.CHITIETMUON_NGAYTRA > GETDATE()", conn);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
