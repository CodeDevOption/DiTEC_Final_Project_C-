using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
 * Last Edited Date: Date:2023/02/04
 * All Right Recerved
 */

namespace Skills_International
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }
        int presentage = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            presentage += 1;
            loadingProg.Value = presentage;
            lblPresentage.Text = presentage + "%";
            if (loadingProg.Value == 100)
            {
                timer1.Stop();
                this.Hide();
                LoginForm logf = new LoginForm();
                logf.Show();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

    }
}
