using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Thuc_Tap_CSDL
{
    public partial class fTeacher : Form
    {
        public fTeacher()
        {
            InitializeComponent();
        }


        SqlConnection con;


        private void fTeacher_Load(object sender, EventArgs e)
        {
            txtTeacherID.Focus();

            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            Display();
        }

        private void fTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void Display()
        {
            string sqlCode = "SELECT * FROM GIAOVIEN";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvTeacher.DataSource = dataTable;
        }

        private void txtTeacherBirth_Enter(object sender, EventArgs e)
        {
            if (txtTeacherBirth.Text == "MM/DD/YYYY")
            {
                txtTeacherBirth.Text = "";
                txtTeacherBirth.ForeColor = Color.FromArgb(0, 72, 39);
            }
        }

        private void txtTeacherBirth_Leave(object sender, EventArgs e)
        {
            if (txtTeacherBirth.Text == "")
            {
                txtTeacherBirth.Text = "MM/DD/YYYY";
                txtTeacherBirth.ForeColor = Color.Silver;
            }
        }

        private void btnTeacher_add_Click(object sender, EventArgs e)
        {
            string gender;
            if (radGender_female.Checked)
            {
                gender = radGender_female.Text;
            }
            else
            {
                gender = radGender_male.Text;
            }


            string sqlInsert = "exec PROC_INSERT_GIAOVIEN '" + txtTeacherID.Text + "','" + txtTeacherName.Text + "','" + txtTeacherBirth.Text + "','" + gender + "','" + txtTeacherAddress.Text + "','" + txtTeacherPhone.Text + "', '"+ txtSubjectID.Text + "', '" + txtSalaryID.Text + "' ";


            SqlCommand cmd = new SqlCommand(sqlInsert, con);

            cmd.ExecuteNonQuery();
            Display();
        }

        private void btnTeacher_edit_Click(object sender, EventArgs e)
        {
            string gender;
            if (radGender_female.Checked)
            {
                gender = radGender_female.Text;
            }
            else
            {
                gender = radGender_male.Text;
            }


            string sqlEdit = "exec PROC_UPDATE_GIAOVIEN '" + txtTeacherID.Text + "','" + txtTeacherName.Text + "','" + txtTeacherBirth.Text + "','" + gender + "','" + txtTeacherAddress.Text + "','" + txtTeacherPhone.Text + "', '" + txtSubjectID.Text + "', '" + txtSalaryID.Text + "' ";


            SqlCommand cmd = new SqlCommand(sqlEdit, con);

            cmd.ExecuteNonQuery();
            Display();
        }

        private void btnTeacher_delete_Click(object sender, EventArgs e)
        {
            string sqlupdateDelete1 = "update LOPHOC set MaGiaoVien = null where MaGiaoVien = '" + txtTeacherID.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(sqlupdateDelete1, con);
            cmd1.ExecuteNonQuery();


            string sqlupdateDelete2 = "update BLTRALUONG set MaGiaoVien = null where MaGiaoVien = '" + txtTeacherID.Text + "' ";
            SqlCommand cmd2 = new SqlCommand(sqlupdateDelete2, con);
            cmd2.ExecuteNonQuery();


            string sqlDelete = "exec PROC_DELETE_GIAOVIEN '" + txtTeacherID.Text + "'";

            SqlCommand cmd = new SqlCommand(sqlDelete, con);
         
            cmd.ExecuteNonQuery();
            Display();
        }

        private void btnTeacher_clear_Click(object sender, EventArgs e)
        {
            txtTeacherID.Text = "";
            txtTeacherName.Text = "";
            txtTeacherBirth.Text = "MM/DD/YYYY";
            txtTeacherBirth.ForeColor = Color.Silver;
            radGender_male.Checked = true;
            txtTeacherAddress.Text = "";
            txtTeacherPhone.Text = "";
            txtSubjectID.Text = "";
            txtSalaryID.Text = "";
            txtTeacherSearch.Text = "";
        }

        private void btnTeacher_search_Click(object sender, EventArgs e)
        {
            if (cmbTeacher.SelectedItem == "Mã giáo viên")
            {
                string sqlCode1 = "Select * from DBO.FUNC_SEARCH_GV_MAGV('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Tên giáo viên")
            {
                string sqlCode1 = "Select * from DBO.FUNC_SEARCH_GV_TENGV('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Ngày sinh")
            {
                string sqlCode1 = "Select * from DBO.FUNC_SEARCH_GV_NGAYSINH('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Giới tính")
            {
                string sqlCode1 = "Select * from DBO.FUNC_SEARCH_GV_GIOITINH('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Địa chỉ")
            {
                string sqlCode1 = "Select * from DBO.FUNC_SEARCH_GV_DIACHI('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Số điện thoại")
            {
                string sqlCode1 = "Select * from DBO.FUNC_SEARCH_GV_SDT('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Mã môn học")
            {
                string sqlCode1 = "Select * from DBO.FUNC_SEARCH_GV_MAMH('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }

            if (cmbTeacher.SelectedItem == "Mã mức TT")
            {
                string sqlCode1 = "Select * from DBO.FUNC_SEARCH_GV_MAMTT('" + txtTeacherSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode1, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvTeacher.DataSource = dataTable;
            }
        }


        private void btnTeacher_all_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void dgvTeacher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvTeacher.CurrentRow.Index;
            txtTeacherID.Text = dgvTeacher.Rows[i].Cells[0].Value.ToString();
            txtTeacherName.Text = dgvTeacher.Rows[i].Cells[1].Value.ToString();
            txtTeacherBirth.Text = dgvTeacher.Rows[i].Cells[2].Value.ToString();
            //radGender_male.Checked = dgvStudent.Rows[i].Cells[3].Value.ToString();
            txtTeacherAddress.Text = dgvTeacher.Rows[i].Cells[4].Value.ToString();
            txtTeacherPhone.Text = dgvTeacher.Rows[i].Cells[5].Value.ToString();
            txtSubjectID.Text = dgvTeacher.Rows[i].Cells[6].Value.ToString();
            txtSalaryID.Text = dgvTeacher.Rows[i].Cells[7].Value.ToString();
        }

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
