namespace pdf.Client.LoginUserControls
{
    partial class RegisterUC
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
            this.port_lbl = new System.Windows.Forms.Label();
            this.ip_lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.name_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwd_txt = new System.Windows.Forms.TextBox();
            this.firstname_txt = new System.Windows.Forms.TextBox();
            this.lastname_txt = new System.Windows.Forms.TextBox();
            this.address_txt = new System.Windows.Forms.TextBox();
            this.email_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.register_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // port_lbl
            // 
            this.port_lbl.AutoSize = true;
            this.port_lbl.Location = new System.Drawing.Point(76, 38);
            this.port_lbl.Name = "port_lbl";
            this.port_lbl.Size = new System.Drawing.Size(38, 16);
            this.port_lbl.TabIndex = 10;
            this.port_lbl.Text = ":9999";
            // 
            // ip_lbl
            // 
            this.ip_lbl.AutoSize = true;
            this.ip_lbl.Location = new System.Drawing.Point(12, 38);
            this.ip_lbl.Name = "ip_lbl";
            this.ip_lbl.Size = new System.Drawing.Size(58, 16);
            this.ip_lbl.TabIndex = 9;
            this.ip_lbl.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "current settings:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.register_btn);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.email_txt);
            this.panel1.Controls.Add(this.address_txt);
            this.panel1.Controls.Add(this.lastname_txt);
            this.panel1.Controls.Add(this.firstname_txt);
            this.panel1.Controls.Add(this.name_label);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.username_txt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.passwd_txt);
            this.panel1.Location = new System.Drawing.Point(346, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 267);
            this.panel1.TabIndex = 11;
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Cursor = System.Windows.Forms.Cursors.Default;
            this.name_label.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.Location = new System.Drawing.Point(3, 0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(144, 38);
            this.name_label.TabIndex = 8;
            this.name_label.Text = "REGISTER";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 14);
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
            this.label2.Location = new System.Drawing.Point(210, 48);
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
            // firstname_txt
            // 
            this.firstname_txt.Location = new System.Drawing.Point(287, 79);
            this.firstname_txt.Name = "firstname_txt";
            this.firstname_txt.Size = new System.Drawing.Size(136, 22);
            this.firstname_txt.TabIndex = 9;
            // 
            // lastname_txt
            // 
            this.lastname_txt.Location = new System.Drawing.Point(287, 113);
            this.lastname_txt.Name = "lastname_txt";
            this.lastname_txt.Size = new System.Drawing.Size(136, 22);
            this.lastname_txt.TabIndex = 10;
            // 
            // address_txt
            // 
            this.address_txt.Location = new System.Drawing.Point(287, 147);
            this.address_txt.Name = "address_txt";
            this.address_txt.Size = new System.Drawing.Size(136, 22);
            this.address_txt.TabIndex = 11;
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(287, 181);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(136, 22);
            this.email_txt.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "first_name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "last_name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "address:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "email:";
            // 
            // register_btn
            // 
            this.register_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.register_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.register_btn.Location = new System.Drawing.Point(10, 217);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(137, 36);
            this.register_btn.TabIndex = 16;
            this.register_btn.Text = "register";
            this.register_btn.UseVisualStyleBackColor = false;
            this.register_btn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // RegisterUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.port_lbl);
            this.Controls.Add(this.ip_lbl);
            this.Controls.Add(this.label3);
            this.Name = "RegisterUC";
            this.Size = new System.Drawing.Size(1130, 598);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label port_lbl;
        private System.Windows.Forms.Label ip_lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwd_txt;
        private System.Windows.Forms.TextBox email_txt;
        private System.Windows.Forms.TextBox address_txt;
        private System.Windows.Forms.TextBox lastname_txt;
        private System.Windows.Forms.TextBox firstname_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button register_btn;
    }
}
