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
            this.label1 = new System.Windows.Forms.Label();
            this.Tx_lote = new System.Windows.Forms.TextBox();
            this.Tx_diam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_carga = new System.Windows.Forms.Button();
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
            this.WB.Size = new System.Drawing.Size(914, 427);
            this.WB.TabIndex = 1;
            this.WB.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WB_DocumentCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(960, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lote";
            // 
            // Tx_lote
            // 
            this.Tx_lote.Location = new System.Drawing.Point(1010, 84);
            this.Tx_lote.Name = "Tx_lote";
            this.Tx_lote.Size = new System.Drawing.Size(100, 20);
            this.Tx_lote.TabIndex = 3;
            // 
            // Tx_diam
            // 
            this.Tx_diam.Location = new System.Drawing.Point(1010, 122);
            this.Tx_diam.Name = "Tx_diam";
            this.Tx_diam.Size = new System.Drawing.Size(66, 20);
            this.Tx_diam.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(951, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Diametro";
            // 
            // Btn_carga
            // 
            this.Btn_carga.Location = new System.Drawing.Point(985, 185);
            this.Btn_carga.Name = "Btn_carga";
            this.Btn_carga.Size = new System.Drawing.Size(75, 23);
            this.Btn_carga.TabIndex = 6;
            this.Btn_carga.Text = "Cargar";
            this.Btn_carga.UseVisualStyleBackColor = true;
            this.Btn_carga.Click += new System.EventHandler(this.Btn_carga_Click);
            // 
            // Frm_WB_CAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 450);
            this.Controls.Add(this.Btn_carga);
            this.Controls.Add(this.Tx_diam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tx_lote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WB);
            this.Name = "Frm_WB_CAP";
            this.Text = "Frm_WB_CAP";
            this.Load += new System.EventHandler(this.Frm_WB_CAP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser WB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tx_lote;
        private System.Windows.Forms.TextBox Tx_diam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_carga;
    }
}