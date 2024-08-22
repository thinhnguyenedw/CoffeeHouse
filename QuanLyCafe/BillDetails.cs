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
    public partial class BillDetails : Form
    {
        string mahd;
        private DataTable billDetails ()
        {
            DataTable billDetails = new System.Data.DataTable();
            SharingElement s = new SharingElement();
            
            using (SqlConnection cnn = new SqlConnection(s.str))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "xemChitietBill";
                    cmd.Parameters.AddWithValue("@mahd", mahd);
                    cnn.Open();
                    try
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            ad.Fill(billDetails);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Nhập bị lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cnn.Close();
                    return billDetails;
                }
            }
        }
        public BillDetails(string value)
        {
            InitializeComponent();
            mahd = value;
        }

        private void BillDetails_Load(object sender, EventArgs e)
        {
            this.MdiParent = Form1.ActiveForm;
            dgvDetails.DataSource = billDetails();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
