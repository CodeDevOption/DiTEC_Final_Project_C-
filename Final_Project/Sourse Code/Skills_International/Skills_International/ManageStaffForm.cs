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
 * Github Profile link: https://github.com/CodeDevOption
 * Created Date:2023/02/14
 * Last Edited Date: Date:2023/02/15
 * All Right Reserved
 */

namespace Skills_International
{
    public partial class ManageStaffForm : Form
    {
        //Get Sql Server Connectinon from Connectin Class
        SqlConnection con = new Connection().GetConnection();

        SqlCommand cmd;

        public ManageStaffForm()
        {
            InitializeComponent();
        }

        private void ManageStaffForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm hf = new HomeForm();
            hf.Show();
        }

        //Manage Staff Form Clear Method
        private void Clear()
        {
            txtFullName.Clear();
            cmbJobTitile.ResetText();
            txtEmail.Clear();
            txtPNo.Clear();
            dtpHireDate.ResetText();
            txtSalary.Clear();
        }

        //DataLoad
        private void DataLoad()
        {
            if (txtSearch.Text == "")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Staff", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                staffDataGridView.DataSource = dt;
            }
            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Staff WHERE Full_Name LIKE '%" + txtSearch.Text + "%' OR Email LIKE '%" + txtSearch.Text + "%' OR Staff_ID LIKE '%" + txtSearch.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                staffDataGridView.DataSource = dt;
            }


        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                //Store StudentForm Data in to Variables 
                string fullName = txtFullName.Text;
                string email = txtEmail.Text;
                string pNo = txtPNo.Text;
                string jobTitle = cmbJobTitile.Text;
                string hireDate = dtpHireDate.Text;
                string salary = txtSalary.Text;


                //Check Value is Empty?
                if (fullName == "" || email == "" || pNo == "" || jobTitle == "" || hireDate == "" || salary == "")
                {
                    MessageBox.Show("Missing Imprtant Values Plese Check Your Data Again", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int pno = int.Parse(pNo);
                    double Salary = double.Parse(salary);

                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Staff VALUES('" + fullName + "','" + email + "'," + pno + ",'" + jobTitle + "','" + hireDate + "'," + salary + ")", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added Succesfully", "Regiser Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void ManageStaffForm_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void staffDataGridView_Click(object sender, EventArgs e)
        {
            lbStafID.Text = staffDataGridView.CurrentRow.Cells[0].Value.ToString();
            txtFullName.Text = staffDataGridView.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = staffDataGridView.CurrentRow.Cells[2].Value.ToString();
            txtPNo.Text = staffDataGridView.CurrentRow.Cells[3].Value.ToString();
            cmbJobTitile.Text = staffDataGridView.CurrentRow.Cells[4].Value.ToString();
            dtpHireDate.Text = staffDataGridView.CurrentRow.Cells[5].Value.ToString();
            txtSalary.Text = staffDataGridView.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                //Store Staff Data in to Variables 
                string fullName = txtFullName.Text;
                string email = txtEmail.Text;
                string pNo = txtPNo.Text;
                string jobTitle = cmbJobTitile.Text;
                string hireDate = dtpHireDate.Text;
                string salary = txtSalary.Text;


                //Check Value is Empty?
                if (fullName == "" || email == "" || pNo == "" || jobTitle == "" || hireDate == "" || salary == "")
                {
                    MessageBox.Show("Missing Imprtant Values Plese Check Your Data Again", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int pno = int.Parse(pNo);
                    double Salary = double.Parse(salary);
                    con.Open();
                    cmd = new SqlCommand("UPDATE Staff SET Full_Name ='" + fullName + "', Email ='" + email + "', PhoneNo =" + pno + ", Job_Title = '" + jobTitle + "', Hire_Date='" + hireDate + "', Salary = " + Salary + " WHERE Staff_ID=" + int.Parse(lbStafID.Text) + "", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Succesfully", "Update Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DialogResult dr = MessageBox.Show("Are you sure, Do you really want to Delete this Record..?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    int stfId = int.Parse(lbStafID.Text);
                    cmd = new SqlCommand("DELETE FROM Staff WHERE Staff_ID =" + stfId + "", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Succesfully", "Delete Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
