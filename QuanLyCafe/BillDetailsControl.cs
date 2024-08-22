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
    public partial class BillDetailsControl : Form
    {
        string x;
        public BillDetailsControl(string value)
        {
            InitializeComponent();
            x = value;
        }

        private DataTable billDetails()
        {
            DataTable billDetails = new System.Data.DataTable();
            SharingElement s = new SharingElement();

            using (SqlConnection cnn = new SqlConnection(s.str))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "xemChitietBill";
                    cmd.Parameters.AddWithValue("@mahd", x);
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
        private void addChitietHoadon()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "addChitietHoadon";
                    cmd.Parameters.AddWithValue("@mahd", x);
                    cmd.Parameters.AddWithValue("@masp", cbbMon.SelectedValue);
                    cmd.Parameters.AddWithValue("@size", labelSize.Text);
                    cmd.Parameters.AddWithValue("@soluong", txtNum.Text);
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
        private void suaChitietHoadon()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "suaChitietHoadon";
                    cmd.Parameters.AddWithValue("@mahd", x);
                    cmd.Parameters.AddWithValue("@masp", cbbMon.SelectedValue);
                    cmd.Parameters.AddWithValue("@size", labelSize.Text);
                    cmd.Parameters.AddWithValue("@soluong", txtNum.Text);
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
        private void xoaChitietHoadon()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "xoaChitietHoadon";
                    cmd.Parameters.AddWithValue("@mahd", x);
                    cmd.Parameters.AddWithValue("@masp", cbbMon.SelectedValue);
                    cmd.Parameters.AddWithValue("@size", labelSize.Text);
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
            if (s.ketnoi() == true)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SAN_PHAM");
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM THUC_DON");
                dgvBillDetails.DataSource = billDetails();
            }
        }
        private string setSize(string n)
        {
            string setSize;
            DataTable billDetails = new System.Data.DataTable();
            SharingElement s = new SharingElement();

            using (SqlConnection cnn = new SqlConnection(s.str))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "selectSize";
                    cmd.Parameters.AddWithValue("@masp",n);
                    cnn.Open();
                    try
                    {
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            ad.Fill(billDetails);
                            setSize = billDetails.Rows[0][0].ToString();
                        }
                    }
                    catch {
                        setSize = "";
                    }
                    cnn.Close();
                    
                    return setSize;
                }
            }
        }
        private void BillDetailsControl_Load(object sender, EventArgs e)
        {
            SharingElement s = new SharingElement();
            labelMahd.Text = x;
            if (s.ketnoi() == true)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SAN_PHAM");
                dgvBillDetails.DataSource = billDetails();
                s.loadComboBox(cmd, cbbMon);
                labelSize.Text = setSize(labelMasp.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelSize.Text = setSize(cbbMon.SelectedValue.ToString());
        }

        private void cbbSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvBillDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbMon.SelectedValue = dgvBillDetails.CurrentRow.Cells[1].Value.ToString();
            txtNum.Text = dgvBillDetails.CurrentRow.Cells[4].Value.ToString();
            labelMasp.Text= dgvBillDetails.CurrentRow.Cells[1].Value.ToString();
            labelSize.Text = setSize(labelMasp.Text);
        }

        private void dgvBillDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbMon.SelectedValue = dgvBillDetails.CurrentRow.Cells[1].Value.ToString();
            txtNum.Text = dgvBillDetails.CurrentRow.Cells[4].Value.ToString();
            labelMasp.Text = dgvBillDetails.CurrentRow.Cells[1].Value.ToString();
            labelSize.Text = setSize(labelMasp.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addChitietHoadon();
            reload();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            suaChitietHoadon();
            reload();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            xoaChitietHoadon();
            reload();
        }
    }
}
