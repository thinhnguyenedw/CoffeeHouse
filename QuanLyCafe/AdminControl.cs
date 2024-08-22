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
    public partial class AdminControl : Form
    {

        private void addAccount()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {

                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    if (txtMasothue.Text.Length == 10)
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "addNVMST";
                        cmd.Parameters.AddWithValue("@manv", txtManv.Text);
                        cmd.Parameters.AddWithValue("@tennv", txtTen.Text);
                        cmd.Parameters.AddWithValue("@mast", txtMasothue.Text);
                        cmd.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(dtNgaysinh.Text));
                        
                    }
                    cnn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Chưa nhập đủ 10 kí tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    cnn.Close();
                }
            }
        }
        private void addHanghoa()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {

                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "themHanghoa";
                    //@masp nvarchar(6), @tensp nvarchar(40), @maloai nvarchar(6), @size varchar(1), @dvtinh nvarchar(5), @dongia float
                    cmd.Parameters.AddWithValue("@masp", txtMaSp.Text);
                    cmd.Parameters.AddWithValue("@tensp", txtTensp.Text);
                    cmd.Parameters.AddWithValue("@maloai", cbbMaloai.Text);
                    cmd.Parameters.AddWithValue("@size", cbbSize.Text);
                    cmd.Parameters.AddWithValue("@dvtinh", cbbDvitinh.Text);
                    cmd.Parameters.AddWithValue("@dongia", txtDongia.Text);
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
        private void updateAccount()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {

                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    if (txtMasothue.Text.Length == 10)
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "suanv";
                        cmd.Parameters.AddWithValue("@manv", txtManv.Text);
                        cmd.Parameters.AddWithValue("@tennv", txtTen.Text);
                        cmd.Parameters.AddWithValue("@mast", txtMasothue.Text);
                        cmd.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(dtNgaysinh.Text));

                    }
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
        private void updateHanghoa()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {

                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "suaHanghoa";
                    cmd.Parameters.AddWithValue("@masp", txtMaSp.Text);
                    cmd.Parameters.AddWithValue("@tensp", txtTensp.Text);
                    cmd.Parameters.AddWithValue("@maloai", cbbMaloai.Text);
                    cmd.Parameters.AddWithValue("@size", cbbSize.Text);
                    cmd.Parameters.AddWithValue("@dvtinh", cbbDvitinh.Text);
                    cmd.Parameters.AddWithValue("@dongia", txtDongia.Text);
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
        private void deleteAccount()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {

                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "xoanv";
                 
                    cmd.Parameters.AddWithValue("@manv", txtManv.Text);
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
        private void deleteHanghoa()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {

                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "xoaHanghoa";
                    cmd.Parameters.AddWithValue("@masp", txtMaSp.Text);
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
                s.loadDatagridView("v_Hanghoa", dgvHanghoa);
                s.loadDatagridView("v_NV", dgvAccount);
                s.loadDatagridView("v_Hoadon", dgvHoadon);
            }
        }
        public AdminControl()
        {
            InitializeComponent();
            labelAccount.Text = "Xin chào ADMIN";
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
           
            SharingElement s = new SharingElement();
            if (s.ketnoi() == true)
            {
                s.loadDatagridView("v_NV", dgvAccount);
                s.loadDatagridView("v_Hanghoa", dgvHanghoa);
                s.loadDatagridView("v_Hoadon", dgvHoadon);
            }
           
        }

        private void toolStripAccount_Click(object sender, EventArgs e)
        {
        }

        private void toolStripDrink_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addAccount();
            reload();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateAccount();
            reload();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            deleteAccount();
            reload();
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            txtManv.Text = dgvAccount.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dgvAccount.CurrentRow.Cells[1].Value.ToString();
     
        /*    dtNgaysinh.Text = dgvAccount.CurrentRow.Cells[5].Value.ToString();*/
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtManv.Text = dgvAccount.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dgvAccount.CurrentRow.Cells[1].Value.ToString();

            /*       dtNgaysinh.Text = dgvAccount.CurrentRow.Cells[5].Value.ToString();*/
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            string a = dgvAccount.CurrentRow.Cells[2].Value.ToString();
            EditEmployee edit = new EditEmployee(a);
            edit.MdiParent = Form1.ActiveForm;
            edit.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSp.Text = dgvHanghoa.CurrentRow.Cells[0].Value.ToString();
            cbbMaloai.Text = dgvHanghoa.CurrentRow.Cells[1].Value.ToString();
            txtTensp.Text = dgvHanghoa.CurrentRow.Cells[2].Value.ToString();
            cbbSize.Text = dgvHanghoa.CurrentRow.Cells[3].Value.ToString();
            cbbDvitinh.Text = dgvHanghoa.CurrentRow.Cells[4].Value.ToString();
            txtDongia.Text = dgvHanghoa.CurrentRow.Cells[5].Value.ToString();
        }

        private void txtMaSp_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvHanghoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSp.Text = dgvHanghoa.CurrentRow.Cells[0].Value.ToString();
            cbbMaloai.Text = dgvHanghoa.CurrentRow.Cells[1].Value.ToString();
            txtTensp.Text = dgvHanghoa.CurrentRow.Cells[2].Value.ToString();
            cbbSize.Text = dgvHanghoa.CurrentRow.Cells[3].Value.ToString();
            cbbDvitinh.Text = dgvHanghoa.CurrentRow.Cells[4].Value.ToString();
            txtDongia.Text = dgvHanghoa.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            addHanghoa();
            reload();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            updateHanghoa();
            reload();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteHanghoa();
            reload();
        }

        private void dgvHoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            string value = dgvHoadon.CurrentRow.Cells[0].Value.ToString();
            BillDetails billDetails = new BillDetails(value);
            billDetails.Show();
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            
            ThongkeDoanhthu thongkeDoanhthu = new ThongkeDoanhthu();
            thongkeDoanhthu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mst thongkeDoanhthu = new mst();
            thongkeDoanhthu.Show();
        }
    }
}
