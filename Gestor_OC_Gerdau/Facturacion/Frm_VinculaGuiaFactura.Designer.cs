namespace Gestor_OC_Gerdau.Facturacion
{
    partial class Frm_VinculaGuiaFactura
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
            this.Btn_Revisa = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Pb_Avance = new System.Windows.Forms.ProgressBar();
            this.Lbl_avance = new System.Windows.Forms.Label();
            this.Btn_Actualiza = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Revisa
            // 
            this.Btn_Revisa.Location = new System.Drawing.Point(317, 12);
            this.Btn_Revisa.Name = "Btn_Revisa";
            this.Btn_Revisa.Size = new System.Drawing.Size(121, 41);
            this.Btn_Revisa.TabIndex = 0;
            this.Btn_Revisa.Text = "Revisa Guias Factura";
            this.Btn_Revisa.UseVisualStyleBackColor = true;
            this.Btn_Revisa.Click += new System.EventHandler(this.Btn_Revisa_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 336);
            this.dataGridView1.TabIndex = 1;
            // 
            // Pb_Avance
            // 
            this.Pb_Avance.Location = new System.Drawing.Point(39, 76);
            this.Pb_Avance.Name = "Pb_Avance";
            this.Pb_Avance.Size = new System.Drawing.Size(715, 20);
            this.Pb_Avance.TabIndex = 3;
            // 
            // Lbl_avance
            // 
            this.Lbl_avance.AutoSize = true;
            this.Lbl_avance.Location = new System.Drawing.Point(137, 57);
            this.Lbl_avance.Name = "Lbl_avance";
            this.Lbl_avance.Size = new System.Drawing.Size(35, 13);
            this.Lbl_avance.TabIndex = 4;
            this.Lbl_avance.Text = "label1";
            // 
            // Btn_Actualiza
            // 
            this.Btn_Actualiza.Location = new System.Drawing.Point(603, 12);
            this.Btn_Actualiza.Name = "Btn_Actualiza";
            this.Btn_Actualiza.Size = new System.Drawing.Size(121, 41);
            this.Btn_Actualiza.TabIndex = 5;
            this.Btn_Actualiza.Text = "Actualiza Guias Facturas";
            this.Btn_Actualiza.UseVisualStyleBackColor = true;
            this.Btn_Actualiza.Click += new System.EventHandler(this.Btn_Actualiza_Click);
            // 
            // Frm_VinculaGuiaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_Actualiza);
            this.Controls.Add(this.Lbl_avance);
            this.Controls.Add(this.Pb_Avance);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Btn_Revisa);
            this.Name = "Frm_VinculaGuiaFactura";
            this.Text = "Frm_VinculaGuiaFactura";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Revisa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar Pb_Avance;
        private System.Windows.Forms.Label Lbl_avance;
        private System.Windows.Forms.Button Btn_Actualiza;
    }
}