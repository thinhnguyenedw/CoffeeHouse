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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            SharingElement sharingElement = new SharingElement();
            string account;
            string pass;
            string role;
            if (textBoxPass.Text == "" || textBoxAcc.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin đăng nhập");
            }
            else
            {
                if (sharingElement.ketnoi() == true)
                {

                    try
                    {

                        SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TAI_KHOAN WHERE TaiKhoan= '" + textBoxAcc.Text + "' AND MatKhau= '" + textBoxPass.Text + "'");
                        if (sharingElement.getData(sqlCommand).Rows.Count > 0)
                        {
                            account = textBoxAcc.Text;
                            pass = textBoxPass.Text;
                            role = sharingElement.getData(sqlCommand).Rows[0][3].ToString();

                            if (role == "AD")
                            {

                                AdminControl adminControl = new AdminControl();
                                adminControl.MdiParent = Form1.ActiveForm;
                                adminControl.Show();
                                this.Hide();
                            }
                            if (role=="NV")
                            {
                                GeneralControl generalControl = new GeneralControl(textBoxAcc.Text);
                                generalControl.MdiParent = Form1.ActiveForm;
                                generalControl.Show();
                                this.Hide();
                            }
                        }
                        if (sharingElement.getData(sqlCommand).Rows.Count == 0)
                        {
                            MessageBox.Show("Không có thông tin tài khoản này!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }
    }
}
