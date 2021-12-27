namespace Gestor_OC_Gerdau.Tools
{
    partial class Frm_CreaMP
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
            this.Tx_Codigo = new System.Windows.Forms.TextBox();
            this.Btn_BuscaProd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_Prod = new System.Windows.Forms.DataGridView();
            this.Tx_Desc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tx_Tipo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tx_Diam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Tx_LArgo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Chk_Soldable = new System.Windows.Forms.CheckBox();
            this.Tx_TipoAcero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Btn_Grabar = new System.Windows.Forms.Button();
            this.Btn_cargar = new System.Windows.Forms.Button();
            this.Tx_existe = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn_BuscarCodAza = new System.Windows.Forms.Button();
            this.Tx_codigoAZA = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Dtg_DePAra = new System.Windows.Forms.DataGridView();
            this.Tx_codigoTO = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Btn_grabarDePara = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Tx_existe1 = new System.Windows.Forms.TextBox();
            this.Btn_Coronel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Prod)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_DePAra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código Producto";
            // 
            // Tx_Codigo
            // 
            this.Tx_Codigo.Location = new System.Drawing.Point(12, 25);
            this.Tx_Codigo.Name = "Tx_Codigo";
            this.Tx_Codigo.Size = new System.Drawing.Size(100, 20);
            this.Tx_Codigo.TabIndex = 1;
            // 
            // Btn_BuscaProd
            // 
            this.Btn_BuscaProd.Location = new System.Drawing.Point(120, 22);
            this.Btn_BuscaProd.Name = "Btn_BuscaProd";
            this.Btn_BuscaProd.Size = new System.Drawing.Size(55, 23);
            this.Btn_BuscaProd.TabIndex = 2;
            this.Btn_BuscaProd.Text = "Buscar";
            this.Btn_BuscaProd.UseVisualStyleBackColor = true;
            this.Btn_BuscaProd.Click += new System.EventHandler(this.Btn_BuscaProd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Datos Producto desde INET";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Dtg_Prod);
            this.groupBox1.Location = new System.Drawing.Point(1, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1017, 143);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // Dtg_Prod
            // 
            this.Dtg_Prod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Prod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Prod.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Prod.Name = "Dtg_Prod";
            this.Dtg_Prod.Size = new System.Drawing.Size(1011, 124);
            this.Dtg_Prod.TabIndex = 0;
            // 
            // Tx_Desc
            // 
            this.Tx_Desc.Location = new System.Drawing.Point(269, 25);
            this.Tx_Desc.Name = "Tx_Desc";
            this.Tx_Desc.Size = new System.Drawing.Size(364, 20);
            this.Tx_Desc.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descripción";
            // 
            // Tx_Tipo
            // 
            this.Tx_Tipo.Location = new System.Drawing.Point(667, 24);
            this.Tx_Tipo.Name = "Tx_Tipo";
            this.Tx_Tipo.Size = new System.Drawing.Size(53, 20);
            this.Tx_Tipo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(681, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo";
            // 
            // Tx_Diam
            // 
            this.Tx_Diam.Location = new System.Drawing.Point(735, 24);
            this.Tx_Diam.Name = "Tx_Diam";
            this.Tx_Diam.Size = new System.Drawing.Size(54, 20);
            this.Tx_Diam.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(749, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Diam";
            // 
            // Tx_LArgo
            // 
            this.Tx_LArgo.Location = new System.Drawing.Point(798, 24);
            this.Tx_LArgo.Name = "Tx_LArgo";
            this.Tx_LArgo.Size = new System.Drawing.Size(48, 20);
            this.Tx_LArgo.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(801, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Largo";
            // 
            // Chk_Soldable
            // 
            this.Chk_Soldable.AutoSize = true;
            this.Chk_Soldable.Location = new System.Drawing.Point(279, 66);
            this.Chk_Soldable.Name = "Chk_Soldable";
            this.Chk_Soldable.Size = new System.Drawing.Size(67, 17);
            this.Chk_Soldable.TabIndex = 13;
            this.Chk_Soldable.Text = "Soldable";
            this.Chk_Soldable.UseVisualStyleBackColor = true;
            // 
            // Tx_TipoAcero
            // 
            this.Tx_TipoAcero.Location = new System.Drawing.Point(656, 65);
            this.Tx_TipoAcero.Name = "Tx_TipoAcero";
            this.Tx_TipoAcero.Size = new System.Drawing.Size(64, 20);
            this.Tx_TipoAcero.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(661, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tipo Acero";
            // 
            // Btn_Grabar
            // 
            this.Btn_Grabar.Location = new System.Drawing.Point(908, 21);
            this.Btn_Grabar.Name = "Btn_Grabar";
            this.Btn_Grabar.Size = new System.Drawing.Size(66, 41);
            this.Btn_Grabar.TabIndex = 16;
            this.Btn_Grabar.Text = "Grabar";
            this.Btn_Grabar.UseVisualStyleBackColor = true;
            this.Btn_Grabar.Click += new System.EventHandler(this.Btn_Grabar_Click);
            // 
            // Btn_cargar
            // 
            this.Btn_cargar.Location = new System.Drawing.Point(191, 22);
            this.Btn_cargar.Name = "Btn_cargar";
            this.Btn_cargar.Size = new System.Drawing.Size(55, 23);
            this.Btn_cargar.TabIndex = 17;
            this.Btn_cargar.Text = "Cargar";
            this.Btn_cargar.UseVisualStyleBackColor = true;
            this.Btn_cargar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tx_existe
            // 
            this.Tx_existe.Location = new System.Drawing.Point(798, 69);
            this.Tx_existe.Name = "Tx_existe";
            this.Tx_existe.Size = new System.Drawing.Size(54, 20);
            this.Tx_existe.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(801, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Esta En BD";
            // 
            // Btn_BuscarCodAza
            // 
            this.Btn_BuscarCodAza.Location = new System.Drawing.Point(120, 284);
            this.Btn_BuscarCodAza.Name = "Btn_BuscarCodAza";
            this.Btn_BuscarCodAza.Size = new System.Drawing.Size(55, 23);
            this.Btn_BuscarCodAza.TabIndex = 22;
            this.Btn_BuscarCodAza.Text = "Buscar";
            this.Btn_BuscarCodAza.UseVisualStyleBackColor = true;
            this.Btn_BuscarCodAza.Click += new System.EventHandler(this.Btn_BuscarCodAza_Click);
            // 
            // Tx_codigoAZA
            // 
            this.Tx_codigoAZA.Location = new System.Drawing.Point(12, 287);
            this.Tx_codigoAZA.Name = "Tx_codigoAZA";
            this.Tx_codigoAZA.Size = new System.Drawing.Size(100, 20);
            this.Tx_codigoAZA.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Código Producto";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Dtg_DePAra);
            this.groupBox2.Location = new System.Drawing.Point(12, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1017, 143);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // Dtg_DePAra
            // 
            this.Dtg_DePAra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_DePAra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_DePAra.Location = new System.Drawing.Point(3, 16);
            this.Dtg_DePAra.Name = "Dtg_DePAra";
            this.Dtg_DePAra.Size = new System.Drawing.Size(1011, 124);
            this.Dtg_DePAra.TabIndex = 0;
            // 
            // Tx_codigoTO
            // 
            this.Tx_codigoTO.Location = new System.Drawing.Point(513, 268);
            this.Tx_codigoTO.Name = "Tx_codigoTO";
            this.Tx_codigoTO.Size = new System.Drawing.Size(140, 20);
            this.Tx_codigoTO.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(448, 268);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Código";
            // 
            // Btn_grabarDePara
            // 
            this.Btn_grabarDePara.Location = new System.Drawing.Point(684, 258);
            this.Btn_grabarDePara.Name = "Btn_grabarDePara";
            this.Btn_grabarDePara.Size = new System.Drawing.Size(66, 41);
            this.Btn_grabarDePara.TabIndex = 26;
            this.Btn_grabarDePara.Text = "Grabar";
            this.Btn_grabarDePara.UseVisualStyleBackColor = true;
            this.Btn_grabarDePara.Click += new System.EventHandler(this.Btn_grabarDePara_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(272, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Esta En BD";
            // 
            // Tx_existe1
            // 
            this.Tx_existe1.Location = new System.Drawing.Point(269, 279);
            this.Tx_existe1.Name = "Tx_existe1";
            this.Tx_existe1.Size = new System.Drawing.Size(54, 20);
            this.Tx_existe1.TabIndex = 27;
            // 
            // Btn_Coronel
            // 
            this.Btn_Coronel.Location = new System.Drawing.Point(834, 258);
            this.Btn_Coronel.Name = "Btn_Coronel";
            this.Btn_Coronel.Size = new System.Drawing.Size(93, 41);
            this.Btn_Coronel.TabIndex = 29;
            this.Btn_Coronel.Text = "Crea Productos Coronel";
            this.Btn_Coronel.UseVisualStyleBackColor = true;
            this.Btn_Coronel.Click += new System.EventHandler(this.Btn_Coronel_Click);
            // 
            // Frm_CreaMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 461);
            this.Controls.Add(this.Btn_Coronel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Tx_existe1);
            this.Controls.Add(this.Btn_grabarDePara);
            this.Controls.Add(this.Tx_codigoTO);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Btn_BuscarCodAza);
            this.Controls.Add(this.Tx_codigoAZA);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Tx_existe);
            this.Controls.Add(this.Btn_cargar);
            this.Controls.Add(this.Btn_Grabar);
            this.Controls.Add(this.Tx_TipoAcero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Chk_Soldable);
            this.Controls.Add(this.Tx_LArgo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Tx_Diam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Tx_Tipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Tx_Desc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_BuscaProd);
            this.Controls.Add(this.Tx_Codigo);
            this.Controls.Add(this.label1);
            this.Name = "Frm_CreaMP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Creación de Materia Prima";
            this.Load += new System.EventHandler(this.Frm_CreaMP_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Prod)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_DePAra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tx_Codigo;
        private System.Windows.Forms.Button Btn_BuscaProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_Prod;
        private System.Windows.Forms.TextBox Tx_Desc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tx_Tipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tx_Diam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Tx_LArgo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox Chk_Soldable;
        private System.Windows.Forms.TextBox Tx_TipoAcero;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Btn_Grabar;
        private System.Windows.Forms.Button Btn_cargar;
        private System.Windows.Forms.TextBox Tx_existe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Btn_BuscarCodAza;
        private System.Windows.Forms.TextBox Tx_codigoAZA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Dtg_DePAra;
        private System.Windows.Forms.TextBox Tx_codigoTO;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Btn_grabarDePara;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Tx_existe1;
        private System.Windows.Forms.Button Btn_Coronel;
    }
}