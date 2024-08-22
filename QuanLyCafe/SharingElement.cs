using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace QuanLyCafe
{
    class SharingElement
    {
        public string str = ConfigurationManager.ConnectionStrings["db_Connect"].ConnectionString;
        public SqlConnection cnn = new SqlConnection();
        public bool ketnoi()
        {
            {
                try
                {
                    if (cnn.State == ConnectionState.Open) cnn.Close();
                    cnn.ConnectionString = str;
                    cnn.Open();
                }
                catch
                {
                    MessageBox.Show("Lỗi kết nối CSDL", "Thông báo");
                    return false;
                }
                return true;
            }
        }
        public DataTable getTable(string tenbang)
        {
            string sql = "Select * from " + tenbang;
            SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public DataTable getData(SqlCommand cmd)
        {
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            return tbl;
        }
        public void loadDatagridView(string strSQL, DataGridView dgr)
        {
            if (ketnoi() == false) return;
            try
            {
                DataTable dt = getTable(strSQL);
                dgr.DataSource = dt;
                dgr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu", "Thông báo");
                return;
            }
        }
        public void loadComboBox(SqlCommand cmd, ComboBox cbb)
        {
            DataTable tbl = getData(cmd);
            cbb.DataSource = tbl;
            cbb.ValueMember = tbl.Columns[0].ColumnName;
            cbb.DisplayMember = tbl.Columns[1].ColumnName;
        }
        /*        public int checkExist(SqlCommand cmd)
                {
                    try
                    {
                        cnn.Open();
                        cmd.Connection = cnn;

                    }
                }*/
    }
}
