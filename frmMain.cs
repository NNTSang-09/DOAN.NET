using System.ComponentModel.Design;
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
                MenuStripKho.Visible = false;
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

        private void btnNhapThuoc_Click(object sender, System.EventArgs e)
        {
            frmNhapThuoc frmnhapThuoc = new frmNhapThuoc(_connectionString);
            frmnhapThuoc.ShowDialog();

        }
    }
}
