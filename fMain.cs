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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        public fMain(string name)
        {
            if (name == "staff")
            {
                InitializeComponent();
                btnFee.Visible = false;
                btnSalary.Visible = false;
                //btnStatistic.Visible = false;               
            }
            else InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMiniMize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Đăng xuất?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }    
        }

        private Form activeForm;

        public void openMenuForm(Form childForm, object btnsender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlDisplay.Controls.Add(childForm);
            this.pnlDisplay.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            btnStudent.Focus();
            openMenuForm(new fStudent(), sender);
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            openMenuForm(new fStudent(), sender);
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            openMenuForm(new fTeacher(), sender);
        }

        public void btnClass_Click(object sender, EventArgs e)
        {
            openMenuForm(new fClass(), sender);
        }

        private void btnFee_Click(object sender, EventArgs e)
        {
            openMenuForm(new fFee(), sender);
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            openMenuForm(new fSalary(), sender);
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            openMenuForm(new fStatistic(), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
