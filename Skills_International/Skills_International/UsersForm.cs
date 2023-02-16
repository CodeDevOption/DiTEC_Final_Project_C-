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
 * Created Date:2023/02/04
 * Last Edited Date: Date:2023/02/05
 * All Right Reserved
 */


namespace Skills_International
{
    public partial class UsersForm : Form
    {
        //Get Sql Server Connectinon from Connectin Class
        SqlConnection con = new Connection().GetConnection();

        SqlCommand cmd;

        public UsersForm()
        {
            InitializeComponent();
        }

        private void DataLoad() {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Users", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            usersDataGridView.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                //Store StudentForm Data in to Variables 
                string username = txtUsername.Text;
                string passowrd = "";
                if (txtPassowrd.Text == txtComPassword.Text)
                {
                    passowrd = txtPassowrd.Text;
                }
                else {
                    MessageBox.Show("Passoword and Comfirm  Password Dose not Match ", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                }


                //Check Value is Empty?
                if (username == "" || passowrd == "")
                {
                    MessageBox.Show("Missing Imprtant Values Plese Check Your Data Again", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Users VALUES('" + username + "','" + passowrd + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added Succesfully", "Regiser Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //StudentForm Clear Method
        private void Clear()
        {
            txtUsername.Clear();
            txtPassowrd.Clear();
            txtComPassword.Clear();
        }


        private void UsersForm_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                //Store StudentForm Data in to Variables 
                string username = txtUsername.Text;
                string passowrd = "";
                if (txtPassowrd.Text == txtComPassword.Text)
                {
                    passowrd = txtPassowrd.Text;
                }
                else
                {
                    MessageBox.Show("Passoword and Comfirm  Password Dose not Match ", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                //Check Value is Empty?
                if (username == "" || passowrd == "")
                {
                    MessageBox.Show("Missing Imprtant Values Plese Check Your Data Again", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE Users SET Username='" + username + "', Password='" + passowrd + "' WHERE Username='" + username + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Succesfully", "Regiser Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void usersDataGridView_Click(object sender, EventArgs e)
        {
            txtUsername.Text = usersDataGridView.CurrentRow.Cells[0].Value.ToString();
            txtPassowrd.Text = usersDataGridView.CurrentRow.Cells[1].Value.ToString();
            txtComPassword.Text = usersDataGridView.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure, Do you really want to Delete this Record..?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string username = txtUsername.Text;
                    cmd = new SqlCommand("DELETE FROM Users WHERE Username='" + username + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added Succesfully", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void UsersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomeForm hf = new HomeForm();
            hf.Show();
        }

    }
}
