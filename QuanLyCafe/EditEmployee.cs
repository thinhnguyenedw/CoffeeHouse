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
    public partial class EditEmployee : Form
    {
        string mnv;
        private void suaEmployee()
        {
            SharingElement s = new SharingElement();
            using (SqlConnection cnn = new SqlConnection(s.str))
            {

                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "suaEmployee";
                    cmd.Parameters.AddWithValue("@manv", mnv);
                    cmd.Parameters.AddWithValue("@hoten", txtHoten.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(dtNgaysinh.Text));
                    cmd.Parameters.AddWithValue("@gioitinh", cbbGender.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtAdress.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@mavtri", cbbVitri.Text);
                    cnn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sửa lại thành công");
                        this.Close();
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    cnn.Close();
                }
            }
        }
        public EditEmployee(string value)
        {
            mnv = value;
            InitializeComponent();
            
        }
        
        private void EditEmployee_Load(object sender, EventArgs e)
        {
            SharingElement s = new SharingElement();
            if (s.ketnoi() == true)
            {
                // Sử dụng tham số cho câu lệnh SQL để tránh các vấn đề bảo mật và xử lý chuỗi đầu vào
                SqlCommand sql = new SqlCommand("SELECT * FROM NHANVIEN WHERE MaNV ='"+mnv+"';");


                DataTable result = s.getData(sql);

                // Kiểm tra xem có dữ liệu trả về hay không
                if (result.Rows.Count > 0)
                {
                    // Truy cập hàng đầu tiên của kết quả truy vấn
                    txtHoten.Text = result.Rows[0][1].ToString(); // Cột 1 là HoTen
                    dtNgaysinh.Text = result.Rows[0][2].ToString(); // Cột 2 là NgaySinh
                    cbbGender.Text=result.Rows[0][3].ToString();
                    txtAdress.Text=result.Rows[0][4].ToString();
                    txtPhone.Text=result.Rows[0][5].ToString();
                    cbbVitri.Text=result.Rows[0][7].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên với mã: " + mnv);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            suaEmployee();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
