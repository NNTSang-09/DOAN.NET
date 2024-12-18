using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_Ban_Thuoc
{
    using System.Globalization;

    public partial class frmBaoCaoDoanhThu : Form
    {
        private readonly string _connectionString;
        private readonly User _user;

        public frmBaoCaoDoanhThu(string connectionString, User user)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _user = user;
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1); // Đến hết ngày kết thúc

            // Tải báo cáo
            LoadReport(startDate, endDate);
        }

        private void LoadReport(DateTime startDate, DateTime endDate)
        {
            string query = @"
            SELECT 
                CONVERT(DATE, created_at) AS [Ngày],
                SUM(amount) AS [Tổng Doanh Thu]
            FROM sale
            WHERE created_at BETWEEN @startDate AND @endDate
            GROUP BY CONVERT(DATE, created_at)
            ORDER BY CONVERT(DATE, created_at);";

            // Thiết lập kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu lệnh SQL
                        command.Parameters.AddWithValue("@startDate", startDate);
                        command.Parameters.AddWithValue("@endDate", endDate);

                        // Đọc dữ liệu từ cơ sở dữ liệu
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Hiển thị kết quả lên DataGridView
                        dgvReport.DataSource = dataTable;

                        // Format cột "Tổng Doanh Thu" thành tiền VNĐ
                        dgvReport.Columns["Tổng Doanh Thu"].DefaultCellStyle.Format = "C0"; // Định dạng tiền tệ không có số thập phân
                        dgvReport.Columns["Tổng Doanh Thu"].DefaultCellStyle.FormatProvider = new CultureInfo("vi-VN");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain mainView = new frmMain(_connectionString, _user);
            mainView.Show();
            this.Close();
        }
    }

}

