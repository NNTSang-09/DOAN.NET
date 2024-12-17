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

            string medicineCode = txtCode.Text.Trim();
            string medicineName = txtName.Text.Trim();
            string medicineGroup = txtCategory.Text.Trim();
            string unitType = cbbUnit.Text.Trim();
            DateTime expiredDate = dtpExpired.Value;
            int quantity;
            decimal medicinePrice;
            string medicineContent = txtDescription.Text.Trim();

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(medicineCode) || string.IsNullOrEmpty(medicineName) ||
                string.IsNullOrEmpty(medicineGroup) || string.IsNullOrEmpty(unitType))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số lượng và giá tiền
            if (!int.TryParse(nudQuantity.Text.Trim(), out quantity) || quantity < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out medicinePrice) || medicinePrice <= 0)
            {
                MessageBox.Show("Giá tiền phải là số dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ngày hết hạn
            if (expiredDate <= DateTime.Now)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã thuốc và tên thuốc
            if (medicineCode.Length > 50 || medicineName.Length > 100)
            {
                MessageBox.Show("Mã thuốc hoặc tên thuốc quá dài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Câu lệnh SQL thêm thuốc
            string query = @"
            INSERT INTO medicine (medicine_code, medicine_name, medicine_group, unit_type, medicine_price, quantity, medicine_expire_date, medicine_content)
            VALUES (@MedicineCode, @MedicineName, @MedicineGroup, @UnitType, @MedicinePrice, @Quantity, @MedicineExpireDate, @MedicineContent)";

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
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@MedicineExpireDate", expiredDate);
                command.Parameters.AddWithValue("@MedicineContent", medicineContent);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    MessageBox.Show($"Thêm dữ liệu thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
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

        private void ClearForm()
        {
            txtCode.Clear();
            txtName.Clear();
            txtCategory.Clear();
            cbbUnit.Items.Clear();
            nudQuantity.Value = 0;
            dtpExpired.Value = DateTime.Now;
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
