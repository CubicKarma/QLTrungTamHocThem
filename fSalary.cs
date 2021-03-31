using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace Thuc_Tap_CSDL
{
    public partial class fSalary : Form
    {
        public fSalary()
        {
            InitializeComponent();
        }

        private void btnSalary_bill_Click(object sender, EventArgs e)
        {
            txtSalaryBill_id.Enabled = true;
            txtSalaryBill_sumDay.Enabled = true;
            txtSalaryBill_sumMoney.Enabled = true;
            txtSalaryBill_teacherID.Enabled = true;
            txtSalaryBill_classID.Enabled = true;
            txtSalaryBill_datePay.Enabled = true;
            txtSalaryBill_datePayFor.Enabled = true;
            ckbPayed.Enabled = true;
            btnSalaryBill_add.Enabled = true;
            btnSalaryBill_edit.Enabled = true;
            btnSalaryBill_delete.Enabled = true;
            btnSalaryBill_clear.Enabled = true;
        }


        SqlConnection con;
    

        public void Display()
        {
            string sqlCode = "SELECT * FROM GIAOVIEN ";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvSalary.DataSource = dataTable;
        }

        private void btnSalary_search_Click(object sender, EventArgs e)
        {
            if (cmbSalary_search.SelectedItem == "Mã môn học")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_GV_MAGV('" + txtSalarySearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvSalary.DataSource = dataTable;
            }

            if (cmbSalary_search.SelectedItem == "Tên môn học")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_GV_TENGV('" + txtSalarySearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvSalary.DataSource = dataTable;
            }
        }

        public void Display1()
        {
            string sqlCode = "SELECT * FROM BLTRALUONG ";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvSalary_bill.DataSource = dataTable;
        }

        private void fSalary_Load(object sender, EventArgs e)
        {

            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            Display();
            Display1();
        }

        private void dgvSalary_bill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvSalary_bill.CurrentRow.Index;
            txtSalaryBill_id.Text = dgvSalary_bill.Rows[i].Cells[0].Value.ToString();
            txtSalaryBill_sumDay.Text = dgvSalary_bill.Rows[i].Cells[1].Value.ToString();
            txtSalaryBill_sumMoney.Text = dgvSalary_bill.Rows[i].Cells[2].Value.ToString();
            txtSalaryBill_teacherID .Text= dgvSalary_bill.Rows[i].Cells[3].Value.ToString();
            txtSalaryBill_classID.Text = dgvSalary_bill.Rows[i].Cells[4].Value.ToString();
            txtSalaryBill_datePay .Text= dgvSalary_bill.Rows[i].Cells[5].Value.ToString();
            txtSalaryBill_datePayFor .Text= dgvSalary_bill.Rows[i].Cells[6].Value.ToString();
            ckbPayed.Checked = (dgvSalary_bill.Rows[i].Cells[7].Value.ToString()=="1");
            if (ckbPayed.Checked)
                ckbPayed.Text = "đã thu";
            else
                ckbPayed.Text = "chưa thu";
        }

        private void btnSalaryBill_add_Click_1(object sender, EventArgs e)
        {
            string text;
            if(ckbPayed.Checked==false)
            
                text = "0";  
            else
            
                text = "1";

           int tongSoBuoiDay;
           tongSoBuoiDay = Int32.Parse(txtSalaryBill_sumDay.Text);


            string sqlInsert = "exec PROC_INSERT_BLTRALUONG '" + txtSalaryBill_id.Text + "','" + txtSalaryBill_teacherID.Text + "','" + txtSalaryBill_classID.Text + "'," + tongSoBuoiDay + ",'" + txtSalaryBill_sumMoney.Text + "', '" + txtSalaryBill_datePay.Text + "','" + txtSalaryBill_datePayFor.Text + "','"+ text + "' ";
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();
            Display1();
        }

        private void btnSalaryBill_edit_Click_1(object sender, EventArgs e)
        {
            string sqlEdit = "exec PROC_UPDATE_BLTRALUONG '" + txtSalaryBill_id.Text + "','" + txtSalaryBill_sumDay.Text + "','" + txtSalaryBill_sumMoney.Text + "','" + txtSalaryBill_teacherID.Text + "','" + txtSalaryBill_classID.Text + "', '" + txtSalaryBill_datePay.Text + "','" + txtSalaryBill_datePayFor.Text + "','" + ckbPayed.Checked + "' ";


            SqlCommand cmd = new SqlCommand(sqlEdit, con);

            cmd.ExecuteNonQuery();
            Display1();
        }

        private void btnSalaryBill_delete_Click_1(object sender, EventArgs e)
        {
            

            string sqlDelete = "exec PROC_DELETE_BLTRALUONG '" + txtSalaryBill_id.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.ExecuteNonQuery();

            Display1();
        }

        private void btnSalaryBill_clear_Click_1(object sender, EventArgs e)
        {
            txtSalaryBill_id.Text = "";
            txtSalaryBill_sumDay.Text = "";
            txtSalaryBill_sumMoney.Text = "";
            txtSalaryBill_teacherID.Text = "";
            txtSalaryBill_classID.Text = "";
            txtSalaryBill_datePay.Text = "";
            txtSalaryBill_datePayFor.Text = "";
            ckbPayed.Text = "đã thu";
            txtSalaryBill_search.Text = "";
            Display();
            Display1();
        }

        private void btnSalaryBill_all_Click(object sender, EventArgs e)
        {
            Display1();
        }

        private void btnSalaryBill_search_Click(object sender, EventArgs e)
        {
            if (cmbSalaryBill_search.SelectedItem == "Mã biên lai")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_BLTRALUONG_MABL('" + txtSalaryBill_search.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvSalary_bill.DataSource = dataTable;
                dgvSalary.DataSource = dataTable;
            }

            if (cmbSalaryBill_search.SelectedItem == "Tổng số buổi dạy")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_BLTRALUONG_TONGSBD('" + txtSalaryBill_search.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvSalary_bill.DataSource = dataTable;
                dgvSalary.DataSource = dataTable;
            }

            if (cmbSalaryBill_search.SelectedItem == "Tổng lương")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_BLTRALUONG_TONGLUONG('" + txtSalaryBill_search.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvSalary_bill.DataSource = dataTable;
                dgvSalary.DataSource = dataTable;
            }

            if (cmbSalaryBill_search.SelectedItem == "Mã giáo viên")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_BLTRALUONG_MAGV('" + txtSalaryBill_search.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvSalary_bill.DataSource = dataTable;
                dgvSalary.DataSource = dataTable;
            }

            if (cmbSalaryBill_search.SelectedItem == "Mã lớp học")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_BLTRALUONG_MALH('" + txtSalaryBill_search.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvSalary_bill.DataSource = dataTable;
                dgvSalary.DataSource = dataTable;
            }
        }

        private void cmbSalaryBill_search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
