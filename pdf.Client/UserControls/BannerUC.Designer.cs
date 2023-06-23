namespace pdf.Client.UserControls
{
    partial class BannerUC
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
            this.name_label = new System.Windows.Forms.Label();
            this.ip_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.port_lbl = new System.Windows.Forms.Label();
            this.port_txt = new System.Windows.Forms.TextBox();
            this.connect_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Cursor = System.Windows.Forms.Cursors.Default;
            this.name_label.Font = new System.Drawing.Font("Segoe Print", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.Location = new System.Drawing.Point(390, 120);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(358, 50);
            this.name_label.TabIndex = 0;
            this.name_label.Text = "PDF_LIB_VERSION_v1.0";
            // 
            // ip_txt
            // 
            this.ip_txt.Location = new System.Drawing.Point(514, 236);
            this.ip_txt.Name = "ip_txt";
            this.ip_txt.Size = new System.Drawing.Size(192, 22);
            this.ip_txt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ip_address";
            // 
            // port_lbl
            // 
            this.port_lbl.AutoSize = true;
            this.port_lbl.Location = new System.Drawing.Point(433, 277);
            this.port_lbl.Name = "port_lbl";
            this.port_lbl.Size = new System.Drawing.Size(30, 16);
            this.port_lbl.TabIndex = 3;
            this.port_lbl.Text = "port";
            // 
            // port_txt
            // 
            this.port_txt.Location = new System.Drawing.Point(514, 277);
            this.port_txt.Name = "port_txt";
            this.port_txt.Size = new System.Drawing.Size(100, 22);
            this.port_txt.TabIndex = 4;
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(514, 326);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(75, 23);
            this.connect_btn.TabIndex = 5;
            this.connect_btn.Text = "connect";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // BannerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.port_txt);
            this.Controls.Add(this.port_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ip_txt);
            this.Controls.Add(this.name_label);
            this.Name = "BannerUC";
            this.Size = new System.Drawing.Size(1130, 598);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.TextBox ip_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label port_lbl;
        private System.Windows.Forms.TextBox port_txt;
        private System.Windows.Forms.Button connect_btn;
    }
}
