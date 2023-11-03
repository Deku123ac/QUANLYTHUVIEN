using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ADMIN
{
    public partial class DocGia : Form
    {
        public SqlConnection conn = new SqlConnection();
        Ham ham = new Ham();
        public DocGia()
        {
            InitializeComponent();
        }

        private void DocGia_Load(object sender, EventArgs e)
        {
            ham.KetNoi(conn);
            ham.HienThiDuLieuDG(luoi, "select * from docgia", conn);

        }

        private void them_Click(object sender, EventArgs e)
        {
            them.Enabled = true;
            luu.Enabled = true;
            sua.Enabled = false;
            string sql_max = "SELECT MAX(SUBSTRING (docgia_ma,3,3)) FROM docgia;";

            SqlCommand comd = new SqlCommand(sql_max, conn);

            SqlDataReader reader = comd.ExecuteReader();


            if (reader.Read())//If reader có dữ liệu
            {
                int max = Convert.ToInt16(reader.GetValue(0).ToString()) + 1;

                if (max >= 100)
                {
                    txtmadocgia.Text = "DG" + max;
                }
                if (max >= 10)
                {
                    txtmadocgia.Text = "DG0" + max;
                }
                else
                {
                    txtmadocgia.Text = "DG00" + max;
                }
                txtmadocgia.Enabled = false;
            }
            
            reader.Close();
        }

        private void sua_Click(object sender, EventArgs e)
        {
            string MADG = txtmadocgia.Text;
            string TENDG = txttendocgia.Text;
            string phone = textBox1.Text;
            string dc = txtdiachi.Text;
            string ns = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            string sqlUpdate = "update sach set docgia_ten = N'" + TENDG + "',docgia_namsinh = '" + ns + "',sdt  ='" + phone + "',diachi ='" + dc + "'WHERE docgia_ma = '" + MADG + "'";


            ham.capnhat(sqlUpdate, conn);
            ham.HienThiDuLieuDG(luoi, "select * from sach", conn);
        }

        private void luoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtmadocgia.Text = luoi.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttendocgia.Text = luoi.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox1.Text = luoi.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtdiachi.Text = luoi.Rows[e.RowIndex].Cells[3].Value.ToString();
            
        }
    }
}

