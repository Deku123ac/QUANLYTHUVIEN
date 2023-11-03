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
    public partial class FormTraSach : Form
    {
        public SqlConnection conn = new SqlConnection();
        Ham ham = new Ham();

        public FormTraSach()

        {
            InitializeComponent();
        }

        private void FormTraSach_Load(object sender, EventArgs e)
        {
            ham.KetNoi(conn);
            string sql_tatcaphieumuon = "select a.PHIEUMUON_MA as MAPHIEUMUON, b.docgia_ma as MADOCGIA, b.DOCGIA_TEN as TENDOCGIA, " +
                " b.SDT as SDT, d.SACH_TENSACH as TENSACH, a.NGAYMUON as NGAYMUON, a.THUTHU_MA as THUTHU  from phieumuon a, docgia b, chitietmuon c, sach d " +
                "where a.docgia_ma = b.docgia_ma and a.PHIEUMUON_MA = c.PHIEUMUON_MA and c.SACH_MA = d.SACH_MA;";
            ham.HienThiDuLieuDG(dgwDanhsachmuon, sql_tatcaphieumuon, conn);

            string sql_tatcadocgia = "select * from docgia";
            ham.LoadComboBox(cbbChondocgia, sql_tatcadocgia, conn, "DOCGIA_ten", "DOCGIA_ma");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            string maphieumuon = txtMaphieumuon.Text;
            string sql_xoaphieumuon = "delete from phieumuon where phieumuon_ma = '" + maphieumuon + "';";
            ham.capnhat(sql_xoaphieumuon, conn);

            string madocgia = txtMadocgia.Text;
            string sql_laydocgia = "select * from phieumuon where docgia_ma = '" + madocgia + "'";
            ham.HienThiDuLieuDG(dgwDanhsachmuon, sql_laydocgia, conn);
        }

        private void dgwDanhsachmuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaphieumuon.Text = dgwDanhsachmuon.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMadocgia.Text = dgwDanhsachmuon.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTendocgia.Text = dgwDanhsachmuon.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTensach.Text = dgwDanhsachmuon.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtMathuthu.Text = dgwDanhsachmuon.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string chuoiTimKiem = txtTimkiemdocgia.Text;
            string sql_timdocgia = "select * from docgia where docgia_ten like '%" + chuoiTimKiem + "%' or docgia_ma like '%" + chuoiTimKiem + "%';";
            ham.LoadComboBox(cbbChondocgia, sql_timdocgia, conn, "DOCGIA_ten", "DOCGIA_ma");
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            string madocgia = cbbChondocgia.SelectedValue.ToString();
            string sql_laydg = "select a.PHIEUMUON_MA as MAPHIEUMUON, b.docgia_ma as MADOCGIA, b.DOCGIA_TEN as TENDOCGIA, " +
                " b.SDT as SDT, d.SACH_TENSACH as TENSACH, a.NGAYMUON as NGAYMUON, a.THUTHU_MA as THUTHU  from phieumuon a, docgia b, chitietmuon c, sach d " +
                "where a.docgia_ma = '" + madocgia + "' and a.docgia_ma = b.docgia_ma and a.PHIEUMUON_MA = c.PHIEUMUON_MA and c.SACH_MA = d.SACH_MA;";

            ham.HienThiDuLieuDG(dgwDanhsachmuon, sql_laydg, conn);

            txtMadocgia.Text = madocgia;
        }
    }
}
