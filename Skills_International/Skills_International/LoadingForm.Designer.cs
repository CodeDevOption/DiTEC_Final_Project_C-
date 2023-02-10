namespace Skills_International
{
    partial class LoadingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            this.loadingProg = new Bunifu.UI.WinForms.BunifuProgressBar();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblPresentage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loadingProg
            // 
            this.loadingProg.AllowAnimations = false;
            this.loadingProg.Animation = 0;
            this.loadingProg.AnimationSpeed = 220;
            this.loadingProg.AnimationStep = 10;
            this.loadingProg.BackColor = System.Drawing.Color.Transparent;
            this.loadingProg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadingProg.BackgroundImage")));
            this.loadingProg.BorderColor = System.Drawing.Color.Transparent;
            this.loadingProg.BorderRadius = 9;
            this.loadingProg.BorderThickness = 1;
            this.loadingProg.Location = new System.Drawing.Point(-4, 278);
            this.loadingProg.Maximum = 100;
            this.loadingProg.MaximumValue = 100;
            this.loadingProg.Minimum = 0;
            this.loadingProg.MinimumValue = 0;
            this.loadingProg.Name = "loadingProg";
            this.loadingProg.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.loadingProg.ProgressBackColor = System.Drawing.Color.Transparent;
            this.loadingProg.ProgressColorLeft = System.Drawing.Color.DodgerBlue;
            this.loadingProg.ProgressColorRight = System.Drawing.Color.DodgerBlue;
            this.loadingProg.Size = new System.Drawing.Size(513, 13);
            this.loadingProg.TabIndex = 0;
            this.loadingProg.Value = 0;
            this.loadingProg.ValueByTransition = 0;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(141, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = " Skills International";
            // 
            // lblPresentage
            // 
            this.lblPresentage.AutoSize = true;
            this.lblPresentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresentage.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblPresentage.Location = new System.Drawing.Point(251, 256);
            this.lblPresentage.Name = "lblPresentage";
            this.lblPresentage.Size = new System.Drawing.Size(19, 15);
            this.lblPresentage.TabIndex = 1;
            this.lblPresentage.Text = "%";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(177, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(504, 291);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblPresentage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadingProg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuProgressBar loadingProg;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPresentage;
        private System.Windows.Forms.Timer timer1;
    }
}

