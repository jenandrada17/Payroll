namespace DBConnect.Tools
{
    partial class Backup
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
            this.BackUp_BTN = new System.Windows.Forms.Button();
            this.Path_TXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FileName_TXT = new System.Windows.Forms.TextBox();
            this.Restore_BTN = new System.Windows.Forms.Button();
            this.Log_Console = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackUp_BTN
            // 
            this.BackUp_BTN.Location = new System.Drawing.Point(103, 391);
            this.BackUp_BTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BackUp_BTN.Name = "BackUp_BTN";
            this.BackUp_BTN.Size = new System.Drawing.Size(112, 35);
            this.BackUp_BTN.TabIndex = 0;
            this.BackUp_BTN.Text = "Backup Now";
            this.BackUp_BTN.UseVisualStyleBackColor = true;
            this.BackUp_BTN.Click += new System.EventHandler(this.BackUp_BTN_Click);
            // 
            // Path_TXT
            // 
            this.Path_TXT.Location = new System.Drawing.Point(29, 37);
            this.Path_TXT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Path_TXT.Name = "Path_TXT";
            this.Path_TXT.ReadOnly = true;
            this.Path_TXT.Size = new System.Drawing.Size(402, 26);
            this.Path_TXT.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "File Name: ";
            // 
            // FileName_TXT
            // 
            this.FileName_TXT.Location = new System.Drawing.Point(29, 100);
            this.FileName_TXT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileName_TXT.Name = "FileName_TXT";
            this.FileName_TXT.Size = new System.Drawing.Size(402, 26);
            this.FileName_TXT.TabIndex = 3;
            // 
            // Restore_BTN
            // 
            this.Restore_BTN.Location = new System.Drawing.Point(223, 391);
            this.Restore_BTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Restore_BTN.Name = "Restore_BTN";
            this.Restore_BTN.Size = new System.Drawing.Size(112, 35);
            this.Restore_BTN.TabIndex = 5;
            this.Restore_BTN.Text = "Restore";
            this.Restore_BTN.UseVisualStyleBackColor = true;
            this.Restore_BTN.Click += new System.EventHandler(this.Restore_BTN_Click);
            // 
            // Log_Console
            // 
            this.Log_Console.AutoWordSelection = true;
            this.Log_Console.Location = new System.Drawing.Point(11, 163);
            this.Log_Console.Name = "Log_Console";
            this.Log_Console.ReadOnly = true;
            this.Log_Console.Size = new System.Drawing.Size(433, 220);
            this.Log_Console.TabIndex = 6;
            this.Log_Console.Text = "";
            this.Log_Console.WordWrap = false;
            this.Log_Console.TextChanged += new System.EventHandler(this.Log_Console_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Events:";
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 440);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Log_Console);
            this.Controls.Add(this.Restore_BTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FileName_TXT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Path_TXT);
            this.Controls.Add(this.BackUp_BTN);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Backup";
            this.Text = "Backup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackUp_BTN;
        private System.Windows.Forms.TextBox Path_TXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FileName_TXT;
        private System.Windows.Forms.Button Restore_BTN;
        private System.Windows.Forms.RichTextBox Log_Console;
        private System.Windows.Forms.Label label3;
    }
}