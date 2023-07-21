namespace Gestor_OC_Gerdau.Calidad
{
    partial class Frm_CertificacionViaje
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
            this.Dtg_Datos = new System.Windows.Forms.DataGridView();
            this.Btn_Refresh = new System.Windows.Forms.Button();
            this.Btn_ActualizaLote = new System.Windows.Forms.Button();
            this.Lbl_Lote = new System.Windows.Forms.Label();
            this.Btn_lotesProblema = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_RevisaHD = new System.Windows.Forms.Button();
            this.Btn_ActualizaPorViaje = new System.Windows.Forms.Button();
            this.Tx_Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_CP = new System.Windows.Forms.Button();
            this.Btn_CorrigueEV = new System.Windows.Forms.Button();
            this.Btn_ReparaET = new System.Windows.Forms.Button();
            this.Lbl_IdPaquete = new System.Windows.Forms.Label();
            this.Lbl_Diam = new System.Windows.Forms.Label();
            this.Lbl_Kgs = new System.Windows.Forms.Label();
            this.Btn_VerLote = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Tx_lote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_LoteForzado = new System.Windows.Forms.Button();
            this.Btn_ObtenerLotesV2 = new System.Windows.Forms.Button();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.btn_GeneraProducciones = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Dtg_Datos);
            this.groupBox1.Location = new System.Drawing.Point(8, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1092, 321);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle";
            // 
            // Dtg_Datos
            // 
            this.Dtg_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Datos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Datos.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Datos.Name = "Dtg_Datos";
            this.Dtg_Datos.Size = new System.Drawing.Size(1086, 302);
            this.Dtg_Datos.TabIndex = 0;
            this.Dtg_Datos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Datos_CellContentClick);
            // 
            // Btn_Refresh
            // 
            this.Btn_Refresh.Location = new System.Drawing.Point(11, 49);
            this.Btn_Refresh.Name = "Btn_Refresh";
            this.Btn_Refresh.Size = new System.Drawing.Size(75, 38);
            this.Btn_Refresh.TabIndex = 1;
            this.Btn_Refresh.Text = "Actualizar Datos";
            this.Btn_Refresh.UseVisualStyleBackColor = true;
            this.Btn_Refresh.Click += new System.EventHandler(this.Btn_Refresh_Click);
            // 
            // Btn_ActualizaLote
            // 
            this.Btn_ActualizaLote.Location = new System.Drawing.Point(92, 49);
            this.Btn_ActualizaLote.Name = "Btn_ActualizaLote";
            this.Btn_ActualizaLote.Size = new System.Drawing.Size(75, 38);
            this.Btn_ActualizaLote.TabIndex = 2;
            this.Btn_ActualizaLote.Text = "Actualiza Lote";
            this.Btn_ActualizaLote.UseVisualStyleBackColor = true;
            this.Btn_ActualizaLote.Click += new System.EventHandler(this.Btn_ActualizaLote_Click);
            // 
            // Lbl_Lote
            // 
            this.Lbl_Lote.AutoSize = true;
            this.Lbl_Lote.Location = new System.Drawing.Point(89, 90);
            this.Lbl_Lote.Name = "Lbl_Lote";
            this.Lbl_Lote.Size = new System.Drawing.Size(70, 13);
            this.Lbl_Lote.TabIndex = 3;
            this.Lbl_Lote.Text = " 2612432102";
            // 
            // Btn_lotesProblema
            // 
            this.Btn_lotesProblema.Location = new System.Drawing.Point(7, 1);
            this.Btn_lotesProblema.Name = "Btn_lotesProblema";
            this.Btn_lotesProblema.Size = new System.Drawing.Size(75, 38);
            this.Btn_lotesProblema.TabIndex = 4;
            this.Btn_lotesProblema.Text = "Lotes con Problemas";
            this.Btn_lotesProblema.UseVisualStyleBackColor = true;
            this.Btn_lotesProblema.Click += new System.EventHandler(this.Btn_lotesProblema_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_RevisaHD);
            this.groupBox2.Controls.Add(this.Btn_ActualizaPorViaje);
            this.groupBox2.Controls.Add(this.Tx_Codigo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(173, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 88);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Por IT";
            // 
            // Btn_RevisaHD
            // 
            this.Btn_RevisaHD.Location = new System.Drawing.Point(163, 53);
            this.Btn_RevisaHD.Name = "Btn_RevisaHD";
            this.Btn_RevisaHD.Size = new System.Drawing.Size(113, 29);
            this.Btn_RevisaHD.TabIndex = 4;
            this.Btn_RevisaHD.Text = "Revisa Archivos HD";
            this.Btn_RevisaHD.UseVisualStyleBackColor = true;
            this.Btn_RevisaHD.Click += new System.EventHandler(this.Btn_RevisaHD_Click);
            // 
            // Btn_ActualizaPorViaje
            // 
            this.Btn_ActualizaPorViaje.Location = new System.Drawing.Point(163, 13);
            this.Btn_ActualizaPorViaje.Name = "Btn_ActualizaPorViaje";
            this.Btn_ActualizaPorViaje.Size = new System.Drawing.Size(113, 29);
            this.Btn_ActualizaPorViaje.TabIndex = 3;
            this.Btn_ActualizaPorViaje.Text = "Actualiza Por Viaje";
            this.Btn_ActualizaPorViaje.UseVisualStyleBackColor = true;
            this.Btn_ActualizaPorViaje.Click += new System.EventHandler(this.Btn_ActualizaPorViaje_Click);
            // 
            // Tx_Codigo
            // 
            this.Tx_Codigo.Location = new System.Drawing.Point(58, 35);
            this.Tx_Codigo.Name = "Tx_Codigo";
            this.Tx_Codigo.Size = new System.Drawing.Size(99, 20);
            this.Tx_Codigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Viaje";
            // 
            // Btn_CP
            // 
            this.Btn_CP.Location = new System.Drawing.Point(461, 9);
            this.Btn_CP.Name = "Btn_CP";
            this.Btn_CP.Size = new System.Drawing.Size(81, 49);
            this.Btn_CP.TabIndex = 6;
            this.Btn_CP.Text = "Actualizar Certificados paquete";
            this.Btn_CP.UseVisualStyleBackColor = true;
            this.Btn_CP.Click += new System.EventHandler(this.Btn_CP_Click);
            // 
            // Btn_CorrigueEV
            // 
            this.Btn_CorrigueEV.Enabled = false;
            this.Btn_CorrigueEV.Location = new System.Drawing.Point(1022, 14);
            this.Btn_CorrigueEV.Name = "Btn_CorrigueEV";
            this.Btn_CorrigueEV.Size = new System.Drawing.Size(75, 38);
            this.Btn_CorrigueEV.TabIndex = 7;
            this.Btn_CorrigueEV.Text = "Corrige EV";
            this.Btn_CorrigueEV.UseVisualStyleBackColor = true;
            this.Btn_CorrigueEV.Click += new System.EventHandler(this.Btn_CorrigueEV_Click);
            // 
            // Btn_ReparaET
            // 
            this.Btn_ReparaET.Enabled = false;
            this.Btn_ReparaET.Location = new System.Drawing.Point(548, 14);
            this.Btn_ReparaET.Name = "Btn_ReparaET";
            this.Btn_ReparaET.Size = new System.Drawing.Size(102, 38);
            this.Btn_ReparaET.TabIndex = 8;
            this.Btn_ReparaET.Text = "Repara ET. no vinculada";
            this.Btn_ReparaET.UseVisualStyleBackColor = true;
            this.Btn_ReparaET.Click += new System.EventHandler(this.Btn_ReparaET_Click);
            // 
            // Lbl_IdPaquete
            // 
            this.Lbl_IdPaquete.AutoSize = true;
            this.Lbl_IdPaquete.Location = new System.Drawing.Point(558, 59);
            this.Lbl_IdPaquete.Name = "Lbl_IdPaquete";
            this.Lbl_IdPaquete.Size = new System.Drawing.Size(70, 13);
            this.Lbl_IdPaquete.TabIndex = 9;
            this.Lbl_IdPaquete.Text = " 2612432102";
            // 
            // Lbl_Diam
            // 
            this.Lbl_Diam.AutoSize = true;
            this.Lbl_Diam.Location = new System.Drawing.Point(558, 74);
            this.Lbl_Diam.Name = "Lbl_Diam";
            this.Lbl_Diam.Size = new System.Drawing.Size(70, 13);
            this.Lbl_Diam.TabIndex = 10;
            this.Lbl_Diam.Text = " 2612432102";
            // 
            // Lbl_Kgs
            // 
            this.Lbl_Kgs.AutoSize = true;
            this.Lbl_Kgs.Location = new System.Drawing.Point(558, 87);
            this.Lbl_Kgs.Name = "Lbl_Kgs";
            this.Lbl_Kgs.Size = new System.Drawing.Size(70, 13);
            this.Lbl_Kgs.TabIndex = 11;
            this.Lbl_Kgs.Text = " 2612432102";
            // 
            // Btn_VerLote
            // 
            this.Btn_VerLote.Location = new System.Drawing.Point(656, 9);
            this.Btn_VerLote.Name = "Btn_VerLote";
            this.Btn_VerLote.Size = new System.Drawing.Size(75, 38);
            this.Btn_VerLote.TabIndex = 12;
            this.Btn_VerLote.Text = "Ver Lote AZA";
            this.Btn_VerLote.UseVisualStyleBackColor = true;
            this.Btn_VerLote.Click += new System.EventHandler(this.Btn_VerLote_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Tx_lote);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(737, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(112, 63);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ver Lote";
            // 
            // Tx_lote
            // 
            this.Tx_lote.Location = new System.Drawing.Point(6, 33);
            this.Tx_lote.Name = "Tx_lote";
            this.Tx_lote.Size = new System.Drawing.Size(99, 20);
            this.Tx_lote.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "LOTE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(656, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 38);
            this.button1.TabIndex = 14;
            this.button1.Text = "Descarga Doc CAP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_LoteForzado
            // 
            this.Btn_LoteForzado.Location = new System.Drawing.Point(871, 9);
            this.Btn_LoteForzado.Name = "Btn_LoteForzado";
            this.Btn_LoteForzado.Size = new System.Drawing.Size(75, 38);
            this.Btn_LoteForzado.TabIndex = 15;
            this.Btn_LoteForzado.Text = "Actualiza Lote forzado";
            this.Btn_LoteForzado.UseVisualStyleBackColor = true;
            this.Btn_LoteForzado.Click += new System.EventHandler(this.Btn_LoteForzado_Click);
            // 
            // Btn_ObtenerLotesV2
            // 
            this.Btn_ObtenerLotesV2.Location = new System.Drawing.Point(173, 90);
            this.Btn_ObtenerLotesV2.Name = "Btn_ObtenerLotesV2";
            this.Btn_ObtenerLotesV2.Size = new System.Drawing.Size(99, 25);
            this.Btn_ObtenerLotesV2.TabIndex = 16;
            this.Btn_ObtenerLotesV2.Text = "Obtener Lotes V2";
            this.Btn_ObtenerLotesV2.UseVisualStyleBackColor = true;
            this.Btn_ObtenerLotesV2.Click += new System.EventHandler(this.Btn_ObtenerLotesV2_Click);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_Msg.Location = new System.Drawing.Point(295, 92);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(257, 23);
            this.Lbl_Msg.TabIndex = 17;
            this.Lbl_Msg.Text = " 2612432102";
            this.Lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_GeneraProducciones
            // 
            this.btn_GeneraProducciones.Location = new System.Drawing.Point(871, 69);
            this.btn_GeneraProducciones.Name = "btn_GeneraProducciones";
            this.btn_GeneraProducciones.Size = new System.Drawing.Size(89, 38);
            this.btn_GeneraProducciones.TabIndex = 18;
            this.btn_GeneraProducciones.Text = "Genera Producciones";
            this.btn_GeneraProducciones.UseVisualStyleBackColor = true;
            this.btn_GeneraProducciones.Click += new System.EventHandler(this.btn_GeneraProducciones_Click);
            // 
            // Frm_CertificacionViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 436);
            this.Controls.Add(this.btn_GeneraProducciones);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.Btn_ObtenerLotesV2);
            this.Controls.Add(this.Btn_LoteForzado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Btn_VerLote);
            this.Controls.Add(this.Lbl_Kgs);
            this.Controls.Add(this.Lbl_Diam);
            this.Controls.Add(this.Lbl_IdPaquete);
            this.Controls.Add(this.Btn_ReparaET);
            this.Controls.Add(this.Btn_CorrigueEV);
            this.Controls.Add(this.Btn_CP);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Btn_lotesProblema);
            this.Controls.Add(this.Lbl_Lote);
            this.Controls.Add(this.Btn_ActualizaLote);
            this.Controls.Add(this.Btn_Refresh);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_CertificacionViaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_CertificacionViaje";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_CertificacionViaje_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_Datos;
        private System.Windows.Forms.Button Btn_Refresh;
        private System.Windows.Forms.Button Btn_ActualizaLote;
        private System.Windows.Forms.Label Lbl_Lote;
        private System.Windows.Forms.Button Btn_lotesProblema;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Tx_Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_ActualizaPorViaje;
        private System.Windows.Forms.Button Btn_CP;
        private System.Windows.Forms.Button Btn_CorrigueEV;
        private System.Windows.Forms.Button Btn_ReparaET;
        private System.Windows.Forms.Label Lbl_IdPaquete;
        private System.Windows.Forms.Label Lbl_Diam;
        private System.Windows.Forms.Label Lbl_Kgs;
        private System.Windows.Forms.Button Btn_VerLote;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Tx_lote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_RevisaHD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_LoteForzado;
        private System.Windows.Forms.Button Btn_ObtenerLotesV2;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.Button btn_GeneraProducciones;
    }
}