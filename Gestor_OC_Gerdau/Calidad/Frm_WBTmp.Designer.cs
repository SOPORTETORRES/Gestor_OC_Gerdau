namespace Gestor_OC_Gerdau.Calidad
{
    partial class Frm_WBTmp
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
            this.Tx_url = new System.Windows.Forms.TextBox();
            this.cachedRep_trazabilidadCol_v21 = new Gestor_OC_Gerdau.Calidad.CachedRep_trazabilidadCol_v2();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tx_url
            // 
            this.Tx_url.Location = new System.Drawing.Point(99, 68);
            this.Tx_url.Name = "Tx_url";
            this.Tx_url.Size = new System.Drawing.Size(638, 20);
            this.Tx_url.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frm_WBTmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Tx_url);
            this.Name = "Frm_WBTmp";
            this.Text = "Frm_WBTmp";
            this.Load += new System.EventHandler(this.Frm_WBTmp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tx_url;
        private CachedRep_trazabilidadCol_v2 cachedRep_trazabilidadCol_v21;
        private System.Windows.Forms.Button button1;
    }
}