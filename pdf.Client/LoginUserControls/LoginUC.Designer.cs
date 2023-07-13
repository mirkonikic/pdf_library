namespace pdf.Client.UserControls
{
    partial class LoginUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwd_txt = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ip_lbl = new System.Windows.Forms.Label();
            this.port_lbl = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "username:";
            // 
            // username_txt
            // 
            this.username_txt.Location = new System.Drawing.Point(287, 11);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(136, 22);
            this.username_txt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "password:";
            // 
            // passwd_txt
            // 
            this.passwd_txt.Location = new System.Drawing.Point(287, 45);
            this.passwd_txt.Name = "passwd_txt";
            this.passwd_txt.PasswordChar = '^';
            this.passwd_txt.Size = new System.Drawing.Size(136, 22);
            this.passwd_txt.TabIndex = 3;
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.login_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.login_btn.Location = new System.Drawing.Point(10, 217);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(137, 36);
            this.login_btn.TabIndex = 4;
            this.login_btn.Text = "login";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "current settings:";
            // 
            // ip_lbl
            // 
            this.ip_lbl.AutoSize = true;
            this.ip_lbl.Location = new System.Drawing.Point(12, 38);
            this.ip_lbl.Name = "ip_lbl";
            this.ip_lbl.Size = new System.Drawing.Size(58, 16);
            this.ip_lbl.TabIndex = 6;
            this.ip_lbl.Text = "127.0.0.1";
            // 
            // port_lbl
            // 
            this.port_lbl.AutoSize = true;
            this.port_lbl.Location = new System.Drawing.Point(76, 38);
            this.port_lbl.Name = "port_lbl";
            this.port_lbl.Size = new System.Drawing.Size(38, 16);
            this.port_lbl.TabIndex = 7;
            this.port_lbl.Text = ":9999";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Cursor = System.Windows.Forms.Cursors.Default;
            this.name_label.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.Location = new System.Drawing.Point(3, 0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(102, 38);
            this.name_label.TabIndex = 8;
            this.name_label.Text = "LOGIN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.name_label);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.username_txt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.login_btn);
            this.panel1.Controls.Add(this.passwd_txt);
            this.panel1.Location = new System.Drawing.Point(346, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 267);
            this.panel1.TabIndex = 9;
            // 
            // LoginUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.port_lbl);
            this.Controls.Add(this.ip_lbl);
            this.Controls.Add(this.label3);
            this.Name = "LoginUC";
            this.Size = new System.Drawing.Size(1130, 598);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwd_txt;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ip_lbl;
        private System.Windows.Forms.Label port_lbl;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Panel panel1;
    }
}
