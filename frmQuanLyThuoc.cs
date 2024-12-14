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
    public partial class frmQuanLyThuoc : Form
    {
        private readonly string _connectionString;
        private readonly User _user;
        public frmQuanLyThuoc(string connectionString, User user)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _user = user;
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddMedicine frmAddMedicine = new frmAddMedicine(_connectionString);
            frmAddMedicine.ShowDialog();
            LoadData();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain(_connectionString, _user);
            frmMain.Show();
            this.Hide();
        }

        private void LoadData()
        {
            string query = "SELECT medicine_code AS [Mã Thuốc], medicine_name AS [Tên Thuốc], " +
                           "medicine_group AS [Nhóm Thuốc], unit_type AS [Đơn Vị], " +
                           "medicine_price AS [Giá], medicine_content AS [Nội Dung] FROM medicine";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvMedicineData.DataSource = dt;
                    dgvMedicineData.Columns["Mã Thuốc"].ReadOnly = true;

                    if (dgvMedicineData.Columns["btnDelete"] == null)
                    {
                        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                        btnDelete.Name = "btnDelete";
                        btnDelete.HeaderText = "Xóa";
                        btnDelete.Text = "Xóa";
                        btnDelete.UseColumnTextForButtonValue = true;

                        dgvMedicineData.Columns.Add(btnDelete);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }


        private void dgvMedicineData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Kiểm tra nếu click vào cột "Xóa" (tên cột là "btnDelete")
                if (dgvMedicineData.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    // Lấy giá trị khóa chính từ hàng hiện tại
                    string medicineCode = dgvMedicineData.Rows[e.RowIndex].Cells["Mã Thuốc"].Value.ToString();

                    // Hỏi xác nhận xóa
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thuốc này không?",
                                        "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Gọi hàm xóa
                        DeleteMedicine(medicineCode);

                        // Refresh lại dữ liệu sau khi xóa
                        LoadData();
                    }
                }
            }
        }

        private void DeleteMedicine(string medicineCode)
        {
            string query = "DELETE FROM medicine WHERE medicine_code = @Code";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Code", medicineCode);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMedicineData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string medicineCode = dgvMedicineData.Rows[e.RowIndex].Cells["Mã Thuốc"].Value.ToString();
                string medicineName = dgvMedicineData.Rows[e.RowIndex].Cells["Tên Thuốc"].Value.ToString();
                string medicineGroup = dgvMedicineData.Rows[e.RowIndex].Cells["Nhóm Thuốc"].Value.ToString();
                string unitType = dgvMedicineData.Rows[e.RowIndex].Cells["Đơn Vị"].Value.ToString();
                decimal price = Convert.ToDecimal(dgvMedicineData.Rows[e.RowIndex].Cells["Giá"].Value);
                string content = dgvMedicineData.Rows[e.RowIndex].Cells["Nội Dung"].Value.ToString();

                UpdateMedicine(medicineCode, medicineName, medicineGroup, unitType, price, content);
            }
        }

        private void UpdateMedicine(string code, string name, string group, string unit, decimal price, string content)
        {
            string query = "UPDATE medicine SET medicine_name = @Name, medicine_group = @Group, " +
                           "unit_type = @Unit, medicine_price = @Price, medicine_content = @Content " +
                           "WHERE medicine_code = @Code";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Code", code);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Group", group);
                    command.Parameters.AddWithValue("@Unit", unit);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Content", content);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
