namespace Gestor_OC_Gerdau.Produccion
{
    partial class Frm_IngresaDatos
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
            this.Tx_Path = new System.Windows.Forms.TextBox();
            this.Btn_Path = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Rb_Optimizado = new System.Windows.Forms.RadioButton();
            this.Tb_Sku = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Dtg_Resultado = new System.Windows.Forms.DataGridView();
            this.Btn_CargaArch = new System.Windows.Forms.Button();
            this.Btn_GrabarArch = new System.Windows.Forms.Button();
            this.Btn_SolicitaMP = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Tx_Path);
            this.groupBox1.Controls.Add(this.Btn_Path);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(717, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Ingreso de Datos de OPTISTEEL";
            // 
            // Tx_Path
            // 
            this.Tx_Path.Enabled = false;
            this.Tx_Path.Location = new System.Drawing.Point(268, 48);
            this.Tx_Path.Name = "Tx_Path";
            this.Tx_Path.Size = new System.Drawing.Size(443, 20);
            this.Tx_Path.TabIndex = 4;
            // 
            // Btn_Path
            // 
            this.Btn_Path.Location = new System.Drawing.Point(375, 25);
            this.Btn_Path.Name = "Btn_Path";
            this.Btn_Path.Size = new System.Drawing.Size(25, 22);
            this.Btn_Path.TabIndex = 3;
            this.Btn_Path.Text = "?";
            this.Btn_Path.UseVisualStyleBackColor = true;
            this.Btn_Path.Click += new System.EventHandler(this.Btn_Path_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione Archivo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Rb_Optimizado);
            this.groupBox2.Controls.Add(this.Tb_Sku);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccione Tipo Archivo";
            // 
            // Rb_Optimizado
            // 
            this.Rb_Optimizado.AutoSize = true;
            this.Rb_Optimizado.Location = new System.Drawing.Point(121, 25);
            this.Rb_Optimizado.Name = "Rb_Optimizado";
            this.Rb_Optimizado.Size = new System.Drawing.Size(116, 17);
            this.Rb_Optimizado.TabIndex = 1;
            this.Rb_Optimizado.TabStop = true;
            this.Rb_Optimizado.Text = "Archivo Optimizado";
            this.Rb_Optimizado.UseVisualStyleBackColor = true;
            // 
            // Tb_Sku
            // 
            this.Tb_Sku.AutoSize = true;
            this.Tb_Sku.Location = new System.Drawing.Point(19, 26);
            this.Tb_Sku.Name = "Tb_Sku";
            this.Tb_Sku.Size = new System.Drawing.Size(86, 17);
            this.Tb_Sku.TabIndex = 0;
            this.Tb_Sku.TabStop = true;
            this.Tb_Sku.Text = "Archivo SKU";
            this.Tb_Sku.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.Dtg_Resultado);
            this.groupBox3.Location = new System.Drawing.Point(8, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(988, 316);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resultados";
            // 
            // Dtg_Resultado
            // 
            this.Dtg_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Resultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Resultado.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Resultado.Name = "Dtg_Resultado";
            this.Dtg_Resultado.Size = new System.Drawing.Size(982, 297);
            this.Dtg_Resultado.TabIndex = 0;
            // 
            // Btn_CargaArch
            // 
            this.Btn_CargaArch.Location = new System.Drawing.Point(739, 17);
            this.Btn_CargaArch.Name = "Btn_CargaArch";
            this.Btn_CargaArch.Size = new System.Drawing.Size(97, 30);
            this.Btn_CargaArch.TabIndex = 2;
            this.Btn_CargaArch.Text = "Carga Archivo";
            this.Btn_CargaArch.UseVisualStyleBackColor = true;
            this.Btn_CargaArch.Click += new System.EventHandler(this.Btn_CargaArch_Click);
            // 
            // Btn_GrabarArch
            // 
            this.Btn_GrabarArch.Location = new System.Drawing.Point(739, 57);
            this.Btn_GrabarArch.Name = "Btn_GrabarArch";
            this.Btn_GrabarArch.Size = new System.Drawing.Size(97, 30);
            this.Btn_GrabarArch.TabIndex = 3;
            this.Btn_GrabarArch.Text = "Grabar Archivo";
            this.Btn_GrabarArch.UseVisualStyleBackColor = true;
            this.Btn_GrabarArch.Click += new System.EventHandler(this.Btn_GrabarArch_Click);
            // 
            // Btn_SolicitaMP
            // 
            this.Btn_SolicitaMP.Location = new System.Drawing.Point(884, 17);
            this.Btn_SolicitaMP.Name = "Btn_SolicitaMP";
            this.Btn_SolicitaMP.Size = new System.Drawing.Size(107, 39);
            this.Btn_SolicitaMP.TabIndex = 4;
            this.Btn_SolicitaMP.Text = " Resumen Pedido";
            this.Btn_SolicitaMP.UseVisualStyleBackColor = true;
            this.Btn_SolicitaMP.Click += new System.EventHandler(this.Btn_SolicitaMP_Click);
            // 
            // Frm_IngresaDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 427);
            this.Controls.Add(this.Btn_SolicitaMP);
            this.Controls.Add(this.Btn_GrabarArch);
            this.Controls.Add(this.Btn_CargaArch);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_IngresaDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Ingreso de Datos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Tx_Path;
        private System.Windows.Forms.Button Btn_Path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Rb_Optimizado;
        private System.Windows.Forms.RadioButton Tb_Sku;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView Dtg_Resultado;
        private System.Windows.Forms.Button Btn_CargaArch;
        private System.Windows.Forms.Button Btn_GrabarArch;
        private System.Windows.Forms.Button Btn_SolicitaMP;
    }
}