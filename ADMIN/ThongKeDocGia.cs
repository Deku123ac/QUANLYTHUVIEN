using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADMIN
{
    public partial class ThongKeDocGia : Form
    {   
        public SqlConnection conn = new SqlConnection();
        Ham ham = new Ham();    
        public ThongKeDocGia()
        {
            InitializeComponent();
        }

        private void ThongKeDocGia_Load(object sender, EventArgs e)
        {
            ham.KetNoi(conn);
            tuychon.Text = "Tất cả sách";
            ham.HienThiDuLieuDG(luoi, "select a.DOCGIA_MA,a.DOCGIA_TEN,a.DOCGIA_NAMSINH,a.sdt,a.diachi from" +
                " docgia a , PHIEUMUON b, CHITIETMUON c where a.DOCGIA_MA = b.DOCGIA_MA and b.PHIEUMUON_MA = c.PHIEUMUON_MA ", conn);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tuychon.Text == "Tất cả độc giả")
                ham.HienThiDuLieuDG(luoi, "select a.DOCGIA_MA,a.DOCGIA_TEN,a.DOCGIA_NAMSINH,a.sdt,a.diachi from" +
                " docgia a , PHIEUMUON b, CHITIETMUON c where a.DOCGIA_MA = b.DOCGIA_MA and b.PHIEUMUON_MA = c.PHIEUMUON_MA ", conn);
            else if (tuychon.Text == "Độc giả đã đang mượn sách")
                ham.HienThiDuLieuDG(luoi, "select a.DOCGIA_MA,a.DOCGIA_TEN,a.DOCGIA_NAMSINH,a.sdt,a.diachi from" +
               " docgia a , PHIEUMUON b, CHITIETMUON c where a.DOCGIA_MA = b.DOCGIA_MA and b.PHIEUMUON_MA = c.PHIEUMUON_MA and c.CHITIETMUON_NGAYTRA > GETDATE()", conn);
            else if (tuychon.Text == "Độc giả đã trả sách")
                ham.HienThiDuLieuDG(luoi, "select a.DOCGIA_MA,a.DOCGIA_TEN,a.DOCGIA_NAMSINH,a.sdt,a.diachi from" +
               " docgia a , PHIEUMUON b, CHITIETMUON c where a.DOCGIA_MA = b.DOCGIA_MA and b.PHIEUMUON_MA = c.PHIEUMUON_MA and c.CHITIETMUON_NGAYTRA < GETDATE()", conn);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
