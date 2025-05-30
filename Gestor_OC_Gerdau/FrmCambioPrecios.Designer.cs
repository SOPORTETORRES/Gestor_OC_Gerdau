namespace Gestor_OC_Gerdau
{
    partial class FrmCambioPrecios
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Tx_PrecioFi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Grabar = new System.Windows.Forms.Button();
            this.Tx_PrecioTri = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Lbl_Mes = new System.Windows.Forms.Label();
            this.Cmb_Mes = new System.Windows.Forms.ComboBox();
            this.Tx_Year = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Rb_Concepcion = new System.Windows.Forms.RadioButton();
            this.Rb_Coronel = new System.Windows.Forms.RadioButton();
            this.Rb_Calama = new System.Windows.Forms.RadioButton();
            this.Rb_Santiago = new System.Windows.Forms.RadioButton();
            this.Rb_TO = new System.Windows.Forms.RadioButton();
            this.Rb_Tosol = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Pnl_CambioPrecio = new System.Windows.Forms.Panel();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.Lbl_msgPB = new System.Windows.Forms.Label();
            this.Dtg_Resultado = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.Pnl_CambioPrecio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.Btn_Buscar);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.Rb_TO);
            this.groupBox1.Controls.Add(this.Rb_Tosol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1068, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cambio de Precio";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(666, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Tx_PrecioFi);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.Btn_Grabar);
            this.groupBox4.Controls.Add(this.Tx_PrecioTri);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(738, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(324, 72);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nuevo Precio";
            // 
            // Tx_PrecioFi
            // 
            this.Tx_PrecioFi.Location = new System.Drawing.Point(118, 42);
            this.Tx_PrecioFi.Name = "Tx_PrecioFi";
            this.Tx_PrecioFi.Size = new System.Drawing.Size(48, 20);
            this.Tx_PrecioFi.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Precio Financiero";
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.Enabled = false;
            this.Btn_Grabar.Location = new System.Drawing.Point(242, 15);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(66, 45);
            this.Btn_Grabar.TabIndex = 6;
            this.Btn_Grabar.Text = "Grabar";
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            this.Btn_Grabar.Click += new System.EventHandler(this.Btn_Grabar_Click);
            // 
            // Tx_PrecioTri
            // 
            this.Tx_PrecioTri.Location = new System.Drawing.Point(118, 16);
            this.Tx_PrecioTri.Name = "Tx_PrecioTri";
            this.Tx_PrecioTri.Size = new System.Drawing.Size(48, 20);
            this.Tx_PrecioTri.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Precio Tributario";
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(666, 40);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(66, 45);
            this.Btn_Buscar.TabIndex = 5;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Lbl_Mes);
            this.groupBox3.Controls.Add(this.Cmb_Mes);
            this.groupBox3.Controls.Add(this.Tx_Year);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(401, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 72);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Periodo";
            // 
            // Lbl_Mes
            // 
            this.Lbl_Mes.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Mes.Location = new System.Drawing.Point(134, 41);
            this.Lbl_Mes.Name = "Lbl_Mes";
            this.Lbl_Mes.Size = new System.Drawing.Size(113, 17);
            this.Lbl_Mes.TabIndex = 4;
            this.Lbl_Mes.Text = "Mes no Seleccionado";
            // 
            // Cmb_Mes
            // 
            this.Cmb_Mes.FormattingEnabled = true;
            this.Cmb_Mes.Location = new System.Drawing.Point(74, 39);
            this.Cmb_Mes.Name = "Cmb_Mes";
            this.Cmb_Mes.Size = new System.Drawing.Size(48, 21);
            this.Cmb_Mes.TabIndex = 3;
            this.Cmb_Mes.SelectedIndexChanged += new System.EventHandler(this.Cmb_Mes_SelectedIndexChanged);
            // 
            // Tx_Year
            // 
            this.Tx_Year.Location = new System.Drawing.Point(9, 39);
            this.Tx_Year.Name = "Tx_Year";
            this.Tx_Year.Size = new System.Drawing.Size(48, 20);
            this.Tx_Year.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Año";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Rb_Concepcion);
            this.groupBox2.Controls.Add(this.Rb_Coronel);
            this.groupBox2.Controls.Add(this.Rb_Calama);
            this.groupBox2.Controls.Add(this.Rb_Santiago);
            this.groupBox2.Location = new System.Drawing.Point(177, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 88);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sucursal";
            // 
            // Rb_Concepcion
            // 
            this.Rb_Concepcion.AutoSize = true;
            this.Rb_Concepcion.Location = new System.Drawing.Point(106, 48);
            this.Rb_Concepcion.Name = "Rb_Concepcion";
            this.Rb_Concepcion.Size = new System.Drawing.Size(82, 17);
            this.Rb_Concepcion.TabIndex = 6;
            this.Rb_Concepcion.Text = "Concepción";
            this.Rb_Concepcion.UseVisualStyleBackColor = true;
            // 
            // Rb_Coronel
            // 
            this.Rb_Coronel.AutoSize = true;
            this.Rb_Coronel.Location = new System.Drawing.Point(106, 19);
            this.Rb_Coronel.Name = "Rb_Coronel";
            this.Rb_Coronel.Size = new System.Drawing.Size(61, 17);
            this.Rb_Coronel.TabIndex = 5;
            this.Rb_Coronel.Text = "Coronel";
            this.Rb_Coronel.UseVisualStyleBackColor = true;
            // 
            // Rb_Calama
            // 
            this.Rb_Calama.AutoSize = true;
            this.Rb_Calama.Location = new System.Drawing.Point(20, 49);
            this.Rb_Calama.Name = "Rb_Calama";
            this.Rb_Calama.Size = new System.Drawing.Size(60, 17);
            this.Rb_Calama.TabIndex = 4;
            this.Rb_Calama.Text = "Calama";
            this.Rb_Calama.UseVisualStyleBackColor = true;
            // 
            // Rb_Santiago
            // 
            this.Rb_Santiago.AutoSize = true;
            this.Rb_Santiago.Checked = true;
            this.Rb_Santiago.Location = new System.Drawing.Point(20, 18);
            this.Rb_Santiago.Name = "Rb_Santiago";
            this.Rb_Santiago.Size = new System.Drawing.Size(67, 17);
            this.Rb_Santiago.TabIndex = 3;
            this.Rb_Santiago.TabStop = true;
            this.Rb_Santiago.Text = "Santiago";
            this.Rb_Santiago.UseVisualStyleBackColor = true;
            // 
            // Rb_TO
            // 
            this.Rb_TO.AutoSize = true;
            this.Rb_TO.Checked = true;
            this.Rb_TO.Location = new System.Drawing.Point(26, 48);
            this.Rb_TO.Name = "Rb_TO";
            this.Rb_TO.Size = new System.Drawing.Size(107, 17);
            this.Rb_TO.TabIndex = 2;
            this.Rb_TO.TabStop = true;
            this.Rb_TO.Text = "Torres  Ocaranza";
            this.Rb_TO.UseVisualStyleBackColor = true;
            // 
            // Rb_Tosol
            // 
            this.Rb_Tosol.AutoSize = true;
            this.Rb_Tosol.Location = new System.Drawing.Point(26, 74);
            this.Rb_Tosol.Name = "Rb_Tosol";
            this.Rb_Tosol.Size = new System.Drawing.Size(61, 17);
            this.Rb_Tosol.TabIndex = 1;
            this.Rb_Tosol.Text = "TOSOL";
            this.Rb_Tosol.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione la empresa";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.Pnl_CambioPrecio);
            this.groupBox5.Controls.Add(this.Dtg_Resultado);
            this.groupBox5.Location = new System.Drawing.Point(4, 119);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1082, 349);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Resultados";
            // 
            // Pnl_CambioPrecio
            // 
            this.Pnl_CambioPrecio.Controls.Add(this.PB);
            this.Pnl_CambioPrecio.Controls.Add(this.Lbl_msgPB);
            this.Pnl_CambioPrecio.Location = new System.Drawing.Point(159, 36);
            this.Pnl_CambioPrecio.Name = "Pnl_CambioPrecio";
            this.Pnl_CambioPrecio.Size = new System.Drawing.Size(660, 100);
            this.Pnl_CambioPrecio.TabIndex = 1;
            this.Pnl_CambioPrecio.Visible = false;
            // 
            // PB
            // 
            this.PB.Location = new System.Drawing.Point(59, 52);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(559, 23);
            this.PB.TabIndex = 2;
            // 
            // Lbl_msgPB
            // 
            this.Lbl_msgPB.AutoSize = true;
            this.Lbl_msgPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_msgPB.Location = new System.Drawing.Point(223, 17);
            this.Lbl_msgPB.Name = "Lbl_msgPB";
            this.Lbl_msgPB.Size = new System.Drawing.Size(190, 17);
            this.Lbl_msgPB.TabIndex = 1;
            this.Lbl_msgPB.Text = "Estado del Cambio de Precio";
            // 
            // Dtg_Resultado
            // 
            this.Dtg_Resultado.AllowUserToAddRows = false;
            this.Dtg_Resultado.AllowUserToDeleteRows = false;
            this.Dtg_Resultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Resultado.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Resultado.Name = "Dtg_Resultado";
            this.Dtg_Resultado.ReadOnly = true;
            this.Dtg_Resultado.Size = new System.Drawing.Size(1076, 329);
            this.Dtg_Resultado.TabIndex = 0;
            this.Dtg_Resultado.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Resultado_CellContentDoubleClick);
            // 
            // FrmCambioPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 469);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCambioPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Cambio de Precios (Versión 1.0.8)";
            this.Load += new System.EventHandler(this.FrmCambioPrecios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.Pnl_CambioPrecio.ResumeLayout(false);
            this.Pnl_CambioPrecio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button Btn_Grabar;
        private System.Windows.Forms.TextBox Tx_PrecioTri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Lbl_Mes;
        private System.Windows.Forms.ComboBox Cmb_Mes;
        private System.Windows.Forms.TextBox Tx_Year;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Rb_Calama;
        private System.Windows.Forms.RadioButton Rb_Santiago;
        private System.Windows.Forms.RadioButton Rb_TO;
        private System.Windows.Forms.RadioButton Rb_Tosol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView Dtg_Resultado;
        private System.Windows.Forms.Panel Pnl_CambioPrecio;
        private System.Windows.Forms.ProgressBar PB;
        private System.Windows.Forms.Label Lbl_msgPB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton Rb_Coronel;
        private System.Windows.Forms.RadioButton Rb_Concepcion;
        private System.Windows.Forms.TextBox Tx_PrecioFi;
        private System.Windows.Forms.Label label4;
    }
}