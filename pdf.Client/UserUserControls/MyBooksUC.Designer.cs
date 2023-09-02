namespace pdf.Client.UserUserControls
{
    partial class MyBooksUC
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
            this.save_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.status_dgv = new System.Windows.Forms.DataGridView();
            this.book_list = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.status_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.Black;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.save_btn.Location = new System.Drawing.Point(979, 546);
            this.save_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(137, 36);
            this.save_btn.TabIndex = 18;
            this.save_btn.Text = "save";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.BackColor = System.Drawing.Color.Aquamarine;
            this.add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.add_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.add_btn.Location = new System.Drawing.Point(340, 241);
            this.add_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(43, 36);
            this.add_btn.TabIndex = 17;
            this.add_btn.Text = "=>";
            this.add_btn.UseVisualStyleBackColor = false;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // status_dgv
            // 
            this.status_dgv.AllowUserToAddRows = false;
            this.status_dgv.AllowUserToDeleteRows = false;
            this.status_dgv.AllowUserToResizeColumns = false;
            this.status_dgv.AllowUserToResizeRows = false;
            this.status_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.status_dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.status_dgv.Location = new System.Drawing.Point(388, 16);
            this.status_dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.status_dgv.MultiSelect = false;
            this.status_dgv.Name = "status_dgv";
            this.status_dgv.RowHeadersWidth = 51;
            this.status_dgv.RowTemplate.Height = 24;
            this.status_dgv.Size = new System.Drawing.Size(727, 500);
            this.status_dgv.TabIndex = 16;
            this.status_dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.status_dgv_CellEndEdit);
            this.status_dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.status_dgv_DataError);
            // 
            // book_list
            // 
            this.book_list.FormattingEnabled = true;
            this.book_list.ItemHeight = 16;
            this.book_list.Location = new System.Drawing.Point(15, 18);
            this.book_list.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.book_list.Name = "book_list";
            this.book_list.Size = new System.Drawing.Size(319, 564);
            this.book_list.TabIndex = 19;
            // 
            // MyBooksUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.book_list);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.status_dgv);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MyBooksUC";
            this.Size = new System.Drawing.Size(1131, 598);
            this.Load += new System.EventHandler(this.MyBooksUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.status_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.DataGridView status_dgv;
        private System.Windows.Forms.ListBox book_list;
    }
}
