using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thuc_Tap_CSDL
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        //string username = "admin";
        //string password = "admin";

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMiniMize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lblExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(txtUser.Text == "Tên đăng nhập")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.FromArgb(0, 134, 75);
            }    
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if(txtUser.Text == "")
            {
                txtUser.Text = "Tên đăng nhập";
                txtUser.ForeColor = Color.Silver;
            }    
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if(txtPassword.Text == "Mật khẩu")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = Color.FromArgb(0, 134, 75);
            }    
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if(txtPassword.Text == "")
            {
                txtPassword.Text = "Mật khẩu";
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.ForeColor = Color.Silver;
            }    
        }

        private void ptrEyes_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text != "Mật khẩu")
            {
                if (txtPassword.UseSystemPasswordChar)
                {
                    txtPassword.UseSystemPasswordChar = false;
                    //ptrEyes.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\eyeopen.ico");
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = true;
                    //ptrEyes.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\eyeclose.ico");
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if((txtUser.Text == "admin" && txtPassword.Text == "admin") || (txtUser.Text == "staff" && txtPassword.Text == "staff"))
            {
                this.Hide();
                fMain fmain = new fMain(txtUser.Text);
                fmain.ShowDialog();
                this.Show();
                txtUser.Text = "Tên đăng nhập";
                txtUser.ForeColor = Color.Silver;
                txtPassword.Text = "Mật khẩu";
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.ForeColor = Color.Silver;
                lblFailLogin.Text = "";
                txtUser.Focus();
            }
            else
            {
                txtUser.Text = "Tên đăng nhập";
                txtUser.ForeColor = Color.Silver;
                txtPassword.Text = "Mật khẩu";
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.ForeColor = Color.Silver;
                lblFailLogin.Text = "Đăng nhập thất bại";
                txtUser.Focus();
            }    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Thoát ứng dụng?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
