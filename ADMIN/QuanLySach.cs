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

namespace ADMIN
{
    public partial class QuanLySach : Form
    {
        public SqlConnection conn = new SqlConnection();
        Ham ham = new Ham();
        public QuanLySach()
        {
            InitializeComponent();
        }

        private void QuanLySach_Load(object sender, EventArgs e)
        {
            ham.KetNoi(conn);
            ham.HienThiDuLieuDG(luoi, "select a.SACH_MA,a.SACH_TENSACH,a.SACH_NXB,a.SACH_TENTG,a.LOAISACH_MA,b.LOAISACH_TEN,b.LOAISACH_MA from" +
                " sach a,LOAISACH b where a.LOAISACH_MA = b.LOAISACH_MA", conn);
            ham.LoadComboBox(comtheloai, "select loaisach_ma , loaisach_ten from loaisach", conn, "loaisach_ten", "loaisach_ma");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string tukhoa = txttimkiem.Text;


            string searchtheoten = "select a.SACH_MA,a.SACH_TENSACH,a.SACH_NXB,a.SACH_TENTG,a.LOAISACH_MA,b.LOAISACH_TEN,b.LOAISACH_MA from sach a,LOAISACH b where a.LOAISACH_MA = b.LOAISACH_MA" +
                " and ( a.sach_tensach like N'%" + tukhoa + "%')";

            string searchtheoma = "select a.SACH_MA,a.SACH_TENSACH,a.SACH_NXB,a.SACH_TENTG,a.LOAISACH_MA,b.LOAISACH_TEN,b.LOAISACH_MA from sach a,LOAISACH b where a.LOAISACH_MA = b.LOAISACH_MA" +
               " and (a.sach_ma like N'%" + tukhoa + "%' )";
            if (tensach.Checked == true)
            {
                ham.HienThiDuLieuDG(luoi, searchtheoten, conn);
            }
            else if (masach.Checked == true)
            {
                ham.HienThiDuLieuDG(luoi, searchtheoma, conn);
            }
        }

        private void them_Click(object sender, EventArgs e)
        {
            them.Enabled = true;
            sua.Enabled = false;

            string sql_max = "SELECT MAX(CAST(SUBSTRING(SACH_MA, 2, 3) AS INT)) FROM SACH";
            SqlCommand comd = new SqlCommand(sql_max, conn);
            SqlDataReader reader = comd.ExecuteReader();

            if (reader.Read())
            {
                int max = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader[0]);
                int nextValue = max + 1;

                if (nextValue < 10)
                {
                    txtmasach.Text = "S00" + nextValue;
                }
                else if (nextValue < 100)
                {
                    txtmasach.Text = "S0" + nextValue;
                }
                else
                {
                    txtmasach.Text = "S" + nextValue;
                }
                txtmasach.Enabled = false;
            }
            reader.Close();

            txttensach.Text = "";
            comtheloai.Text = "Chọn thể loại";
            tennhaxb.Text = "";
            tentacgia.Text = "";
        }

        private void luu_Click(object sender, EventArgs e)
        {
            string masach = txtmasach.Text;
            string tensach = txttensach.Text;
            string tenNXB = tennhaxb.Text;
            string tenTG = tentacgia.Text;
            string theloai = comtheloai.SelectedValue.ToString();

            if (String.IsNullOrEmpty(masach))
            {
                MessageBox.Show("Bạn chưa nhập mã hàng!!");
            }
            else
            {
                string sql_Them = "INSERT INTO SACH (SACH_MA, SACH_TENSACH, SACH_TENTG, LOAISACH_MA, SACH_NXB) VALUES (@masach, @tensach, @tenTG, @theloai, @tenNXB)";

                SqlCommand cmd = new SqlCommand(sql_Them, conn);
                cmd.Parameters.AddWithValue("@masach", masach);
                cmd.Parameters.AddWithValue("@tensach", tensach);
                cmd.Parameters.AddWithValue("@tenTG", tenTG);
                cmd.Parameters.AddWithValue("@theloai", theloai);
                cmd.Parameters.AddWithValue("@tenNXB", tenNXB);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data saved successfully.");
                    ham.HienThiDuLieuDG(luoi, "select a.SACH_MA,a.SACH_TENSACH,a.SACH_NXB,a.SACH_TENTG,a.LOAISACH_MA,b.LOAISACH_TEN,b.LOAISACH_MA from sach a,LOAISACH b where a.LOAISACH_MA = b.LOAISACH_MA", conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmasach.Text))
            {
                string masach = txtmasach.Text;

                // Xác nhận việc xóa với người dùng (tùy chọn)
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sách này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Thực hiện câu lệnh xóa thông tin sách
                    string sql_xoa_sach = "DELETE FROM SACH WHERE SACH_MA = @masach";
                    SqlCommand cmd = new SqlCommand(sql_xoa_sach, conn);
                    cmd.Parameters.AddWithValue("@masach", masach);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sách đã được xóa thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa sách có mã: " + masach);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }

                    // Sau khi xóa, làm sạch dữ liệu trên giao diện
                    txtmasach.Text = "";
                    txttensach.Text = "";
                    tennhaxb.Text = "";
                    tentacgia.Text = "";
                    comtheloai.Text = "Chọn thể loại";

                    // Cập nhật lại dữ liệu trên DataGridView
                    ham.HienThiDuLieuDG(luoi, "select a.SACH_MA,a.SACH_TENSACH,a.SACH_NXB,a.SACH_TENTG,a.LOAISACH_MA,b.LOAISACH_TEN,b.LOAISACH_MA from sach a,LOAISACH b where a.LOAISACH_MA = b.LOAISACH_MA", conn);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sách để xóa.");
            }
        }


        private void sua_Click(object sender, EventArgs e)
        {
            string masach = txtmasach.Text;
            string tensach = txttensach.Text;
            string tenNXB = tennhaxb.Text;
            string tenTG = tentacgia.Text;
            string theloai = comtheloai.SelectedValue.ToString();

            string sqlUpdate = "update sach set sach_tensach = N'"+ tensach + "',loaisach_ma = '"+ theloai + "',sach_nxb ='"+ tenNXB + "',sach_tentg ='"+ tenTG + "'WHERE sach_ma = '" + masach + "'";


            ham.capnhat(sqlUpdate, conn);
            ham.HienThiDuLieuDG(luoi, "select a.SACH_MA,a.SACH_TENSACH,a.SACH_NXB,a.SACH_TENTG,a.LOAISACH_MA,b.LOAISACH_TEN,b.LOAISACH_MA from sach a,LOAISACH b where a.LOAISACH_MA = b.LOAISACH_MA", conn);

        }

        private void luoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtmasach.Text = luoi.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttensach.Text = luoi.Rows[e.RowIndex].Cells[1].Value.ToString();
            tennhaxb.Text = luoi.Rows[e.RowIndex].Cells[2].Value.ToString();
            tentacgia.Text = luoi.Rows[e.RowIndex].Cells[3].Value.ToString();
           
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
