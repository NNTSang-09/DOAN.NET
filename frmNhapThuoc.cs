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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;

namespace Quan_ly_Ban_Thuoc
{
    public partial class frmNhapThuoc : Form
    {
        private readonly string _connectionString;
        public frmNhapThuoc(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            List<string> medicineNames = new List<string>();
            List<string> medicineCodes = new List<string>();
            var medicines = GetMedicineDetails();
            foreach (var medicine in medicines)
            {
                medicineCodes.Add(medicine.Code);
                medicineNames.Add(medicine.Name);
                Console.WriteLine($"Code: {medicine.Code}, Name: {medicine.Name}");
            }

            SetAutoCompleteNameData(medicineCodes, medicineNames);
        }

        public void SetAutoCompleteNameData(List<string> medicineCodes, List<string> medicineName)
        {
            AutoCompleteStringCollection suggestCode = new AutoCompleteStringCollection();
            suggestCode.AddRange(medicineCodes.ToArray());
            
            AutoCompleteStringCollection suggestName = new AutoCompleteStringCollection();
            suggestName.AddRange(medicineName.ToArray());

            txtCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCode.AutoCompleteCustomSource = suggestCode;

            txtName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteCustomSource = suggestName;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtCode.Text.Trim();
            int quantity = Convert.ToInt32(nudQuantity.Value);
            DateTime expiryDate = dtpHetHan.Value;

            if (string.IsNullOrEmpty(id) || quantity <= 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và chính xác các thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (expiryDate <= DateTime.Now)
            {
                MessageBox.Show("Hạn sử dụng phải lớn hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                            INSERT INTO repository (quantity, medicine_expire_date, medicine_code) 
                            VALUES (@quantity, @medicine_expire_date, @medicine_code)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@medicine_expire_date", expiryDate);
                    cmd.Parameters.AddWithValue("@medicine_code", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thuốc vào kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private List<(string Code, string Name)> GetMedicineDetails()
        {
            List<(string Code, string Name)> medicineDetails = new List<(string Code, string Name)>();

            string query = "SELECT medicine_code, medicine_name FROM medicine"; // Truy vấn lấy code và tên thuốc từ bảng medicine

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Đọc thông tin từ bảng medicine
                        string medicineCode = reader["medicine_code"].ToString();
                        string medicineName = reader["medicine_name"].ToString();

                        // Thêm vào danh sách
                        medicineDetails.Add((medicineCode, medicineName));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return medicineDetails;
        }


        private void ClearForm()
        {
            txtName.Clear();
            txtCode.Clear();
            nudQuantity.Value = 0;
            dtpHetHan.Value = DateTime.Now;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
   