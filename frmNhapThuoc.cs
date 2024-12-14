using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_Ban_Thuoc
{
    public partial class frmNhapThuoc : Form
    {
        private readonly string _connectionString;
        public frmNhapThuoc(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            List<string> medicineNames = GetMedicineNames();
            SetAutoCompleteNameData(medicineNames);
        }
        
        // Autocomplete data
        public void SetAutoCompleteNameData(List<string> medicineName)
        {
            AutoCompleteStringCollection suggest = new AutoCompleteStringCollection();
            suggest.AddRange(medicineName.ToArray());

            txtName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteCustomSource = suggest;
        }

        // Get medicine name from database
        private List<string> GetMedicineNames()
        {
            List<string> medicineNames = new List<string>();

            string query = "SELECT medicine_name FROM medicine";  // Truy vấn lấy tất cả tên thuốc từ bảng medicine

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Thêm tên thuốc vào danh sách
                        string medicineName = reader["medicine_name"].ToString();
                        medicineNames.Add(medicineName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return medicineNames;
        }

        // Save Data
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ client
            string medicineCode = txtCode.Text.Trim();
            string medicineQuantityText = txtQuantity.Text.Trim();
            DateTime medicineExpireDate = dtpHetHan.Value;
            // check dữ liệu
            if (string.IsNullOrEmpty(medicineCode))
            {
                MessageBox.Show("Mã thuốc không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (medicineExpireDate <= DateTime.Now)
            {
                MessageBox.Show("Hạn sử dụng phải lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(medicineQuantityText) || !int.TryParse(medicineQuantityText, out int medicineQuantity) || medicineQuantity <= 0)
            {
                MessageBox.Show("Số lượng thuốc phải là một số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsMedicineCodeValid(medicineCode))
            {
                MessageBox.Show("Mã thuốc không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Truy vấn
            string query = @"
            INSERT INTO repository (medicine_code, quantity, medicine_expire_date)
            VALUES (@MedicineCode, @MedicineQuantity, @MedicineExpireDate)";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                // Thêm tham số
                command.Parameters.AddWithValue("@MedicineCode", medicineCode);
                command.Parameters.AddWithValue("@MedicineQuantity", medicineQuantity);
                command.Parameters.AddWithValue("@MedicineExpireDate", medicineExpireDate);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Thực hiện thêm dữ liệu
                    MessageBox.Show($"Thêm thành công thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Vi phạm khóa chính hoặc UNIQUE
                    {
                        MessageBox.Show("Dữ liệu đã tồn tại hoặc vi phạm ràng buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool IsMedicineCodeValid(string medicineCode)
        {
            string query = "SELECT COUNT(1) FROM medicine WHERE medicine_code = @MedicineCode";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MedicineCode", medicineCode);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;  // Nếu có ít nhất 1 bản ghi thì mã thuốc hợp lệ
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kiểm tra mã thuốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtCategory.Clear();
            txtUnit.Clear();
            txtPrice.Clear();
            txtCode.Clear();
            txtQuantity.Clear();
            dtpHetHan.Value = DateTime.Now;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void txtName_Leave(object sender, EventArgs e)
        //{
        //    string medicineName = txtCode.Text.Trim();
        //    if (string.IsNullOrEmpty(medicineName))
        //        return;
        //    var medicineInfo = GetMedicineInfoByMedicineName(medicineName);
        //    if (medicineInfo != null)
        //    {
        //        AutoFillData(medicineInfo);
        //    }
        //}

        //private Dictionary<string, string> GetMedicineInfoByMedicineName(string medicineName)
        //{
        //    string query = "SELECT * FROM medicine WHERE medicine_name = @MedicineName";
        //    Dictionary<string, string> medicineInfo = null;

        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@MedicineName", medicineName);

        //        try
        //        {
        //            connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                medicineInfo = new Dictionary<string, string>
        //                {
        //                    { "medicine_code", reader["medicine_code"].ToString() },
        //                    { "medicine_group", reader["medicine_group"].ToString() },
        //                    { "unit_type", reader["unit_type"].ToString() },
        //                    { "medicine_price", reader["medicine_price"].ToString() },
        //                    { "medicine_content", reader["medicine_content"].ToString() }
        //                };
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi truy vấn thông tin thuốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    return medicineInfo;
        //}

        //private void AutoFillData(Dictionary<string, string> medicineInfo)
        //{
        //    if (medicineInfo != null)
        //    {
        //        txtCode.Text = medicineInfo["medicine_code"];
        //        txtCategory.Text = medicineInfo["medicine_group"];
        //        txtUnit.Text = medicineInfo["unit_type"];
        //        txtPrice.Text = medicineInfo["medicine_price"];
        //    }
        //}
    }
}

