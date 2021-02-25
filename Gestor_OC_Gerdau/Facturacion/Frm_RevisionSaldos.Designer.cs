namespace Gestor_OC_Gerdau.Facturacion
{
    partial class Frm_RevisionSaldos
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
            this.Btn_GeneraArchivoLC = new System.Windows.Forms.Button();
            this.Dtg_Datos = new System.Windows.Forms.DataGridView();
            this.Btn_CargaArchivo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_GeneraArchivoLC
            // 
            this.Btn_GeneraArchivoLC.Location = new System.Drawing.Point(13, 3);
            this.Btn_GeneraArchivoLC.Name = "Btn_GeneraArchivoLC";
            this.Btn_GeneraArchivoLC.Size = new System.Drawing.Size(115, 23);
            this.Btn_GeneraArchivoLC.TabIndex = 0;
            this.Btn_GeneraArchivoLC.Text = "Carga  Informe LC";
            this.Btn_GeneraArchivoLC.UseVisualStyleBackColor = true;
            this.Btn_GeneraArchivoLC.Click += new System.EventHandler(this.Btn_GeneraArchivoLC_Click);
            // 
            // Dtg_Datos
            // 
            this.Dtg_Datos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Datos.Location = new System.Drawing.Point(13, 41);
            this.Dtg_Datos.Name = "Dtg_Datos";
            this.Dtg_Datos.Size = new System.Drawing.Size(835, 356);
            this.Dtg_Datos.TabIndex = 1;
            // 
            // Btn_CargaArchivo
            // 
            this.Btn_CargaArchivo.Location = new System.Drawing.Point(226, 3);
            this.Btn_CargaArchivo.Name = "Btn_CargaArchivo";
            this.Btn_CargaArchivo.Size = new System.Drawing.Size(115, 23);
            this.Btn_CargaArchivo.TabIndex = 2;
            this.Btn_CargaArchivo.Text = "Carga  archivo DANI";
            this.Btn_CargaArchivo.UseVisualStyleBackColor = true;
            this.Btn_CargaArchivo.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Comparar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Frm_RevisionSaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 409);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Btn_CargaArchivo);
            this.Controls.Add(this.Dtg_Datos);
            this.Controls.Add(this.Btn_GeneraArchivoLC);
            this.Name = "Frm_RevisionSaldos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Revisión de Saldos";
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_GeneraArchivoLC;
        private System.Windows.Forms.DataGridView Dtg_Datos;
        private System.Windows.Forms.Button Btn_CargaArchivo;
        private System.Windows.Forms.Button button2;
    }
}