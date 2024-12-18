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
    public partial class frmQLThuocHetHan : Form
    {
        private readonly string _connectionString;
        private readonly User _user;
        public frmQLThuocHetHan(string connectionString, User user)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _user = user;
            LoadData();
            
        }

        private void LoadData()
        {
            string query = @"
            SELECT 
                medicine_code AS [ID], 
                medicine_name AS [Tên Thuốc], 
                unit_type AS [Đơn Vị Tính], 
                quantity AS [Số Lượng], 
                medicine_expire_date AS [Ngày Hết Hạn]
            FROM medicine
            WHERE 
                
                medicine_expire_date <= GETDATE()
                OR 
                
                DATEDIFF(DAY, GETDATE(), medicine_expire_date) <= 15
                OR quantity < 10 OR quantity = 0;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Xóa dữ liệu cũ trong ListView hoặc DataGridView
                    lstWarningMedicine.Items.Clear();

                    while (reader.Read())
                    {
                        // Tạo item mới cho mỗi dòng dữ liệu
                        ListViewItem item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["Tên Thuốc"].ToString());
                        item.SubItems.Add(reader["Đơn Vị Tính"].ToString());
                        item.SubItems.Add(reader["Số Lượng"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["Ngày Hết Hạn"]).ToString("dd/MM/yyyy"));
                        item.SubItems.Add("Cảnh báo thuốc");
                        lstWarningMedicine.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain mainView = new frmMain(_connectionString, _user);
            mainView.Show();
            this.Hide();
        }
    }
}
