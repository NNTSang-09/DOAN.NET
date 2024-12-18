using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            dtpExpired.Format = DateTimePickerFormat.Custom;
            dtpExpired.CustomFormat = "dd/MM/yyyy";
            List<string> medicineCodes = GetMedicineCodes();
            SetAutoCompleteData(medicineCodes);
            txtCode.Leave += CheckExistMedicine;

        }
        private void CheckExistMedicine(object sender, EventArgs e)
        {
            string medicineCode = txtCode.Text.Trim();
            if (string.IsNullOrEmpty(medicineCode))
                return;

            DataRow medicineRow = GetMedicineByCode(medicineCode); // Lấy thông tin thuốc từ cơ sở dữ liệu
            if (medicineRow != null)
            {
                AutoFillData(medicineRow); // Tự động điền dữ liệu vào form
            }
            
        }

        private void AutoFillData(DataRow medicineRow)
        {
            if (medicineRow == null)
                return;

            txtName.Text = medicineRow["medicine_name"].ToString();
            txtCategory.Text = medicineRow["medicine_group"].ToString();
            txtDescription.Text = medicineRow["medicine_content"].ToString();
            txtPrice.Text = Convert.ToDecimal(medicineRow["medicine_price"]).ToString("0.##");
            cbbUnit.Text = medicineRow["unit_type"].ToString();
            nudQuantity.Text = Convert.ToInt32(medicineRow["quantity"]).ToString();
            dtpExpired.Value = Convert.ToDateTime(medicineRow["medicine_expire_date"]);

            // Readonly

            txtName.ReadOnly = true;
            txtCategory.ReadOnly = true;
            txtDescription.ReadOnly = true;
            txtPrice.ReadOnly = true;
            cbbUnit.Enabled = false;  // ComboBox không có thuộc tính ReadOnly, dùng Enabled

        }


        private DataRow GetMedicineByCode(string medicineCode)
        {
            string query = "SELECT * FROM medicine WHERE medicine_code = @MedicineCode";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MedicineCode", medicineCode);

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    return table.Rows[0]; // Trả về dòng đầu tiên nếu tìm thấy
                }
            }
            return null; // Không tìm thấy thuốc
        }

        // Set auto complete data
        public void SetAutoCompleteData(List<string> medicineCodes)
        {
            AutoCompleteStringCollection suggestCode = new AutoCompleteStringCollection();
            suggestCode.AddRange(medicineCodes.ToArray());

            txtCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCode.AutoCompleteCustomSource = suggestCode;;
        }

        private List<string> GetMedicineCodes()
        {
            List<string> medicineCodes = new List<string>();

            string query = "SELECT medicine_code FROM medicine";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string medicineCode = reader["medicine_code"].ToString();
                        medicineCodes.Add(medicineCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return medicineCodes;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string medicineCode = txtCode.Text.Trim();
            string medicineName = txtName.Text.Trim();
            string medicineGroup = txtCategory.Text.Trim();
            string unitType = cbbUnit.Text.Trim();
            DateTime expiredDate = dtpExpired.Value.Date;
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

            if (expiredDate <= DateTime.Now.Date)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (medicineCode.Length > 50 || medicineName.Length > 100)
            {
                MessageBox.Show("Mã thuốc hoặc tên thuốc quá dài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // Kiểm tra thuốc đã tồn tại trong DB
                    string checkQuery = @"
                        SELECT quantity 
                        FROM medicine 
                        WHERE medicine_code = @MedicineCode AND medicine_expire_date = @ExpireDate";

                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@MedicineCode", medicineCode);
                    checkCommand.Parameters.AddWithValue("@ExpireDate", expiredDate);

                    object result = checkCommand.ExecuteScalar();

                    if (result != null)
                    {
                        // Nếu thuốc tồn tại và hạn sử dụng giống nhau, cập nhật số lượng
                        int existingQuantity = Convert.ToInt32(result);
                        string updateQuery = @"
                            UPDATE medicine 
                            SET quantity = @NewQuantity 
                            WHERE medicine_code = @MedicineCode AND medicine_expire_date = @ExpireDate";

                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@NewQuantity", existingQuantity + quantity);
                        updateCommand.Parameters.AddWithValue("@MedicineCode", medicineCode);
                        updateCommand.Parameters.AddWithValue("@ExpireDate", expiredDate);

                        updateCommand.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật số lượng thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                    }
                    else
                    {
                        // Nếu thuốc không tồn tại hoặc hạn sử dụng khác, thêm mới
                        string insertQuery = @"
                            INSERT INTO medicine (medicine_code, medicine_name, medicine_group, unit_type, medicine_price, quantity, medicine_expire_date, medicine_content)
                            VALUES (@MedicineCode, @MedicineName, @MedicineGroup, @UnitType, @MedicinePrice, @Quantity, @MedicineExpireDate, @MedicineContent)";

                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@MedicineCode", medicineCode);
                        insertCommand.Parameters.AddWithValue("@MedicineName", medicineName);
                        insertCommand.Parameters.AddWithValue("@MedicineGroup", medicineGroup);
                        insertCommand.Parameters.AddWithValue("@UnitType", unitType);
                        insertCommand.Parameters.AddWithValue("@MedicinePrice", medicinePrice);
                        insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                        insertCommand.Parameters.AddWithValue("@MedicineExpireDate", expiredDate);
                        insertCommand.Parameters.AddWithValue("@MedicineContent", medicineContent);

                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Thêm thuốc mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
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
            nudQuantity.Clear();
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
