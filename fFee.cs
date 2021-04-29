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
    public partial class fFee : Form
    {
        public fFee()
        {
            InitializeComponent();
        }

        private void btnFee_bill_Click(object sender, EventArgs e)
        {
            txtFeeBill_id.Enabled = true;
            txtFeeBill_studentID.Enabled = true;
            txtFeeBill_classID.Enabled = true;
            txtFeeBill_sumDay.Enabled = true;
            txtFeeBill_feePerDay.Enabled = true;
            txtFeeBill_sumFee.Enabled = true;
            txtFeeBill_dateTake.Enabled = true;
            txtFeeBill_takeForDate.Enabled = true;
            ckbTaked.Enabled = true;
            btnFeeBill_add.Enabled = true;
            btnFeeBill_edit.Enabled = true;
            btnFeeBill_delete.Enabled = true;
            btnFeeBill_clear.Enabled = true;
        }

        SqlConnection con;


        private void fFee_Load(object sender, EventArgs e)
        {

            string conString = ConfigurationManager.ConnectionStrings["QLTrungTamHocThem"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();

            string sqlCode = "SELECT top(30) * FROM HOCSINH";
            Display(sqlCode);
            Display1();
        }

        public void Display(string code)
        {
            


            SqlCommand cmd = new SqlCommand(code, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvFee.DataSource = dataTable;
        }

        private void btnFee_search_Click(object sender, EventArgs e)
        {
            if (cmbSalary_search.SelectedItem == "Mã lớp học")
            {

                //string sqlCode2 = "Select * from DBO.FUNC_SEARCH_HS_MAHS('" + txtFeeSearch.Text + "')";
                string sqlCode2 = "Select MaLopHoc, DANHSACHLOP.MaHocSinh, TenHocSinh from HOCSINH, DANHSACHLOP where HOCSINH.MaHocSinh = DANHSACHLOP.MaHocSinh and MaLopHoc = '" + txtFeeSearch.Text + "'";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvFee.DataSource = dataTable;
                Display(sqlCode2);
            }

            if (cmbSalary_search.SelectedItem == "Tên lớp học")
            {

                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_HS_TENHS('" + txtFeeSearch.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvFee.DataSource = dataTable;
                //Display();
            }
        }

        public void Display1()
        {
            string sqlCode = "SELECT * FROM BLTHUHP ";


            SqlCommand cmd = new SqlCommand(sqlCode, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();


            dataTable.Load(dataReader);
            dgvSalary_bill.DataSource = dataTable;
        }

        private void dgvSalary_bill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvSalary_bill.CurrentRow.Index;
            txtFeeBill_id.Text = dgvSalary_bill.Rows[i].Cells[0].Value.ToString();
            txtFeeBill_studentID.Text = dgvSalary_bill.Rows[i].Cells[1].Value.ToString();
            txtFeeBill_classID.Text = dgvSalary_bill.Rows[i].Cells[2].Value.ToString();
            txtFeeBill_sumDay.Text = dgvSalary_bill.Rows[i].Cells[3].Value.ToString();
            txtFeeBill_feePerDay.Text = dgvSalary_bill.Rows[i].Cells[4].Value.ToString();
            txtFeeBill_sumFee.Text = dgvSalary_bill.Rows[i].Cells[5].Value.ToString();
            txtFeeBill_dateTake.Text = dgvSalary_bill.Rows[i].Cells[6].Value.ToString();
            txtFeeBill_takeForDate.Text = dgvSalary_bill.Rows[i].Cells[7].Value.ToString();
            ckbTaked.Checked = (dgvSalary_bill.Rows[i].Cells[8].Value.ToString()=="1");
            if (ckbTaked.Checked)
                ckbTaked.Text = "đã thu";
            else
                ckbTaked.Text = "chưa thu";
        }

        private void ckbTaked_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnFeeBill_search_Click(object sender, EventArgs e)
        {
            if (cmbFeeBill_search.SelectedItem == "Mã biên lai")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_BLTHUHP_MABL('" + txtFeeBill_search.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
              
                dgvSalary_bill.DataSource = dataTable;
            }

            if (cmbFeeBill_search.SelectedItem == "Mã học sinh")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_BLTHUHP_MAHS('" + txtFeeBill_search.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
               
                dgvSalary_bill.DataSource = dataTable;
            }

            if (cmbFeeBill_search.SelectedItem == "Mã lớp học")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_BLTHUHP_MALH('" + txtFeeBill_search.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
               
                dgvSalary_bill.DataSource = dataTable;
            }

            if (cmbFeeBill_search.SelectedItem == "Tổng số buổi")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_BLTHUHP_TONGSB('" + txtFeeBill_search.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
               
                dgvSalary_bill.DataSource = dataTable;
            }

            if (cmbFeeBill_search.SelectedItem == "Học phí/buổi")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_BLTHUHP_HP1B('" + txtFeeBill_search.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                
                dgvSalary_bill.DataSource = dataTable;
            }

            if (cmbFeeBill_search.SelectedItem == "Tổng học phí")
            {
                string sqlCode2 = "Select * from DBO.FUNC_SEARCH_BLTHUHP_TONGHP('" + txtFeeBill_search.Text + "')";

                SqlCommand cmd = new SqlCommand(sqlCode2, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                
                dgvSalary_bill.DataSource = dataTable;
            }

        }

        private void btnFeeBill_add_Click(object sender, EventArgs e)
        {
            string text;

            if (ckbTaked.Checked == false)
                text = "0";
            else
                text = "1";

            string sqlInsert = "exec PROC_INSERT_BLTHUHP '" + txtFeeBill_id.Text + "','" + txtFeeBill_studentID.Text + "','" + txtFeeBill_classID.Text + "','" + txtFeeBill_sumDay.Text + "','" + txtFeeBill_feePerDay.Text + "', '" + txtFeeBill_sumFee.Text + "','" + txtFeeBill_dateTake.Text + "','" + txtFeeBill_takeForDate.Text + "', '" + text + "'";
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.ExecuteNonQuery();

            Display1();
        }

        private void btnFeeBill_edit_Click(object sender, EventArgs e)
        {
            string sqlEdit = "exec PROC_UPDATE_BLTHUHP '" + txtFeeBill_id.Text + "','" + txtFeeBill_studentID.Text + "','" + txtFeeBill_classID.Text + "','" + txtFeeBill_sumDay.Text + "','" + txtFeeBill_feePerDay.Text + "', '" + txtFeeBill_sumFee.Text + "','" + txtFeeBill_dateTake.Text + "','" + txtFeeBill_takeForDate.Text + "', '" + ckbTaked.Checked + "' ";


            SqlCommand cmd = new SqlCommand(sqlEdit, con);

            cmd.ExecuteNonQuery();
            Display1();
        }

        private void btnFeeBill_delete_Click(object sender, EventArgs e)
        {
          
            string sqlDelete = "exec PROC_DELETE_BLTHUHP '" + txtFeeBill_id.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.ExecuteNonQuery();

            Display1();
        }

        private void btnFeeBill_clear_Click(object sender, EventArgs e)
        {
            txtFeeBill_id.Text = "";
            txtFeeBill_studentID.Text = "";
            txtFeeBill_classID.Text = "";
            txtFeeBill_sumDay.Text = "";
            txtFeeBill_feePerDay.Text = "";
            txtFeeBill_sumFee.Text = "";
            txtFeeBill_dateTake.Text = "";
            txtFeeBill_takeForDate.Text = "";
            ckbTaked.Text = "đã thu";
            txtFeeBill_search.Text= "";
            //Display();
            Display1();
        }

        private void btnFeeBill_all_Click(object sender, EventArgs e)
        {
            Display1();
        }

        private void txtFeeBill_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvFee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int i;
            //i = dgvFee.CurrentRow.Index;
            //txtFeeBill_id.Text = dgvSalary_bill.Rows[i].Cells[0].Value.ToString();
            //txtFeeBill_studentID.Text = dgvSalary_bill.Rows[i].Cells[1].Value.ToString();
            //txtFeeBill_classID.Text = dgvSalary_bill.Rows[i].Cells[2].Value.ToString();
            //txtFeeBill_sumDay.Text = dgvSalary_bill.Rows[i].Cells[3].Value.ToString();
            //txtFeeBill_feePerDay.Text = dgvSalary_bill.Rows[i].Cells[4].Value.ToString();
            //txtFeeBill_sumFee.Text = dgvSalary_bill.Rows[i].Cells[5].Value.ToString();
            //txtFeeBill_dateTake.Text = dgvSalary_bill.Rows[i].Cells[6].Value.ToString();
            //txtFeeBill_takeForDate.Text = dgvSalary_bill.Rows[i].Cells[7].Value.ToString();
            //ckbTaked.Checked = (dgvSalary_bill.Rows[i].Cells[8].Value.ToString() == "1");
        }
    }
}
