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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADMIN
{
    public partial class PhieuMuon : Form
    {
        Ham ham = new Ham();
        public SqlConnection conn = new SqlConnection();
        public PhieuMuon()
        {
            InitializeComponent();
        }

        private void PhieuMuon_Load(object sender, EventArgs e)
        {
            ham.KetNoi(conn);
            ham.HienThiDuLieuDG(dataGridView1, "select a.PHIEUMUON_MA,a.DOCGIA_MA,b.DOCGIA_TEN ,d.SACH_MA,d.SACH_TENSACH, a.NGAYMUON ,c.CHITIETMUON_NGAYTRA from PHIEUMUON a,DOCGIA b , CHITIETMUON c, sach d where a.DOCGIA_MA = b.DOCGIA_MA and c.PHIEUMUON_MA = a.PHIEUMUON_MA and c.SACH_MA = d.SACH_MA", conn);
            ham.LoadComboBox(comboBox1, "select docgia_ma from DOCGIA ", conn, "docgia_ma", "docgia_ma");
            ham.LoadComboBox(comboBox2, "select thuthu_ma from thuthu ", conn, "thuthu_ma", "thuthu_ma");
            ham.LoadComboBox(comboBox3, "select   a.SACH_MA,a.SACH_TENSACH from SACH a", conn, "SACH_TENSACH", "SACH_MA");
          
        }

        private void Them_Click(object sender, EventArgs e)
        {

            string mp = maphieu.Text;
             string mdg = comboBox1.SelectedValue.ToString();
            
            string ms = comboBox3.SelectedValue.ToString();
            string tt = comboBox2.SelectedValue.ToString();
            string ngayhientai = DateTime.Now.ToString("yyyy-MM-dd");
            string ngaytra = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            string sql_themphieumuon = "insert into PHIEUMUON (DOCGIA_MA,PHIEUMUON_MA,NGAYMUON,thuthu_ma) " +
                                        "values('"+ mdg + "','"+ mp + "','"+ ngayhientai + "','"+ tt + "')";

            string sql_chitietmuon = "INSERT into chitietmuon (Sach_ma,phieumuon_ma,chitietmuon_ngaytra)" +
                                        "values ('"+ ms + "','"+ mp + "','"+ ngaytra + "')";

            SqlCommand comd = new SqlCommand(sql_themphieumuon, conn);
            SqlCommand cmd = new SqlCommand(sql_chitietmuon, conn);
            cmd.ExecuteNonQuery();
            comd.ExecuteNonQuery();
            ham.capnhat("select a.PHIEUMUON_MA,a.DOCGIA_MA,b.DOCGIA_TEN ,d.SACH_MA,d.SACH_TENSACH, a.NGAYMUON ,c.CHITIETMUON_NGAYTRA from PHIEUMUON a,DOCGIA b , CHITIETMUON c, sach d where a.DOCGIA_MA = b.DOCGIA_MA and c.PHIEUMUON_MA = a.PHIEUMUON_MA and c.SACH_MA = d.SACH_MA", conn);

            ham.HienThiDuLieuDG(dataGridView1, "select a.PHIEUMUON_MA,a.DOCGIA_MA,b.DOCGIA_TEN ,d.SACH_MA,d.SACH_TENSACH, a.NGAYMUON ,c.CHITIETMUON_NGAYTRA from PHIEUMUON a,DOCGIA b , CHITIETMUON c, sach d where a.DOCGIA_MA = b.DOCGIA_MA and c.PHIEUMUON_MA = a.PHIEUMUON_MA and c.SACH_MA = d.SACH_MA", conn);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void madocgia_TextChanged(object sender, EventArgs e)
        {

        }

        private void them_Click_1(object sender, EventArgs e)
        {
            them.Enabled = true;
            sua.Enabled = false;
            string sql_max = "SELECT MAX(SUBSTRING(PHIEUMUON_MA,3,3)) FROM PHIEUMUON";
            SqlCommand comd = new SqlCommand(sql_max, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {

                int max = Convert.ToInt16(reader.GetValue(0).ToString()) + 1;
                if (max < 10)
                {
                    maphieu.Text = "PM00" + max;
                }
                else if (max < 100)
                {
                    maphieu.Text = "PM0" + max;
                }
                else
                {
                    maphieu.Text = "PM" + max;
                }
                maphieu.Enabled = false;

            }
            reader.Close();
            
            comboBox1.Text = "Chọn độc giả";
            comboBox3.Text = "Chọn sách";
            comboBox2.Text = "Chọn người lập phiếu";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maphieu.Enabled = false;
            maphieu.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

        }

        private void sua_Click(object sender, EventArgs e)
        {
            maphieu.Enabled = false;
            string mp = maphieu.Text;
            string mdg = comboBox1.SelectedValue.ToString();

            string ms = comboBox3.SelectedValue.ToString();
            string tt = comboBox2.SelectedValue.ToString();
            string ngayhientai = DateTime.Now.ToString("yyyy-MM-dd");
            string ngaytra = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            // Câu lệnh cập nhật thông tin phiếu mượn
            string sql_capnhatphieumuon = "UPDATE PHIEUMUON SET NGAYMUON = '" + ngayhientai + "', thuthu_ma = '" + tt + "',docgia_ma ='"+ mdg + "' WHERE PHIEUMUON_MA = '" + mp + "'";

            // Câu lệnh cập nhật thông tin chi tiết mượn
            string sql_capnhatchitietmuon = "UPDATE CHITIETMUON SET CHITIETMUON_NGAYTRA = '" + ngaytra + "',sach_ma = '"+ ms + "' WHERE  PHIEUMUON_MA = '" + mp + "'";

            // Thực hiện câu lệnh cập nhật cho phiếu mượn
            SqlCommand comdCapNhatPhieuMuon = new SqlCommand(sql_capnhatphieumuon, conn);
            comdCapNhatPhieuMuon.ExecuteNonQuery();

            // Thực hiện câu lệnh cập nhật cho chi tiết mượn
            SqlCommand comdCapNhatChiTietMuon = new SqlCommand(sql_capnhatchitietmuon, conn);
            comdCapNhatChiTietMuon.ExecuteNonQuery();


            ham.capnhat(sql_capnhatchitietmuon, conn);
            ham.capnhat(sql_capnhatphieumuon, conn);

    

            ham.HienThiDuLieuDG(dataGridView1, "select a.PHIEUMUON_MA,a.DOCGIA_MA,b.DOCGIA_TEN ,d.SACH_MA,d.SACH_TENSACH, a.NGAYMUON ,c.CHITIETMUON_NGAYTRA from PHIEUMUON a,DOCGIA b , CHITIETMUON c, sach d where a.DOCGIA_MA = b.DOCGIA_MA and c.PHIEUMUON_MA = a.PHIEUMUON_MA and c.SACH_MA = d.SACH_MA", conn);
        }
        private void xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu mượn này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string mp = maphieu.Text;

                // Câu lệnh xóa phiếu mượn
                string sql_xoaphieumuon = "DELETE FROM PHIEUMUON WHERE PHIEUMUON_MA = '" + mp + "'";

                // Câu lệnh xóa chi tiết mượn
                string sql_xoachitietmuon = "DELETE FROM CHITIETMUON WHERE PHIEUMUON_MA = '" + mp + "'";

                // Thực hiện câu lệnh xóa cho phiếu mượn
                SqlCommand comdXoaPhieuMuon = new SqlCommand(sql_xoaphieumuon, conn);
                comdXoaPhieuMuon.ExecuteNonQuery();

                // Thực hiện câu lệnh xóa cho chi tiết mượn
                SqlCommand comdXoaChiTietMuon = new SqlCommand(sql_xoachitietmuon, conn);
                comdXoaChiTietMuon.ExecuteNonQuery();

                ham.HienThiDuLieuDG(dataGridView1, "select a.PHIEUMUON_MA,a.DOCGIA_MA,b.DOCGIA_TEN ,d.SACH_MA,d.SACH_TENSACH, a.NGAYMUON ,c.CHITIETMUON_NGAYTRA from PHIEUMUON a,DOCGIA b , CHITIETMUON c, sach d where a.DOCGIA_MA = b.DOCGIA_MA and c.PHIEUMUON_MA = a.PHIEUMUON_MA and c.SACH_MA = d.SACH_MA", conn);

                // Xóa dữ liệu trên giao diện người dùng sau khi xóa thành công
                maphieu.Text = "";
                comboBox1.Text = "Chọn độc giả";
                comboBox3.Text = "Chọn sách";
                comboBox2.Text = "Chọn người lập phiếu";
            }
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            ham.HienThiDuLieuDG(dataGridView1, "select a.PHIEUMUON_MA,a.DOCGIA_MA,b.DOCGIA_TEN ,d.SACH_MA,d.SACH_TENSACH, a.NGAYMUON ,c.CHITIETMUON_NGAYTRA from PHIEUMUON a,DOCGIA b , CHITIETMUON c, sach d where a.DOCGIA_MA = b.DOCGIA_MA and c.PHIEUMUON_MA = a.PHIEUMUON_MA and c.SACH_MA = d.SACH_MA", conn);
        }

        private void masach_TextChanged(object sender, EventArgs e)
        {









































        }
    }
}
