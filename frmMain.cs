using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace Quan_ly_Ban_Thuoc
{
    public partial class frmMain : Form
    {
        private readonly string _connectionString;
        private readonly User _user;


        public frmMain(string connectionString, User user)
        {
            InitializeComponent();

            _connectionString = connectionString;
            _user = user;
            lbXinChao.Text = $"Xin chào {user.Username}\nBạn đang đang nhập với vai trò: {user.Role}";
            if (user.Role == "Staff")
            {
                MenustripMedicine.Visible = false;
            }
            LoadProductData();
        }

        public void LoadProductData()
        {
            string query = @"
                SELECT medicine_code AS [ID], 
                       medicine_name AS [Tên Thuốc], 
                       unit_type AS [Đơn Vị Tính], 
                       quantity AS [Số Lượng], 
                       medicine_price AS [Giá Tiền]
                FROM medicine";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Xóa dữ liệu cũ trong ListView
                    listViewMedicines.Items.Clear();

                    while (reader.Read())
                    {
                        // Tạo item mới cho mỗi dòng dữ liệu
                        ListViewItem item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["Tên Thuốc"].ToString());
                        item.SubItems.Add(reader["Đơn Vị Tính"].ToString());
                        item.SubItems.Add(reader["Số Lượng"].ToString());
                        item.SubItems.Add(string.Format("{0:C}", reader["Giá Tiền"])); // Hiển thị giá theo định dạng tiền tệ

                        listViewMedicines.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                frmLogin loginForm = new frmLogin(_connectionString);
                loginForm.Show();
                this.Hide();
            }
            
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {
                Application.Exit();
            }
            
        }

        private void btnAddMedicine_Click(object sender, System.EventArgs e)
        {
            frmAddMedicine addMedicineForm = new frmAddMedicine(_connectionString);
            addMedicineForm.ShowDialog();
        }

        private void btnQLThuoc_Click(object sender, System.EventArgs e)
        {
            frmQuanLyThuoc frmQuanLyThuoc = new frmQuanLyThuoc(_connectionString, _user);
            frmQuanLyThuoc.Show();
            this.Hide();
 
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProductData();
        }

        // Lấy sự kiện click vào phần tử
        private void listViewMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMedicines.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewMedicines.SelectedItems[0];

                // Lấy thông tin từ ListView
                string medicineCode = selectedItem.SubItems[0].Text; // Mã thuốc
                string medicineName = selectedItem.SubItems[1].Text; // Tên thuốc
                string unitType = selectedItem.SubItems[2].Text;     // Đơn vị
                int stockQuantity = int.Parse(selectedItem.SubItems[3].Text); // Số lượng tồn kho
                float price = float.Parse(selectedItem.SubItems[4].Text, System.Globalization.NumberStyles.Currency); // Giá tiền

                foreach (DataGridViewRow row in dgvProductCart.Rows)
                {
                    if (row.Cells["dgvCode"].Value?.ToString() == medicineCode)
                    {
                        // Sản phẩm đã tồn tại => Cộng dồn số lượng
                        int currentQuantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);

                        if (currentQuantity + 1 > stockQuantity)
                        {
                            MessageBox.Show("Không đủ hàng trong kho.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        currentQuantity++; // Tăng số lượng
                        row.Cells["dgvQuantity"].Value = currentQuantity;

                        // Cập nhật Thành tiền
                        float totalPrice = currentQuantity * price;
                        row.Cells["dgvAmount"].Value = totalPrice;
                        return; // Dừng vì đã cập nhật sản phẩm tồn tại
                    }
                }

                // Thêm sản phẩm mới vào giỏ hàng
                if (stockQuantity > 0)
                {
                    int index = dgvProductCart.Rows.Count + 1;
                    int quantityNew = 1; // Mặc định số lượng là 1
                    float totalPriceNew = price * quantityNew;

                    dgvProductCart.Rows.Add(index, medicineCode, medicineName, unitType, quantityNew, price, totalPriceNew);
                    lblTotal.Text = $"{GetTotalOrderAmount():C}";

                }
                else
                {
                    MessageBox.Show("Sản phẩm này đã hết hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Bắt sự kiện thay đổi số lượng trong đơn hàng
        private void dgvProductCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProductCart.Columns[e.ColumnIndex].Name == "dgvQuantity")
            {
                try
                {
                    // Lấy dòng hiện tại
                    DataGridViewRow row = dgvProductCart.Rows[e.RowIndex];

                    // Lấy số lượng (quantity) và giá tiền (price)
                    int quantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
                    float price = Convert.ToSingle(row.Cells["dgvPrice"].Value);
                    int stockQuantity = GetStockQuantity(row.Cells["dgvCode"].Value.ToString()); // Lấy số lượng tồn kho từ cơ sở dữ liệu

                    // Kiểm tra số lượng hợp lệ
                    if (quantity <= 0)
                    {
                        MessageBox.Show("Số lượng phải lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.Cells["dgvQuantity"].Value = 1; // Gán lại giá trị mặc định là 1
                        quantity = 1;
                    }
                    else if (quantity > stockQuantity)
                    {
                        MessageBox.Show("Không đủ hàng trong kho.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.Cells["dgvQuantity"].Value = stockQuantity; // Gán lại số lượng tối đa
                        quantity = stockQuantity;
                    }

                    float totalPrice = quantity * price;
                    row.Cells["dgvAmount"].Value = totalPrice;
                    lblTotal.Text = $"{GetTotalOrderAmount():C}";

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật thành tiền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int GetStockQuantity(string medicineCode)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT quantity FROM medicine WHERE medicine_code = @medicineCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@medicineCode", medicineCode);

                conn.Open();
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        // Tính tổng đơn hàng
        private float GetTotalOrderAmount()
        {
            float totalAmount = 0;

            foreach (DataGridViewRow row in dgvProductCart.Rows)
            {
                if (row.Cells["dgvAmount"] != null && row.Cells["dgvAmount"].Value != null)
                {
                    totalAmount += Convert.ToSingle(row.Cells["dgvAmount"].Value);
                }
            }

            return totalAmount;

        }



        // Xóa khỏi đơn hàng
        private void dgvProductCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvProductCart.Columns[e.ColumnIndex].Name == "dgvDelete") // Kiểm tra cột là "Xóa"
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này khỏi giỏ hàng không?",
                                                 "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        dgvProductCart.Rows.RemoveAt(e.RowIndex); // Xóa dòng
                        lblTotal.Text = $"{GetTotalOrderAmount():C}";
                    }
                }
            }
        }

        // Làm sạch đơn hàng
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvProductCart.Rows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ giỏ hàng không?",
                                             "Xác nhận",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dgvProductCart.Rows.Clear(); // Xóa toàn bộ dòng
                    lblTotal.Text = $"{GetTotalOrderAmount():C}";
                    MessageBox.Show("Đã xóa toàn bộ giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Giỏ hàng đang trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Thanh toán và trừ số lượng thuốc trong kho
        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtKhachTra.Text))
                {
                    MessageBox.Show("Yêu cầu nhập số tiền được trả");
                    return;
                }
                float recievedAmount = float.Parse(txtKhachTra.Text);
                float totalAmount = GetTotalOrderAmount();
                
                if (recievedAmount < totalAmount)
                {
                    MessageBox.Show("Số tiền khách trả không đủ để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataGridViewRow row in dgvProductCart.Rows)
                {
                    if (row.Cells["dgvCode"]?.Value != null && row.Cells["dgvQuantity"]?.Value != null)
                    {
                        string medicineCode = row.Cells["dgvCode"].Value.ToString();
                        int quantitySold = Convert.ToInt32(row.Cells["dgvQuantity"].Value);

                        // Gọi hàm cập nhật số lượng thuốc
                        UpdateMedicineQuantity(medicineCode, quantitySold);
                    }
                }

                

                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadProductData();
                dgvProductCart.Rows.Clear();
                txtKhachTra.Clear();
                lblTotal.Text = "0 VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật lại số lượng thuốc trong kho
        private void UpdateMedicineQuantity(string medicineCode, int quantitySold)
        {
            string query = "UPDATE medicine SET quantity = quantity - @QuantitySold WHERE medicine_code = @MedicineCode";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@QuantitySold", quantitySold);
                    command.Parameters.AddWithValue("@MedicineCode", medicineCode);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        MessageBox.Show($"Không thể cập nhật số lượng cho mã thuốc: {medicineCode}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật số lượng thuốc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
