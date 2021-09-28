namespace DBConnect
{
    partial class ServerSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.DataSource_TXT = new System.Windows.Forms.TextBox();
            this.UserName_TXT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Password_TXT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Database_TXT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CancelCon_BTN = new System.Windows.Forms.Button();
            this.SaveCon_BTN = new System.Windows.Forms.Button();
            this.TestCon_BTN = new System.Windows.Forms.Button();
            this.Change_BTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Source";
            // 
            // DataSource_TXT
            // 
            this.DataSource_TXT.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DBConnect.Properties.Settings.Default, "DataSource", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataSource_TXT.Location = new System.Drawing.Point(17, 37);
            this.DataSource_TXT.Name = "DataSource_TXT";
            this.DataSource_TXT.Size = new System.Drawing.Size(333, 26);
            this.DataSource_TXT.TabIndex = 1;
            this.DataSource_TXT.Text = global::DBConnect.Properties.Settings.Default.DataSource;
            // 
            // UserName_TXT
            // 
            this.UserName_TXT.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DBConnect.Properties.Settings.Default, "UserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UserName_TXT.Location = new System.Drawing.Point(17, 106);
            this.UserName_TXT.Name = "UserName_TXT";
            this.UserName_TXT.Size = new System.Drawing.Size(333, 26);
            this.UserName_TXT.TabIndex = 3;
            this.UserName_TXT.Text = global::DBConnect.Properties.Settings.Default.UserName;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // Password_TXT
            // 
            this.Password_TXT.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DBConnect.Properties.Settings.Default, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Password_TXT.Location = new System.Drawing.Point(17, 175);
            this.Password_TXT.Name = "Password_TXT";
            this.Password_TXT.Size = new System.Drawing.Size(333, 26);
            this.Password_TXT.TabIndex = 5;
            this.Password_TXT.Text = global::DBConnect.Properties.Settings.Default.Password;
            this.Password_TXT.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // Database_TXT
            // 
            this.Database_TXT.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DBConnect.Properties.Settings.Default, "Database", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Database_TXT.Location = new System.Drawing.Point(16, 244);
            this.Database_TXT.Name = "Database_TXT";
            this.Database_TXT.Size = new System.Drawing.Size(333, 26);
            this.Database_TXT.TabIndex = 7;
            this.Database_TXT.Text = global::DBConnect.Properties.Settings.Default.Database;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Database";
            // 
            // CancelCon_BTN
            // 
            this.CancelCon_BTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelCon_BTN.Location = new System.Drawing.Point(274, 284);
            this.CancelCon_BTN.Name = "CancelCon_BTN";
            this.CancelCon_BTN.Size = new System.Drawing.Size(75, 30);
            this.CancelCon_BTN.TabIndex = 8;
            this.CancelCon_BTN.Text = "Cancel";
            this.CancelCon_BTN.UseVisualStyleBackColor = true;
            this.CancelCon_BTN.Click += new System.EventHandler(this.CancelCon_BTN_Click);
            // 
            // SaveCon_BTN
            // 
            this.SaveCon_BTN.Location = new System.Drawing.Point(193, 284);
            this.SaveCon_BTN.Name = "SaveCon_BTN";
            this.SaveCon_BTN.Size = new System.Drawing.Size(75, 30);
            this.SaveCon_BTN.TabIndex = 9;
            this.SaveCon_BTN.Text = "Save";
            this.SaveCon_BTN.UseVisualStyleBackColor = true;
            this.SaveCon_BTN.Click += new System.EventHandler(this.SaveCon_BTN_Click);
            // 
            // TestCon_BTN
            // 
            this.TestCon_BTN.Location = new System.Drawing.Point(112, 284);
            this.TestCon_BTN.Name = "TestCon_BTN";
            this.TestCon_BTN.Size = new System.Drawing.Size(75, 30);
            this.TestCon_BTN.TabIndex = 10;
            this.TestCon_BTN.Text = "Test";
            this.TestCon_BTN.UseVisualStyleBackColor = true;
            this.TestCon_BTN.Click += new System.EventHandler(this.TestCon_BTN_Click);
            // 
            // Change_BTN
            // 
            this.Change_BTN.Location = new System.Drawing.Point(17, 284);
            this.Change_BTN.Name = "Change_BTN";
            this.Change_BTN.Size = new System.Drawing.Size(75, 30);
            this.Change_BTN.TabIndex = 12;
            this.Change_BTN.Text = "Change";
            this.Change_BTN.UseVisualStyleBackColor = true;
            this.Change_BTN.Click += new System.EventHandler(this.Change_BTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DBConnect.Properties.Resources.united_states_technical_support_it_logo_design;
            this.pictureBox1.Location = new System.Drawing.Point(356, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // ServerSettings
            // 
            this.AcceptButton = this.SaveCon_BTN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelCon_BTN;
            this.ClientSize = new System.Drawing.Size(668, 329);
            this.Controls.Add(this.Change_BTN);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TestCon_BTN);
            this.Controls.Add(this.SaveCon_BTN);
            this.Controls.Add(this.CancelCon_BTN);
            this.Controls.Add(this.Database_TXT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Password_TXT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserName_TXT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataSource_TXT);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerSettings";
            this.Text = "Manage Connection";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DataSource_TXT;
        private System.Windows.Forms.TextBox UserName_TXT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Password_TXT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Database_TXT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CancelCon_BTN;
        private System.Windows.Forms.Button SaveCon_BTN;
        private System.Windows.Forms.Button TestCon_BTN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Change_BTN;
    }
}