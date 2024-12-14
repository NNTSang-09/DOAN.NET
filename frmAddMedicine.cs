using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace Quan_ly_Ban_Thuoc
{
    public partial class frmAddMedicine : Form
    {
        private readonly string _connectionString;
        public frmAddMedicine(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox
            string medicineCode = txtCode.Text.Trim();
            string medicineName = txtName.Text.Trim();
            string medicineGroup = txtCategory.Text.Trim();
            string unitType = txtUnit.Text.Trim();
            decimal medicinePrice;
            string medicineContent = txtDescription.Text.Trim();

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(medicineCode) || string.IsNullOrEmpty(medicineName) ||
                string.IsNullOrEmpty(medicineGroup) || string.IsNullOrEmpty(unitType) ||
                !decimal.TryParse(txtPrice.Text.Trim(), out medicinePrice) || medicinePrice <= 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và chính xác thông tin thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Câu lệnh SQL thêm thuốc
            string query = @"
                INSERT INTO medicine (medicine_code, medicine_name, medicine_group, unit_type, medicine_price, medicine_content)
                VALUES (@MedicineCode, @MedicineName, @MedicineGroup, @UnitType, @MedicinePrice, @MedicineContent)";

            // Kết nối tới SQL Server và thêm dữ liệu
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Thêm tham số
                command.Parameters.AddWithValue("@MedicineCode", medicineCode);
                command.Parameters.AddWithValue("@MedicineName", medicineName);
                command.Parameters.AddWithValue("@MedicineGroup", medicineGroup);
                command.Parameters.AddWithValue("@UnitType", unitType);
                command.Parameters.AddWithValue("@MedicinePrice", medicinePrice);
                command.Parameters.AddWithValue("@MedicineContent", medicineContent);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    MessageBox.Show($"Thêm thành công {rowsAffected} dòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa dữ liệu trên form sau khi thêm thành công
                    ClearForm();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Vi phạm khóa chính hoặc UNIQUE
                    {
                        MessageBox.Show("Mã thuốc hoặc tên thuốc đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Phương thức xóa dữ liệu trên Form
        private void ClearForm()
        {
            txtCode.Clear();
            txtName.Clear();
            txtCategory.Clear();
            txtUnit.Clear();
            txtPrice.Clear();
            txtDescription.Clear();
            txtCode.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
