namespace pdf.Client.AdminUserControls
{
    partial class CreateBookUC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.publisher_combo = new System.Windows.Forms.ComboBox();
            this.author_combo = new System.Windows.Forms.ComboBox();
            this.save_button = new System.Windows.Forms.Button();
            this.book_label = new System.Windows.Forms.Label();
            this.check_button = new System.Windows.Forms.Button();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.name_lbl = new System.Windows.Forms.Label();
            this.pagenum_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.isbn_txt = new System.Windows.Forms.TextBox();
            this.format_combo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.published_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.zanr_combo = new System.Windows.Forms.ComboBox();
            this.jezik_combo = new System.Windows.Forms.ComboBox();
            this.opis_txt = new System.Windows.Forms.TextBox();
            this.verzija_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.verzija_txt);
            this.panel1.Controls.Add(this.opis_txt);
            this.panel1.Controls.Add(this.jezik_combo);
            this.panel1.Controls.Add(this.zanr_combo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.published_date);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.format_combo);
            this.panel1.Controls.Add(this.isbn_txt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pagenum_txt);
            this.panel1.Controls.Add(this.name_lbl);
            this.panel1.Controls.Add(this.name_txt);
            this.panel1.Controls.Add(this.publisher_combo);
            this.panel1.Controls.Add(this.author_combo);
            this.panel1.Controls.Add(this.save_button);
            this.panel1.Controls.Add(this.book_label);
            this.panel1.Controls.Add(this.check_button);
            this.panel1.Location = new System.Drawing.Point(308, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 460);
            this.panel1.TabIndex = 0;
            // 
            // publisher_combo
            // 
            this.publisher_combo.FormattingEnabled = true;
            this.publisher_combo.Location = new System.Drawing.Point(330, 304);
            this.publisher_combo.Name = "publisher_combo";
            this.publisher_combo.Size = new System.Drawing.Size(176, 24);
            this.publisher_combo.TabIndex = 5;
            // 
            // author_combo
            // 
            this.author_combo.FormattingEnabled = true;
            this.author_combo.Location = new System.Drawing.Point(330, 274);
            this.author_combo.Name = "author_combo";
            this.author_combo.Size = new System.Drawing.Size(176, 24);
            this.author_combo.TabIndex = 4;
            // 
            // save_button
            // 
            this.save_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save_button.Location = new System.Drawing.Point(264, 410);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(137, 36);
            this.save_button.TabIndex = 3;
            this.save_button.Text = "save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // book_label
            // 
            this.book_label.AutoSize = true;
            this.book_label.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.book_label.Location = new System.Drawing.Point(3, 2);
            this.book_label.Name = "book_label";
            this.book_label.Size = new System.Drawing.Size(95, 38);
            this.book_label.TabIndex = 2;
            this.book_label.Text = "BOOK";
            // 
            // check_button
            // 
            this.check_button.BackColor = System.Drawing.Color.DarkOrange;
            this.check_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.check_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.check_button.Location = new System.Drawing.Point(121, 410);
            this.check_button.Name = "check_button";
            this.check_button.Size = new System.Drawing.Size(137, 36);
            this.check_button.TabIndex = 2;
            this.check_button.Text = "check";
            this.check_button.UseVisualStyleBackColor = false;
            this.check_button.Click += new System.EventHandler(this.check_button_Click);
            // 
            // name_txt
            // 
            this.name_txt.Location = new System.Drawing.Point(330, 16);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(176, 22);
            this.name_txt.TabIndex = 6;
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.Location = new System.Drawing.Point(280, 19);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(44, 16);
            this.name_lbl.TabIndex = 7;
            this.name_lbl.Text = "name:";
            // 
            // pagenum_txt
            // 
            this.pagenum_txt.Location = new System.Drawing.Point(330, 44);
            this.pagenum_txt.Name = "pagenum_txt";
            this.pagenum_txt.Size = new System.Drawing.Size(176, 22);
            this.pagenum_txt.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "page_numbers:";
            // 
            // isbn_txt
            // 
            this.isbn_txt.Location = new System.Drawing.Point(330, 130);
            this.isbn_txt.Name = "isbn_txt";
            this.isbn_txt.Size = new System.Drawing.Size(176, 22);
            this.isbn_txt.TabIndex = 10;
            // 
            // format_combo
            // 
            this.format_combo.FormattingEnabled = true;
            this.format_combo.Location = new System.Drawing.Point(330, 72);
            this.format_combo.Name = "format_combo";
            this.format_combo.Size = new System.Drawing.Size(176, 24);
            this.format_combo.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "format:";
            // 
            // published_date
            // 
            this.published_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.published_date.Location = new System.Drawing.Point(330, 102);
            this.published_date.Name = "published_date";
            this.published_date.Size = new System.Drawing.Size(176, 22);
            this.published_date.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "date_published:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "isbn:";
            // 
            // zanr_combo
            // 
            this.zanr_combo.FormattingEnabled = true;
            this.zanr_combo.Location = new System.Drawing.Point(330, 158);
            this.zanr_combo.Name = "zanr_combo";
            this.zanr_combo.Size = new System.Drawing.Size(176, 24);
            this.zanr_combo.TabIndex = 16;
            // 
            // jezik_combo
            // 
            this.jezik_combo.FormattingEnabled = true;
            this.jezik_combo.Location = new System.Drawing.Point(330, 188);
            this.jezik_combo.Name = "jezik_combo";
            this.jezik_combo.Size = new System.Drawing.Size(176, 24);
            this.jezik_combo.TabIndex = 17;
            // 
            // opis_txt
            // 
            this.opis_txt.Location = new System.Drawing.Point(330, 218);
            this.opis_txt.Name = "opis_txt";
            this.opis_txt.Size = new System.Drawing.Size(176, 22);
            this.opis_txt.TabIndex = 18;
            // 
            // verzija_txt
            // 
            this.verzija_txt.Location = new System.Drawing.Point(330, 246);
            this.verzija_txt.Name = "verzija_txt";
            this.verzija_txt.Size = new System.Drawing.Size(176, 22);
            this.verzija_txt.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "genre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "language:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "version:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(284, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "autor:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 307);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "publisher:";
            // 
            // CreateBookUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CreateBookUC";
            this.Size = new System.Drawing.Size(1130, 598);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label book_label;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button check_button;
        private System.Windows.Forms.ComboBox publisher_combo;
        private System.Windows.Forms.ComboBox author_combo;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Label name_lbl;
        private System.Windows.Forms.TextBox pagenum_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox isbn_txt;
        private System.Windows.Forms.ComboBox format_combo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker published_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox jezik_combo;
        private System.Windows.Forms.ComboBox zanr_combo;
        private System.Windows.Forms.TextBox opis_txt;
        private System.Windows.Forms.TextBox verzija_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}
