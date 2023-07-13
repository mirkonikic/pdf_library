namespace pdf.Client.AdminUserControls
{
    partial class AllUsersUC
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
            this.users_dgv = new System.Windows.Forms.DataGridView();
            this.delete_btn = new System.Windows.Forms.Button();
            this.show_btn = new System.Windows.Forms.Button();
            this.filter_value_txt = new System.Windows.Forms.TextBox();
            this.user_crit_combo = new System.Windows.Forms.ComboBox();
            this.filter_chk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.users_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // users_dgv
            // 
            this.users_dgv.AllowUserToAddRows = false;
            this.users_dgv.AllowUserToDeleteRows = false;
            this.users_dgv.AllowUserToResizeColumns = false;
            this.users_dgv.AllowUserToResizeRows = false;
            this.users_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.users_dgv.Location = new System.Drawing.Point(13, 15);
            this.users_dgv.Name = "users_dgv";
            this.users_dgv.ReadOnly = true;
            this.users_dgv.RowHeadersWidth = 51;
            this.users_dgv.RowTemplate.Height = 24;
            this.users_dgv.Size = new System.Drawing.Size(1100, 478);
            this.users_dgv.TabIndex = 0;
            // 
            // delete_btn
            // 
            this.delete_btn.BackColor = System.Drawing.Color.DarkTurquoise;
            this.delete_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.delete_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.delete_btn.Location = new System.Drawing.Point(13, 545);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(137, 36);
            this.delete_btn.TabIndex = 1;
            this.delete_btn.Text = "delete";
            this.delete_btn.UseVisualStyleBackColor = false;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // show_btn
            // 
            this.show_btn.BackColor = System.Drawing.Color.Black;
            this.show_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.show_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.show_btn.Location = new System.Drawing.Point(976, 545);
            this.show_btn.Name = "show_btn";
            this.show_btn.Size = new System.Drawing.Size(137, 36);
            this.show_btn.TabIndex = 2;
            this.show_btn.Text = "show";
            this.show_btn.UseVisualStyleBackColor = false;
            this.show_btn.Click += new System.EventHandler(this.show_btn_Click);
            // 
            // filter_value_txt
            // 
            this.filter_value_txt.Location = new System.Drawing.Point(967, 509);
            this.filter_value_txt.Name = "filter_value_txt";
            this.filter_value_txt.Size = new System.Drawing.Size(146, 22);
            this.filter_value_txt.TabIndex = 3;
            // 
            // user_crit_combo
            // 
            this.user_crit_combo.FormattingEnabled = true;
            this.user_crit_combo.Location = new System.Drawing.Point(840, 509);
            this.user_crit_combo.Name = "user_crit_combo";
            this.user_crit_combo.Size = new System.Drawing.Size(121, 24);
            this.user_crit_combo.TabIndex = 8;
            // 
            // filter_chk
            // 
            this.filter_chk.AutoSize = true;
            this.filter_chk.Location = new System.Drawing.Point(908, 554);
            this.filter_chk.Name = "filter_chk";
            this.filter_chk.Size = new System.Drawing.Size(53, 20);
            this.filter_chk.TabIndex = 9;
            this.filter_chk.Text = "filter";
            this.filter_chk.UseVisualStyleBackColor = true;
            // 
            // AllUsersUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filter_chk);
            this.Controls.Add(this.user_crit_combo);
            this.Controls.Add(this.filter_value_txt);
            this.Controls.Add(this.show_btn);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.users_dgv);
            this.Name = "AllUsersUC";
            this.Size = new System.Drawing.Size(1130, 598);
            ((System.ComponentModel.ISupportInitialize)(this.users_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView users_dgv;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button show_btn;
        private System.Windows.Forms.TextBox filter_value_txt;
        private System.Windows.Forms.ComboBox user_crit_combo;
        private System.Windows.Forms.CheckBox filter_chk;
    }
}
