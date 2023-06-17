namespace pdf.Server
{
    partial class SrvMainForm
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
            this.start_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.main_rtb = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.enter_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(16, 511);
            this.start_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(100, 28);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Enabled = false;
            this.stop_btn.Location = new System.Drawing.Point(124, 511);
            this.stop_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(100, 28);
            this.stop_btn.TabIndex = 1;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // main_rtb
            // 
            this.main_rtb.Location = new System.Drawing.Point(16, 15);
            this.main_rtb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.main_rtb.Name = "main_rtb";
            this.main_rtb.Size = new System.Drawing.Size(1033, 488);
            this.main_rtb.TabIndex = 2;
            this.main_rtb.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(233, 513);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(708, 22);
            this.textBox1.TabIndex = 3;
            // 
            // enter_btn
            // 
            this.enter_btn.Location = new System.Drawing.Point(951, 511);
            this.enter_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enter_btn.Name = "enter_btn";
            this.enter_btn.Size = new System.Drawing.Size(100, 28);
            this.enter_btn.TabIndex = 4;
            this.enter_btn.Text = "Enter";
            this.enter_btn.UseVisualStyleBackColor = true;
            this.enter_btn.Click += new System.EventHandler(this.enter_btn_Click);
            // 
            // SrvMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.enter_btn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.main_rtb);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.start_btn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SrvMainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.RichTextBox main_rtb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button enter_btn;
    }
}

