namespace Gestor_OC_Gerdau.Produccion
{
    partial class Frm_DescargarArchivos
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
            this.label1 = new System.Windows.Forms.Label();
            this.Cal_Fechas = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.tx_Inicio = new System.Windows.Forms.TextBox();
            this.tx_Fin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Cmb_Sucursal = new System.Windows.Forms.ComboBox();
            this.Cmb_TipoGuia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_Resultados = new System.Windows.Forms.DataGridView();
            this.Btn_Descargar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione la fecha";
            // 
            // Cal_Fechas
            // 
            this.Cal_Fechas.Location = new System.Drawing.Point(20, 36);
            this.Cal_Fechas.Name = "Cal_Fechas";
            this.Cal_Fechas.TabIndex = 2;
            this.Cal_Fechas.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Cal_Fechas_DateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Inicial";
            // 
            // tx_Inicio
            // 
            this.tx_Inicio.BackColor = System.Drawing.Color.White;
            this.tx_Inicio.Location = new System.Drawing.Point(245, 38);
            this.tx_Inicio.Name = "tx_Inicio";
            this.tx_Inicio.ReadOnly = true;
            this.tx_Inicio.Size = new System.Drawing.Size(100, 20);
            this.tx_Inicio.TabIndex = 4;
            // 
            // tx_Fin
            // 
            this.tx_Fin.BackColor = System.Drawing.Color.White;
            this.tx_Fin.Location = new System.Drawing.Point(408, 38);
            this.tx_Fin.Name = "tx_Fin";
            this.tx_Fin.ReadOnly = true;
            this.tx_Fin.Size = new System.Drawing.Size(100, 20);
            this.tx_Fin.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Final";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sucursal";
            // 
            // Cmb_Sucursal
            // 
            this.Cmb_Sucursal.FormattingEnabled = true;
            this.Cmb_Sucursal.Location = new System.Drawing.Point(245, 100);
            this.Cmb_Sucursal.Name = "Cmb_Sucursal";
            this.Cmb_Sucursal.Size = new System.Drawing.Size(135, 21);
            this.Cmb_Sucursal.TabIndex = 8;
            // 
            // Cmb_TipoGuia
            // 
            this.Cmb_TipoGuia.FormattingEnabled = true;
            this.Cmb_TipoGuia.Location = new System.Drawing.Point(408, 100);
            this.Cmb_TipoGuia.Name = "Cmb_TipoGuia";
            this.Cmb_TipoGuia.Size = new System.Drawing.Size(100, 21);
            this.Cmb_TipoGuia.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(423, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo Guía";
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(263, 163);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(229, 35);
            this.Btn_Buscar.TabIndex = 11;
            this.Btn_Buscar.Text = "Buscar Datos";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Dtg_Resultados);
            this.groupBox1.Location = new System.Drawing.Point(11, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 253);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados";
            // 
            // Dtg_Resultados
            // 
            this.Dtg_Resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Resultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Resultados.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Resultados.Name = "Dtg_Resultados";
            this.Dtg_Resultados.Size = new System.Drawing.Size(784, 234);
            this.Dtg_Resultados.TabIndex = 0;
            // 
            // Btn_Descargar
            // 
            this.Btn_Descargar.Location = new System.Drawing.Point(589, 58);
            this.Btn_Descargar.Name = "Btn_Descargar";
            this.Btn_Descargar.Size = new System.Drawing.Size(196, 64);
            this.Btn_Descargar.TabIndex = 13;
            this.Btn_Descargar.Text = "Descargar Atchivos Para OptiSteel (normal y Variables)";
            this.Btn_Descargar.UseVisualStyleBackColor = true;
            this.Btn_Descargar.Click += new System.EventHandler(this.Btn_Descargar_Click);
            // 
            // Frm_DescargarArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 490);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_Descargar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Cmb_TipoGuia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Cmb_Sucursal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tx_Fin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tx_Inicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cal_Fechas);
            this.Controls.Add(this.label1);
            this.Name = "Frm_DescargarArchivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de descarga de Archivos";
            this.Load += new System.EventHandler(this.Frm_DescargarArchivos_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar Cal_Fechas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tx_Inicio;
        private System.Windows.Forms.TextBox tx_Fin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Cmb_Sucursal;
        private System.Windows.Forms.ComboBox Cmb_TipoGuia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_Resultados;
        private System.Windows.Forms.Button Btn_Descargar;
    }
}