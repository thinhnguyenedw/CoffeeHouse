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
    public partial class GeneralControl : Form
    {
        string taikhoan;
        
        public GeneralControl(string value)
        {
            InitializeComponent();
            taikhoan = value;
        }
        private string MaNV()
        {
            string MaNV="";
            SharingElement s = new SharingElement();
            SqlCommand cmd = new SqlCommand("Select MaNV from TAI_KHOAN where TaiKhoan='" + taikhoan + "'");
            if (s.ketnoi() == true)
            {
                MaNV = s.getData(cmd).Rows[0][0].ToString();
            }
            return MaNV;
        }
        private DataTable search()
        {
            DataTable search = new System.Data.DataTable();
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {

                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "searchHoadon";
                    cmd.Parameters.AddWithValue("@mahd", txtinMahd.Text);
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
        private void addHoadon()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "addHoadon";
                    cmd.Parameters.AddWithValue("@mahd", txtMahd.Text);
                    cnn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cnn.Close();
                }
            }
        }
        private void xoaHoadon()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "xoaHoadon";
                    cmd.Parameters.AddWithValue("@mahd", txtMahd.Text);
                    cnn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cnn.Close();
                }
            }
        }

        private void reload()
        {
            SharingElement s = new SharingElement();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Ban");
            if (s.ketnoi() == true)
            {
                s.loadDatagridView("v_NhanvienHoadon", dgvHoadon);
            }
        }
        private void GeneralControl_Load(object sender, EventArgs e)
        {
            SharingElement s = new SharingElement();
            this.MdiParent = Form1.ActiveForm;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Ban");
            if (s.ketnoi() == true)
            {
                labelChao.Text = "Xin chào "+ MaNV();
                s.loadDatagridView("v_NhanvienHoadon", dgvHoadon);
                s.loadComboBox(cmd, cbbTable);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dgvHoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMahd.Text = dgvHoadon.CurrentRow.Cells[0].Value.ToString();
            cbbTable.SelectedValue= dgvHoadon.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addHoadon();
            reload();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            xoaHoadon();
            reload();
        }

        private void dgvHoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMahd.Text = dgvHoadon.CurrentRow.Cells[0].Value.ToString();
            cbbTable.SelectedValue = dgvHoadon.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            BillDetailsControl bill = new BillDetailsControl(txtMahd.Text = dgvHoadon.CurrentRow.Cells[0].Value.ToString());
            bill.MdiParent = Form1.ActiveForm;
            bill.Show();
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            ReportBills rpt = new ReportBills();
            rpt.SetDataSource(search());
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reload();
        }
    }
}
