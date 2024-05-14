namespace Gestor_OC_Gerdau.Calidad
{
    partial class Frm_ProcesoPorLote
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DTG_Resultado = new System.Windows.Forms.DataGridView();
            this.Btn_CargaDatos = new System.Windows.Forms.Button();
            this.Btn_Procesar = new System.Windows.Forms.Button();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTG_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DTG_Resultado);
            this.groupBox1.Location = new System.Drawing.Point(10, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 576);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lotes a Procesar";
            // 
            // DTG_Resultado
            // 
            this.DTG_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTG_Resultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTG_Resultado.Location = new System.Drawing.Point(3, 16);
            this.DTG_Resultado.Name = "DTG_Resultado";
            this.DTG_Resultado.Size = new System.Drawing.Size(290, 557);
            this.DTG_Resultado.TabIndex = 0;
            // 
            // Btn_CargaDatos
            // 
            this.Btn_CargaDatos.Location = new System.Drawing.Point(23, 13);
            this.Btn_CargaDatos.Name = "Btn_CargaDatos";
            this.Btn_CargaDatos.Size = new System.Drawing.Size(111, 45);
            this.Btn_CargaDatos.TabIndex = 1;
            this.Btn_CargaDatos.Text = "Carga Datos";
            this.Btn_CargaDatos.UseVisualStyleBackColor = true;
            this.Btn_CargaDatos.Click += new System.EventHandler(this.Btn_CargaDatos_Click);
            // 
            // Btn_Procesar
            // 
            this.Btn_Procesar.Location = new System.Drawing.Point(195, 13);
            this.Btn_Procesar.Name = "Btn_Procesar";
            this.Btn_Procesar.Size = new System.Drawing.Size(111, 45);
            this.Btn_Procesar.TabIndex = 2;
            this.Btn_Procesar.Text = "Procesar Datos ";
            this.Btn_Procesar.UseVisualStyleBackColor = true;
            this.Btn_Procesar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_Msg.Location = new System.Drawing.Point(13, 73);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(290, 58);
            this.Lbl_Msg.TabIndex = 3;
            this.Lbl_Msg.Text = "label1";
            this.Lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_ProcesoPorLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 719);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.Btn_Procesar);
            this.Controls.Add(this.Btn_CargaDatos);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_ProcesoPorLote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Proceso de certificados por Lote.";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DTG_Resultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DTG_Resultado;
        private System.Windows.Forms.Button Btn_CargaDatos;
        private System.Windows.Forms.Button Btn_Procesar;
        private System.Windows.Forms.Label Lbl_Msg;
    }
}