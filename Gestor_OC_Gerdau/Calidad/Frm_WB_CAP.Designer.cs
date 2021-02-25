namespace Gestor_OC_Gerdau.Calidad
{
    partial class Frm_WB_CAP
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
            this.WB = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WB
            // 
            this.WB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WB.Location = new System.Drawing.Point(12, 3);
            this.WB.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB.Name = "WB";
            this.WB.Size = new System.Drawing.Size(776, 427);
            this.WB.TabIndex = 1;
            this.WB.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WB_DocumentCompleted);
            // 
            // Frm_WB_CAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WB);
            this.Name = "Frm_WB_CAP";
            this.Text = "Frm_WB_CAP";
            this.Load += new System.EventHandler(this.Frm_WB_CAP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WB;
    }
}