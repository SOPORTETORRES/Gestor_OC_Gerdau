namespace Gestor_OC_Gerdau.Tools
{
    partial class Importar_NewCodigos
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
            this.Btn_Procesar = new System.Windows.Forms.Button();
            this.Tx_sucursal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_sel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Tx_path = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Dtg_Archivo = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Btn_EliminaConsumos = new System.Windows.Forms.Button();
            this.Btn_CambiaCod = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.BTN_TOSOL = new System.Windows.Forms.Button();
            this.Btn_CambiosConsumo = new System.Windows.Forms.Button();
            this.Btn_corrigueLC = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Archivo)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_Procesar);
            this.groupBox1.Controls.Add(this.Tx_sucursal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_sel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Tx_path);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione la Ubicación del Archivo a Importar";
            // 
            // Btn_Procesar
            // 
            this.Btn_Procesar.Location = new System.Drawing.Point(351, 21);
            this.Btn_Procesar.Name = "Btn_Procesar";
            this.Btn_Procesar.Size = new System.Drawing.Size(75, 42);
            this.Btn_Procesar.TabIndex = 5;
            this.Btn_Procesar.Text = "Procesar  Archivo";
            this.Btn_Procesar.UseVisualStyleBackColor = true;
            this.Btn_Procesar.Click += new System.EventHandler(this.Btn_Procesar_Click);
            // 
            // Tx_sucursal
            // 
            this.Tx_sucursal.Location = new System.Drawing.Point(233, 33);
            this.Tx_sucursal.Name = "Tx_sucursal";
            this.Tx_sucursal.Size = new System.Drawing.Size(66, 20);
            this.Tx_sucursal.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione Sucursal";
            // 
            // btn_sel
            // 
            this.btn_sel.Location = new System.Drawing.Point(15, 21);
            this.btn_sel.Name = "btn_sel";
            this.btn_sel.Size = new System.Drawing.Size(162, 23);
            this.btn_sel.TabIndex = 2;
            this.btn_sel.Text = "Seleccionar Ubicación";
            this.btn_sel.UseVisualStyleBackColor = true;
            this.btn_sel.Click += new System.EventHandler(this.btn_sel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ubicación del Archivo a Importar";
            // 
            // Tx_path
            // 
            this.Tx_path.Location = new System.Drawing.Point(7, 69);
            this.Tx_path.Name = "Tx_path";
            this.Tx_path.Size = new System.Drawing.Size(419, 20);
            this.Tx_path.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Dtg_Archivo);
            this.groupBox2.Location = new System.Drawing.Point(6, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 304);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Archivo";
            // 
            // Dtg_Archivo
            // 
            this.Dtg_Archivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Archivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Archivo.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Archivo.Name = "Dtg_Archivo";
            this.Dtg_Archivo.Size = new System.Drawing.Size(801, 285);
            this.Dtg_Archivo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Btn_EliminaConsumos);
            this.groupBox3.Controls.Add(this.Btn_CambiaCod);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Location = new System.Drawing.Point(458, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 101);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reversa Consumos Maquinas";
            // 
            // Btn_EliminaConsumos
            // 
            this.Btn_EliminaConsumos.Location = new System.Drawing.Point(218, 50);
            this.Btn_EliminaConsumos.Name = "Btn_EliminaConsumos";
            this.Btn_EliminaConsumos.Size = new System.Drawing.Size(108, 27);
            this.Btn_EliminaConsumos.TabIndex = 7;
            this.Btn_EliminaConsumos.Text = "Elimina Consumos";
            this.Btn_EliminaConsumos.UseVisualStyleBackColor = true;
            this.Btn_EliminaConsumos.Click += new System.EventHandler(this.Btn_EliminaConsumos_Click);
            // 
            // Btn_CambiaCod
            // 
            this.Btn_CambiaCod.Location = new System.Drawing.Point(218, 17);
            this.Btn_CambiaCod.Name = "Btn_CambiaCod";
            this.Btn_CambiaCod.Size = new System.Drawing.Size(108, 27);
            this.Btn_CambiaCod.TabIndex = 6;
            this.Btn_CambiaCod.Text = "Cambia Códigos ";
            this.Btn_CambiaCod.UseVisualStyleBackColor = true;
            this.Btn_CambiaCod.Click += new System.EventHandler(this.Btn_CambiaCod_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fecha Inicio";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(77, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2022, 1, 3, 10, 29, 0, 0);
            // 
            // BTN_TOSOL
            // 
            this.BTN_TOSOL.Location = new System.Drawing.Point(12, 113);
            this.BTN_TOSOL.Name = "BTN_TOSOL";
            this.BTN_TOSOL.Size = new System.Drawing.Size(148, 27);
            this.BTN_TOSOL.TabIndex = 7;
            this.BTN_TOSOL.Text = "Repara Duplicidad Tosol ";
            this.BTN_TOSOL.UseVisualStyleBackColor = true;
            this.BTN_TOSOL.Click += new System.EventHandler(this.BTN_TOSOL_Click);
            // 
            // Btn_CambiosConsumo
            // 
            this.Btn_CambiosConsumo.Location = new System.Drawing.Point(575, 113);
            this.Btn_CambiosConsumo.Name = "Btn_CambiosConsumo";
            this.Btn_CambiosConsumo.Size = new System.Drawing.Size(148, 27);
            this.Btn_CambiosConsumo.TabIndex = 8;
            this.Btn_CambiosConsumo.Text = "Cambia Consumos";
            this.Btn_CambiosConsumo.UseVisualStyleBackColor = true;
            this.Btn_CambiosConsumo.Click += new System.EventHandler(this.Btn_CambiosConsumo_Click);
            // 
            // Btn_corrigueLC
            // 
            this.Btn_corrigueLC.Location = new System.Drawing.Point(242, 113);
            this.Btn_corrigueLC.Name = "Btn_corrigueLC";
            this.Btn_corrigueLC.Size = new System.Drawing.Size(148, 27);
            this.Btn_corrigueLC.TabIndex = 9;
            this.Btn_corrigueLC.Text = "Corriguie LineaCredito";
            this.Btn_corrigueLC.UseVisualStyleBackColor = true;
            this.Btn_corrigueLC.Click += new System.EventHandler(this.Btn_corrigueLC_Click);
            // 
            // Importar_NewCodigos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 456);
            this.Controls.Add(this.Btn_corrigueLC);
            this.Controls.Add(this.Btn_CambiosConsumo);
            this.Controls.Add(this.BTN_TOSOL);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Importar_NewCodigos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de importación de nuevos Códigos de Productos ";
            this.Load += new System.EventHandler(this.Importar_NewCodigos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Archivo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Tx_sucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_sel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tx_path;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Dtg_Archivo;
        private System.Windows.Forms.Button Btn_Procesar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Btn_CambiaCod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Btn_EliminaConsumos;
        private System.Windows.Forms.Button BTN_TOSOL;
        private System.Windows.Forms.Button Btn_CambiosConsumo;
        private System.Windows.Forms.Button Btn_corrigueLC;
    }
}