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
    public partial class ThongkeDoanhthu : Form
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
                    cmd.CommandText = "searchHoadon";
                    cmd.Parameters.AddWithValue("@mahd", txtMahd.Text);
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
        public ThongkeDoanhthu()
        {
            InitializeComponent();
        }

        private void ThongkeDoanhthu_Load(object sender, EventArgs e)
        {
                SharingElement s = new SharingElement();
                if (s.ketnoi() == true)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblPhongban; ");
                }
                ReportDoanhthu rpt = new ReportDoanhthu();
                rpt.Load(@"C:\Users\thinh\source\repos\QuanLyCafe\QuanLyCafe\ReportDoanhthu.rpt");
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*            ReportDocument report = new ReportDocument();
            report.Load(@"C:\Users\thinh\source\repos\ThucHanhCrystalReport\ThucHanhCrystalReport\CrystalReport1.rpt");
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();*/

/*            ParameterFieldDefinition pfd = rpt.DataDefinition.ParameterFields["mpb"];

            // Tạo một đối tượng ParameterValues để lưu trữ giá trị tham số
            ParameterValues pv = new ParameterValues();

            // Tạo một đối tượng ParameterDiscreteValue để thiết lập giá trị tham số từ ComboBox
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();

            // Lấy giá trị đã chọn từ ComboBox và thiết lập cho tham số
            pdv.Value = cbbValues.SelectedIndex.ToString();

            // Thêm giá trị đã thiết lập vào ParameterValues
            pv.Add(pdv);

            // Xóa các giá trị hiện tại của tham số (nếu có)
            pfd.CurrentValues.Clear();

            // Áp dụng giá trị mới cho tham số
            pfd.ApplyCurrentValues(pv);*/
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TimHoadon rpt = new TimHoadon();
            rpt.SetDataSource(search());
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SharingElement s = new SharingElement();
            if (s.ketnoi() == true)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblPhongban; ");
            }
            ReportDoanhthu rpt = new ReportDoanhthu();
            rpt.Load(@"C:\Users\thinh\source\repos\QuanLyCafe\QuanLyCafe\ReportDoanhthu.rpt");
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
