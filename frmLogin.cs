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
    public partial class frmLogin : Form
    {

        readonly string _connectionString;

        private readonly List<User> _users = new List<User>
        {
            new User("admin", "123", "Admin"),
            new User("user", "123", "Staff")
        };

        public frmLogin(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Tìm kiếm tài khoản trong danh sách
            User loggedInUser = _users.Find(u => u.Username == userName && u.Password == password);

            if (loggedInUser != null)
            {
                MessageBox.Show($"Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Truyền thông tin vai trò sang frmMain
                frmMain frmMain = new frmMain(_connectionString, loggedInUser); //loggedInUser.Role
                frmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ckPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
