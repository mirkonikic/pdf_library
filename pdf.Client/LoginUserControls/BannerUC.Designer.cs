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
            this.disconnect_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Cursor = System.Windows.Forms.Cursors.Default;
            this.name_label.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.Location = new System.Drawing.Point(408, 163);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(322, 38);
            this.name_label.TabIndex = 0;
            this.name_label.Text = "PDF_LIB_VERSION_v1.0";
            // 
            // ip_txt
            // 
            this.ip_txt.Location = new System.Drawing.Point(502, 280);
            this.ip_txt.Name = "ip_txt";
            this.ip_txt.Size = new System.Drawing.Size(209, 22);
            this.ip_txt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ip_address";
            // 
            // port_lbl
            // 
            this.port_lbl.AutoSize = true;
            this.port_lbl.Location = new System.Drawing.Point(421, 321);
            this.port_lbl.Name = "port_lbl";
            this.port_lbl.Size = new System.Drawing.Size(30, 16);
            this.port_lbl.TabIndex = 3;
            this.port_lbl.Text = "port";
            // 
            // port_txt
            // 
            this.port_txt.Location = new System.Drawing.Point(502, 321);
            this.port_txt.Name = "port_txt";
            this.port_txt.Size = new System.Drawing.Size(209, 22);
            this.port_txt.TabIndex = 4;
            // 
            // connect_btn
            // 
            this.connect_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.connect_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.connect_btn.FlatAppearance.BorderSize = 0;
            this.connect_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.connect_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.connect_btn.Location = new System.Drawing.Point(424, 370);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(137, 36);
            this.connect_btn.TabIndex = 5;
            this.connect_btn.Text = "connect";
            this.connect_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.connect_btn.UseVisualStyleBackColor = false;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // disconnect_btn
            // 
            this.disconnect_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.disconnect_btn.Location = new System.Drawing.Point(574, 370);
            this.disconnect_btn.Name = "disconnect_btn";
            this.disconnect_btn.Size = new System.Drawing.Size(137, 36);
            this.disconnect_btn.TabIndex = 6;
            this.disconnect_btn.Text = "disconnect";
            this.disconnect_btn.UseVisualStyleBackColor = true;
            this.disconnect_btn.Click += new System.EventHandler(this.disconnect_btn_Click);
            // 
            // BannerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.disconnect_btn);
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
        private System.Windows.Forms.Button disconnect_btn;
    }
}
