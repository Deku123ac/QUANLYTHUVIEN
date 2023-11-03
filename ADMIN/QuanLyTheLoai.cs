using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ADMIN
{
    public partial class QuanLyTheLoai : Form
    {
        public SqlConnection conn = new SqlConnection();
        Ham ham = new Ham();


        public QuanLyTheLoai()
        {
            InitializeComponent();
            btnLuu.Enabled = false;
        }

        private void QuanLyTheLoai_Load(object sender, EventArgs e)
        {
            ham.KetNoi(conn);
            ham.HienThiDuLieuDG(dgwTheloai, "SELECT * FROM LOAISACH", conn);
        }


        

       

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string matheloai = txtMatheloai.Text;
            string tentheloai = txtTentheloai.Text;

            if (tentheloai != "")
            {
                string sql_them = "INSERT INTO loaisach VALUES ('" + matheloai + "',N'" + tentheloai + "')";
                MessageBox.Show(sql_them);
                ham.capnhat(sql_them, conn);
                ham.HienThiDuLieuDG(dgwTheloai, "SELECT * FROM LOAISACH", conn);
            }

            btnSua.Enabled = true;
        }

      


        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;

            string sql_max = "SELECT MAX(SUBSTRING (LOAISACH_MA,3,3)) FROM loaisach;";

            SqlCommand comd = new SqlCommand(sql_max, conn);

            SqlDataReader reader = comd.ExecuteReader();


            if (reader.Read())//If reader có dữ liệu
            {
                int max = Convert.ToInt16(reader.GetValue(0).ToString()) + 1;

                if (max >= 100)
                {
                    txtMatheloai.Text = "LS" + max;
                }
                if (max >= 10)
                {
                    txtMatheloai.Text = "LS0" + max;
                }
                else
                {
                    txtMatheloai.Text = "LS00" + max;
                }
                txtMatheloai.Enabled = false;
            }
            txtTentheloai.Text = "";
            reader.Close();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string matheloai = txtMatheloai.Text;
            string tentheloai = txtTentheloai.Text;

            if (tentheloai != "")
            {
                string sql_sua = "update loaisach set loaisach_ten = N'" + tentheloai + "' where loaisach_ma = '" + matheloai + "'";

                ham.capnhat(sql_sua, conn);

                ham.HienThiDuLieuDG(dgwTheloai, "SELECT * FROM LOAISACH", conn);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string matheloai = txtMatheloai.Text;
            string sql_xoa = "delete from LOAISACH where loaisach_ma = '" + matheloai + "';";
            ham.capnhat(sql_xoa, conn);

            ham.HienThiDuLieuDG(dgwTheloai, "SELECT * FROM LOAISACH", conn);
        }

        private void dgwTheloai_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMatheloai.Text = dgwTheloai.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTentheloai.Text = dgwTheloai.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
