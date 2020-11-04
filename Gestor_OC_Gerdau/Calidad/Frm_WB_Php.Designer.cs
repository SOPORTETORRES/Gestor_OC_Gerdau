namespace Gestor_OC_Gerdau.Calidad
{
    partial class Frm_WB_Php
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
            this.Wb = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // Wb
            // 
            this.Wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wb.Location = new System.Drawing.Point(0, 0);
            this.Wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.Wb.Name = "Wb";
            this.Wb.Size = new System.Drawing.Size(800, 450);
            this.Wb.TabIndex = 1;
            this.Wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.Wb_DocumentCompleted);
            // 
            // Frm_WB_Php
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Wb);
            this.Name = "Frm_WB_Php";
            this.Text = "Frm_WB_Php";
            this.Load += new System.EventHandler(this.Frm_WB_Php_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser Wb;
    }
}