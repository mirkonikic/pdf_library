﻿namespace pdf.Client.UserUserControls
{
    partial class AllBooksUC
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
            this.filter_chk = new System.Windows.Forms.CheckBox();
            this.book_crit_combo = new System.Windows.Forms.ComboBox();
            this.filter_value_txt = new System.Windows.Forms.TextBox();
            this.show_btn = new System.Windows.Forms.Button();
            this.books_dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.books_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // filter_chk
            // 
            this.filter_chk.AutoSize = true;
            this.filter_chk.Location = new System.Drawing.Point(682, 451);
            this.filter_chk.Margin = new System.Windows.Forms.Padding(2);
            this.filter_chk.Name = "filter_chk";
            this.filter_chk.Size = new System.Drawing.Size(45, 17);
            this.filter_chk.TabIndex = 21;
            this.filter_chk.Text = "filter";
            this.filter_chk.UseVisualStyleBackColor = true;
            // 
            // book_crit_combo
            // 
            this.book_crit_combo.FormattingEnabled = true;
            this.book_crit_combo.Location = new System.Drawing.Point(632, 414);
            this.book_crit_combo.Margin = new System.Windows.Forms.Padding(2);
            this.book_crit_combo.Name = "book_crit_combo";
            this.book_crit_combo.Size = new System.Drawing.Size(92, 21);
            this.book_crit_combo.TabIndex = 20;
            // 
            // filter_value_txt
            // 
            this.filter_value_txt.Location = new System.Drawing.Point(727, 414);
            this.filter_value_txt.Margin = new System.Windows.Forms.Padding(2);
            this.filter_value_txt.Name = "filter_value_txt";
            this.filter_value_txt.Size = new System.Drawing.Size(110, 20);
            this.filter_value_txt.TabIndex = 19;
            // 
            // show_btn
            // 
            this.show_btn.BackColor = System.Drawing.Color.Black;
            this.show_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.show_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.show_btn.Location = new System.Drawing.Point(734, 444);
            this.show_btn.Margin = new System.Windows.Forms.Padding(2);
            this.show_btn.Name = "show_btn";
            this.show_btn.Size = new System.Drawing.Size(103, 29);
            this.show_btn.TabIndex = 18;
            this.show_btn.Text = "show";
            this.show_btn.UseVisualStyleBackColor = false;
            this.show_btn.Click += new System.EventHandler(this.show_btn_Click);
            // 
            // books_dgv
            // 
            this.books_dgv.AllowUserToAddRows = false;
            this.books_dgv.AllowUserToDeleteRows = false;
            this.books_dgv.AllowUserToResizeColumns = false;
            this.books_dgv.AllowUserToResizeRows = false;
            this.books_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.books_dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.books_dgv.Location = new System.Drawing.Point(11, 13);
            this.books_dgv.Margin = new System.Windows.Forms.Padding(2);
            this.books_dgv.MultiSelect = false;
            this.books_dgv.Name = "books_dgv";
            this.books_dgv.ReadOnly = true;
            this.books_dgv.RowHeadersWidth = 51;
            this.books_dgv.RowTemplate.Height = 24;
            this.books_dgv.Size = new System.Drawing.Size(825, 388);
            this.books_dgv.TabIndex = 16;
            // 
            // AllBooksUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filter_chk);
            this.Controls.Add(this.book_crit_combo);
            this.Controls.Add(this.filter_value_txt);
            this.Controls.Add(this.show_btn);
            this.Controls.Add(this.books_dgv);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AllBooksUC";
            this.Size = new System.Drawing.Size(848, 486);
            ((System.ComponentModel.ISupportInitialize)(this.books_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox filter_chk;
        private System.Windows.Forms.ComboBox book_crit_combo;
        private System.Windows.Forms.TextBox filter_value_txt;
        private System.Windows.Forms.Button show_btn;
        private System.Windows.Forms.DataGridView books_dgv;
    }
}
