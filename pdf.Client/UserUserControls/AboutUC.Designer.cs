namespace pdf.Client.UserUserControls
{
    partial class AboutUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutUC));
            this.about_label = new System.Windows.Forms.Label();
            this.about_rtb = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // about_label
            // 
            this.about_label.AutoSize = true;
            this.about_label.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.about_label.Location = new System.Drawing.Point(509, 106);
            this.about_label.Name = "about_label";
            this.about_label.Size = new System.Drawing.Size(112, 38);
            this.about_label.TabIndex = 0;
            this.about_label.Text = "ABOUT";
            // 
            // about_rtb
            // 
            this.about_rtb.BackColor = System.Drawing.SystemColors.ControlLight;
            this.about_rtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.about_rtb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.about_rtb.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.about_rtb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.about_rtb.Location = new System.Drawing.Point(79, 171);
            this.about_rtb.Name = "about_rtb";
            this.about_rtb.ReadOnly = true;
            this.about_rtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.about_rtb.Size = new System.Drawing.Size(948, 364);
            this.about_rtb.TabIndex = 1;
            this.about_rtb.Text = resources.GetString("about_rtb.Text");
            // 
            // AboutUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.about_rtb);
            this.Controls.Add(this.about_label);
            this.Name = "AboutUC";
            this.Size = new System.Drawing.Size(1106, 584);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label about_label;
        private System.Windows.Forms.RichTextBox about_rtb;
    }
}
