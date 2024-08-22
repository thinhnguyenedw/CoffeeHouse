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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace QuanLyCafe
{
    public partial class mst : Form
    {
        private DataTable search()
        {
            DataTable search = new System.Data.DataTable();
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {

                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "checkMST";
                    cmd.Parameters.AddWithValue("@mast1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@mast2", textBox2.Text);
                    cnn.Open();
                    try
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            ad.Fill(search);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    cnn.Close();
                    return search;
                }
            }
        }
        public mst()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void mst_Load(object sender, EventArgs e)
        {


        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetDataSource(search());
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
