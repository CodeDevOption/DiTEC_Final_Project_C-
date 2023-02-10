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

    /*
     * Name: Lahiru Sadaruwan
     * RegNo :E161509
     * Github Profile link: 
     * Student Form Created Date:2023/02/04
     * Last Edited Date: Date:2023/02/05
     * All Right Recerved
     */

namespace Skills_International
{

    public partial class StudentForm : Form
    {
        //Get Sql Server Connectinon from Connectin Class
        SqlConnection con = new Connection().GetConnection();

        SqlCommand cmd;

        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        //DataGridView Data Load Custome Method
        private void DataLoad() {
            if (txtSearch.Text == "")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM StudentRegistration", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                studentDataGridView.DataSource = dt;
            }
            else {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM StudentRegistration WHERE FirstName LIKE '%" + txtSearch.Text + "%' OR LastName LIKE '%" + txtSearch.Text + "%' OR NIC LIKE '%" + txtSearch.Text + "%' OR RegNo LIKE '%" + txtSearch.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                studentDataGridView.DataSource = dt;    
            }
            
        }


        //StudentForm Clear Method
        private void Clear(){
            lbStnRegID.Text = "";
            txtFName.Clear();
            txtLName.Clear();
            dpBDate.ResetText();
            male.Checked = false;
            female.Checked = false;
            txtAddress.Clear();
            txtEmail.Clear();
            txtMPNo.Clear();
            txtHPNo.Clear();
            txtPName.Clear();
            txtPNic.Clear();
            txtpConNo.Clear();
        }


        //Student Registration Btn Event Handler
        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {

                //Store StudentForm Data in to Variables 
                string fName = txtFName.Text;
                string lName = txtLName.Text;
                string bDate = dpBDate.Text;
                string gender;
                if (male.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string address = txtAddress.Text;
                string email = txtEmail.Text;
                string mPhNo = txtMPNo.Text;
                string hPhNo = txtHPNo.Text;
                string pName = txtPName.Text;
                string pNic = txtPNic.Text;
                string pconNo = txtpConNo.Text;

                //Check Value is Empty?
                if (fName == "" || lName == "" || bDate == "" || gender == "" || address == "" || email == "" || pName == "" || pNic == "" || pconNo == "")
                {
                    MessageBox.Show("Missing Imprtant Values Plese Check Your Data Again", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int mPNo = int.Parse(mPhNo);
                    int hPNo = int.Parse(hPhNo);
                    int conNo = int.Parse(pconNo);

                    con.Open();
                    cmd = new SqlCommand("INSERT INTO StudentRegistration VALUES('" + fName + "','" + lName + "','" + bDate + "','" + gender + "','" + address + "','" + email + "'," + mPNo + "," + hPNo + ",'" + pName + "','" + pNic + "','" + conNo + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added Succesfully", "Regiser Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                con.Close();
                DataLoad();
            }
            
        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void studentDataGridView_Click(object sender, EventArgs e)
        {
            lbStnRegID.Text = studentDataGridView.CurrentRow.Cells[0].Value.ToString();
            txtFName.Text= studentDataGridView.CurrentRow.Cells[1].Value.ToString();
            txtLName.Text = studentDataGridView.CurrentRow.Cells[2].Value.ToString();
            dpBDate.Text = studentDataGridView.CurrentRow.Cells[3].Value.ToString();
            if (studentDataGridView.CurrentRow.Cells[4].Value.ToString() == "Male")
            {
                male.Checked = true;
            }
            else
            {
                female.Checked = true;
            }
            txtAddress.Text = studentDataGridView.CurrentRow.Cells[5].Value.ToString();
            txtEmail.Text = studentDataGridView.CurrentRow.Cells[6].Value.ToString();
            txtMPNo.Text = studentDataGridView.CurrentRow.Cells[7].Value.ToString();
            txtHPNo.Text = studentDataGridView.CurrentRow.Cells[8].Value.ToString();
            txtPName.Text = studentDataGridView.CurrentRow.Cells[9].Value.ToString();
            txtPNic.Text = studentDataGridView.CurrentRow.Cells[10].Value.ToString();
            txtpConNo.Text = studentDataGridView.CurrentRow.Cells[11].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                //Store StudentForm Data in to Variables 
                string rno = lbStnRegID.Text; 
                string fName = txtFName.Text;
                string lName = txtLName.Text;
                string bDate = dpBDate.Text;
                string gender;
                if (male.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string address = txtAddress.Text;
                string email = txtEmail.Text;
                string mPhNo = txtMPNo.Text;
                string hPhNo = txtHPNo.Text;
                string pName = txtPName.Text;
                string pNic = txtPNic.Text;
                string pconNo = txtpConNo.Text;

                //Check Value is Empty?
                if (fName == "" || lName == "" || bDate == "" || gender == "" || address == "" || email == "" || pName == "" || pNic == "" || pconNo == "" || rno == "")
                {
                    MessageBox.Show("Missing Imprtant Values Plese Check Your Data Again", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int mPNo = int.Parse(mPhNo);
                    int hPNo = int.Parse(hPhNo);
                    int conNo = int.Parse(pconNo);
                    int regNo = int.Parse(rno);

                    con.Open();
                    cmd = new SqlCommand("UPDATE StudentRegistration SET FirstName ='" + fName + "', LastName ='" + lName + "', DateOfBirth ='" + bDate + "', Gender ='" + gender + "', Address ='" + address + "', Email ='" + email + "', MobilePhone =" + mPhNo + ",HomePhone =" + hPNo + ", ParentName ='" + pName + "', NIC ='" + pNic + "',ContactNo=" + conNo + " WHERE RegNo=" + regNo + "", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Succesfully", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                DataLoad();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Are you sure, Do you really want to Delete this Record..?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    int regNo = int.Parse(lbStnRegID.Text);
                    cmd = new SqlCommand("DELETE FROM StudentRegistration WHERE RegNo=" + regNo + "", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added Succesfully", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                    DataLoad();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm hf = new HomeForm();
            hf.Show();

        }

    }
}
