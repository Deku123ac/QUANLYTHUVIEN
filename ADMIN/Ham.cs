using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMIN
{
    internal class Ham
    {
        public void KetNoi(SqlConnection conn)
        {
            string chuoiketnoi = "SERVER = DESKTOP-III95LE ; database = BT_NHOM ;integrated Security = True ";
            conn.ConnectionString = chuoiketnoi;
            conn.Open();

        }
        public void HienThiDuLieuDG(DataGridView dg, string sql, SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "phat");
            dg.DataSource = dataset;
            dg.DataMember = "phat";

        }
        public void LoadComboBox(ComboBox comb, string sql, SqlConnection conn, string hienthi, string giatri)
        {
            SqlCommand comd = new SqlCommand(sql, conn);
            SqlDataReader reader = comd.ExecuteReader();
            DataTable table = new DataTable(); ;
            table.Load(reader);
            comb.DataSource = table;
            comb.DisplayMember = hienthi;
            comb.ValueMember = giatri;
        }
        public void capnhat(String sql, SqlConnection conn)
        {
            SqlCommand comb = new SqlCommand(sql, conn);
            comb.ExecuteNonQuery();
        }
    }
}
