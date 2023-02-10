using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skills_International
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you realy want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginForm logf = new LoginForm();
                logf.Show();
            }
        }

        private void btnStnReg_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentForm stnf = new StudentForm();
            stnf.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            btnStnReg_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnStnReg_Click(sender, e);
        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnMngUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForm usf = new UsersForm();
            usf.Show();
        }

    }
}
