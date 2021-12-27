namespace Gestor_OC_Gerdau.Calidad
{
    partial class Frm_RevisaColadas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Btn_CargaTablaMySql = new System.Windows.Forms.Button();
            this.Btn_CargaDatos = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_Datos = new System.Windows.Forms.DataGridView();
            this.Btn_Actualiza = new System.Windows.Forms.Button();
            this.Btn_DescargaPdf = new System.Windows.Forms.Button();
            this.Btn_CD = new System.Windows.Forms.Button();
            this.Btn_Generar = new System.Windows.Forms.Button();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.Btn_Copia = new System.Windows.Forms.Button();
            this.Btn_GeneraDoc = new System.Windows.Forms.Button();
            this.Lbl_Viaje = new System.Windows.Forms.Label();
            this.Btn_ProcesaViaje = new System.Windows.Forms.Button();
            this.Btn_CertificadosOK = new System.Windows.Forms.Button();
            this.Btn_GeneraDocumentacion = new System.Windows.Forms.Button();
            this.Btn_CertPEND = new System.Windows.Forms.Button();
            this.Btn_RepararDup = new System.Windows.Forms.Button();
            this.Btn_Refresh = new System.Windows.Forms.Button();
            this.Btn_Reprocesacol = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Cmb_Estado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmb_Suc = new System.Windows.Forms.ComboBox();
            this.Btn_actualizaLote = new System.Windows.Forms.Button();
            this.Btn_NotificaLotes = new System.Windows.Forms.Button();
            this.Chk_SoloVer = new System.Windows.Forms.CheckBox();
            this.Btn_MailColadas = new System.Windows.Forms.Button();
            this.Btn_ProcesaCAP = new System.Windows.Forms.Button();
            this.Btn_GuiasNO_Escaneadas = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_CargaTablaMySql
            // 
            this.Btn_CargaTablaMySql.Location = new System.Drawing.Point(135, 9);
            this.Btn_CargaTablaMySql.Name = "Btn_CargaTablaMySql";
            this.Btn_CargaTablaMySql.Size = new System.Drawing.Size(54, 17);
            this.Btn_CargaTablaMySql.TabIndex = 0;
            this.Btn_CargaTablaMySql.Text = "Carga Tabla Temporal";
            this.Btn_CargaTablaMySql.UseVisualStyleBackColor = true;
            this.Btn_CargaTablaMySql.Visible = false;
            this.Btn_CargaTablaMySql.Click += new System.EventHandler(this.Btn_CargaTablaMySql_Click);
            // 
            // Btn_CargaDatos
            // 
            this.Btn_CargaDatos.Location = new System.Drawing.Point(650, 44);
            this.Btn_CargaDatos.Name = "Btn_CargaDatos";
            this.Btn_CargaDatos.Size = new System.Drawing.Size(74, 39);
            this.Btn_CargaDatos.TabIndex = 1;
            this.Btn_CargaDatos.Text = "Nuevo Report";
            this.Btn_CargaDatos.UseVisualStyleBackColor = true;
            this.Btn_CargaDatos.Click += new System.EventHandler(this.Btn_CargaDatos_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Dtg_Datos);
            this.groupBox1.Location = new System.Drawing.Point(11, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 351);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Dtg_Datos
            // 
            this.Dtg_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Datos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Datos.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Datos.Name = "Dtg_Datos";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dtg_Datos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dtg_Datos.Size = new System.Drawing.Size(982, 332);
            this.Dtg_Datos.TabIndex = 0;
            this.Dtg_Datos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Datos_CellClick);
            this.Dtg_Datos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Datos_CellContentClick);
            this.Dtg_Datos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_Datos_CellDoubleClick);
            // 
            // Btn_Actualiza
            // 
            this.Btn_Actualiza.Location = new System.Drawing.Point(344, 0);
            this.Btn_Actualiza.Name = "Btn_Actualiza";
            this.Btn_Actualiza.Size = new System.Drawing.Size(70, 34);
            this.Btn_Actualiza.TabIndex = 3;
            this.Btn_Actualiza.Text = "Actualiza Certificados";
            this.Btn_Actualiza.UseVisualStyleBackColor = true;
            this.Btn_Actualiza.Visible = false;
            this.Btn_Actualiza.Click += new System.EventHandler(this.Btn_Actualiza_Click);
            // 
            // Btn_DescargaPdf
            // 
            this.Btn_DescargaPdf.Location = new System.Drawing.Point(195, 4);
            this.Btn_DescargaPdf.Name = "Btn_DescargaPdf";
            this.Btn_DescargaPdf.Size = new System.Drawing.Size(37, 24);
            this.Btn_DescargaPdf.TabIndex = 4;
            this.Btn_DescargaPdf.Text = "Descarga Pdfs";
            this.Btn_DescargaPdf.UseVisualStyleBackColor = true;
            this.Btn_DescargaPdf.Visible = false;
            this.Btn_DescargaPdf.Click += new System.EventHandler(this.Btn_DescargaPdf_Click);
            // 
            // Btn_CD
            // 
            this.Btn_CD.Location = new System.Drawing.Point(384, 4);
            this.Btn_CD.Name = "Btn_CD";
            this.Btn_CD.Size = new System.Drawing.Size(76, 34);
            this.Btn_CD.TabIndex = 5;
            this.Btn_CD.Text = "Certificados Directorios";
            this.Btn_CD.UseVisualStyleBackColor = true;
            this.Btn_CD.Visible = false;
            this.Btn_CD.Click += new System.EventHandler(this.Btn_CD_Click);
            // 
            // Btn_Generar
            // 
            this.Btn_Generar.Location = new System.Drawing.Point(14, 31);
            this.Btn_Generar.Name = "Btn_Generar";
            this.Btn_Generar.Size = new System.Drawing.Size(108, 28);
            this.Btn_Generar.TabIndex = 6;
            this.Btn_Generar.Text = "1.- Genera Datos";
            this.Btn_Generar.UseVisualStyleBackColor = true;
            this.Btn_Generar.Click += new System.EventHandler(this.Btn_Generar_Click);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.AutoSize = true;
            this.Lbl_Msg.Location = new System.Drawing.Point(507, 70);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Msg.TabIndex = 7;
            this.Lbl_Msg.Text = "label1";
            // 
            // PB
            // 
            this.PB.Location = new System.Drawing.Point(428, 5);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(293, 18);
            this.PB.TabIndex = 8;
            // 
            // Btn_Copia
            // 
            this.Btn_Copia.Location = new System.Drawing.Point(888, 5);
            this.Btn_Copia.Name = "Btn_Copia";
            this.Btn_Copia.Size = new System.Drawing.Size(108, 42);
            this.Btn_Copia.TabIndex = 9;
            this.Btn_Copia.Text = "Envia Etiquetas No Cerradas";
            this.Btn_Copia.UseVisualStyleBackColor = true;
            this.Btn_Copia.Click += new System.EventHandler(this.Btn_Copia_Click);
            // 
            // Btn_GeneraDoc
            // 
            this.Btn_GeneraDoc.Location = new System.Drawing.Point(163, -5);
            this.Btn_GeneraDoc.Name = "Btn_GeneraDoc";
            this.Btn_GeneraDoc.Size = new System.Drawing.Size(53, 26);
            this.Btn_GeneraDoc.TabIndex = 10;
            this.Btn_GeneraDoc.Text = "Genera acta de entrega";
            this.Btn_GeneraDoc.UseVisualStyleBackColor = true;
            this.Btn_GeneraDoc.Visible = false;
            this.Btn_GeneraDoc.Click += new System.EventHandler(this.Btn_GeneraDoc_Click);
            // 
            // Lbl_Viaje
            // 
            this.Lbl_Viaje.AutoSize = true;
            this.Lbl_Viaje.Location = new System.Drawing.Point(667, 46);
            this.Lbl_Viaje.Name = "Lbl_Viaje";
            this.Lbl_Viaje.Size = new System.Drawing.Size(0, 13);
            this.Lbl_Viaje.TabIndex = 11;
            // 
            // Btn_ProcesaViaje
            // 
            this.Btn_ProcesaViaje.Location = new System.Drawing.Point(493, 26);
            this.Btn_ProcesaViaje.Name = "Btn_ProcesaViaje";
            this.Btn_ProcesaViaje.Size = new System.Drawing.Size(64, 36);
            this.Btn_ProcesaViaje.TabIndex = 12;
            this.Btn_ProcesaViaje.Text = "Clasifica Viajes";
            this.Btn_ProcesaViaje.UseVisualStyleBackColor = true;
            this.Btn_ProcesaViaje.Click += new System.EventHandler(this.Btn_ProcesaViaje_Click);
            // 
            // Btn_CertificadosOK
            // 
            this.Btn_CertificadosOK.Location = new System.Drawing.Point(818, 2);
            this.Btn_CertificadosOK.Name = "Btn_CertificadosOK";
            this.Btn_CertificadosOK.Size = new System.Drawing.Size(64, 30);
            this.Btn_CertificadosOK.TabIndex = 13;
            this.Btn_CertificadosOK.Text = "Cert. OK";
            this.Btn_CertificadosOK.UseVisualStyleBackColor = true;
            this.Btn_CertificadosOK.Click += new System.EventHandler(this.Btn_CertificadosOK_Click);
            // 
            // Btn_GeneraDocumentacion
            // 
            this.Btn_GeneraDocumentacion.Location = new System.Drawing.Point(11, 62);
            this.Btn_GeneraDocumentacion.Name = "Btn_GeneraDocumentacion";
            this.Btn_GeneraDocumentacion.Size = new System.Drawing.Size(160, 28);
            this.Btn_GeneraDocumentacion.TabIndex = 14;
            this.Btn_GeneraDocumentacion.Text = "2.-Genera Documentación";
            this.Btn_GeneraDocumentacion.UseVisualStyleBackColor = true;
            this.Btn_GeneraDocumentacion.Click += new System.EventHandler(this.Btn_GeneraDocumentacion_Click);
            // 
            // Btn_CertPEND
            // 
            this.Btn_CertPEND.Location = new System.Drawing.Point(821, 36);
            this.Btn_CertPEND.Name = "Btn_CertPEND";
            this.Btn_CertPEND.Size = new System.Drawing.Size(64, 30);
            this.Btn_CertPEND.TabIndex = 15;
            this.Btn_CertPEND.Text = "Cert. PEN";
            this.Btn_CertPEND.UseVisualStyleBackColor = true;
            this.Btn_CertPEND.Click += new System.EventHandler(this.Btn_CertPEND_Click);
            // 
            // Btn_RepararDup
            // 
            this.Btn_RepararDup.Location = new System.Drawing.Point(2, 4);
            this.Btn_RepararDup.Name = "Btn_RepararDup";
            this.Btn_RepararDup.Size = new System.Drawing.Size(64, 34);
            this.Btn_RepararDup.TabIndex = 16;
            this.Btn_RepararDup.Text = "Repara Duplicados";
            this.Btn_RepararDup.UseVisualStyleBackColor = true;
            this.Btn_RepararDup.Click += new System.EventHandler(this.Btn_RepararDup_Click);
            // 
            // Btn_Refresh
            // 
            this.Btn_Refresh.Location = new System.Drawing.Point(72, 4);
            this.Btn_Refresh.Name = "Btn_Refresh";
            this.Btn_Refresh.Size = new System.Drawing.Size(85, 34);
            this.Btn_Refresh.TabIndex = 17;
            this.Btn_Refresh.Text = "Refresca Datos";
            this.Btn_Refresh.UseVisualStyleBackColor = true;
            this.Btn_Refresh.Click += new System.EventHandler(this.Btn_Refresh_Click);
            // 
            // Btn_Reprocesacol
            // 
            this.Btn_Reprocesacol.Location = new System.Drawing.Point(572, 24);
            this.Btn_Reprocesacol.Name = "Btn_Reprocesacol";
            this.Btn_Reprocesacol.Size = new System.Drawing.Size(72, 34);
            this.Btn_Reprocesacol.TabIndex = 18;
            this.Btn_Reprocesacol.Text = "Reprocesa Coladas";
            this.Btn_Reprocesacol.UseVisualStyleBackColor = true;
            this.Btn_Reprocesacol.Click += new System.EventHandler(this.Btn_Reprocesacol_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_Buscar);
            this.groupBox2.Controls.Add(this.Cmb_Estado);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Cmb_Suc);
            this.groupBox2.Location = new System.Drawing.Point(177, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 65);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(251, 19);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(53, 26);
            this.Btn_Buscar.TabIndex = 11;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Cmb_Estado
            // 
            this.Cmb_Estado.FormattingEnabled = true;
            this.Cmb_Estado.Location = new System.Drawing.Point(162, 27);
            this.Cmb_Estado.Name = "Cmb_Estado";
            this.Cmb_Estado.Size = new System.Drawing.Size(77, 21);
            this.Cmb_Estado.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Sucursal";
            // 
            // Cmb_Suc
            // 
            this.Cmb_Suc.FormattingEnabled = true;
            this.Cmb_Suc.Location = new System.Drawing.Point(4, 28);
            this.Cmb_Suc.Name = "Cmb_Suc";
            this.Cmb_Suc.Size = new System.Drawing.Size(148, 21);
            this.Cmb_Suc.TabIndex = 0;
            // 
            // Btn_actualizaLote
            // 
            this.Btn_actualizaLote.Location = new System.Drawing.Point(891, 53);
            this.Btn_actualizaLote.Name = "Btn_actualizaLote";
            this.Btn_actualizaLote.Size = new System.Drawing.Size(108, 28);
            this.Btn_actualizaLote.TabIndex = 20;
            this.Btn_actualizaLote.Text = "Temp";
            this.Btn_actualizaLote.UseVisualStyleBackColor = true;
            this.Btn_actualizaLote.Click += new System.EventHandler(this.Btn_actualizaLote_Click);
            // 
            // Btn_NotificaLotes
            // 
            this.Btn_NotificaLotes.Location = new System.Drawing.Point(730, 3);
            this.Btn_NotificaLotes.Name = "Btn_NotificaLotes";
            this.Btn_NotificaLotes.Size = new System.Drawing.Size(85, 34);
            this.Btn_NotificaLotes.TabIndex = 21;
            this.Btn_NotificaLotes.Text = "Envia Mail cliente";
            this.Btn_NotificaLotes.UseVisualStyleBackColor = true;
            this.Btn_NotificaLotes.Click += new System.EventHandler(this.Btn_NotificaLotes_Click);
            // 
            // Chk_SoloVer
            // 
            this.Chk_SoloVer.AutoSize = true;
            this.Chk_SoloVer.Location = new System.Drawing.Point(572, 73);
            this.Chk_SoloVer.Name = "Chk_SoloVer";
            this.Chk_SoloVer.Size = new System.Drawing.Size(66, 17);
            this.Chk_SoloVer.TabIndex = 22;
            this.Chk_SoloVer.Text = "Solo Ver";
            this.Chk_SoloVer.UseVisualStyleBackColor = true;
            // 
            // Btn_MailColadas
            // 
            this.Btn_MailColadas.Location = new System.Drawing.Point(730, 34);
            this.Btn_MailColadas.Name = "Btn_MailColadas";
            this.Btn_MailColadas.Size = new System.Drawing.Size(85, 34);
            this.Btn_MailColadas.TabIndex = 23;
            this.Btn_MailColadas.Text = "Mail Coladas ";
            this.Btn_MailColadas.UseVisualStyleBackColor = true;
            this.Btn_MailColadas.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_ProcesaCAP
            // 
            this.Btn_ProcesaCAP.Location = new System.Drawing.Point(730, 74);
            this.Btn_ProcesaCAP.Name = "Btn_ProcesaCAP";
            this.Btn_ProcesaCAP.Size = new System.Drawing.Size(85, 26);
            this.Btn_ProcesaCAP.TabIndex = 24;
            this.Btn_ProcesaCAP.Text = "Procesa CAP ";
            this.Btn_ProcesaCAP.UseVisualStyleBackColor = true;
            this.Btn_ProcesaCAP.Click += new System.EventHandler(this.Btn_ProcesaCAP_Click);
            // 
            // Btn_GuiasNO_Escaneadas
            // 
            this.Btn_GuiasNO_Escaneadas.Location = new System.Drawing.Point(244, -5);
            this.Btn_GuiasNO_Escaneadas.Name = "Btn_GuiasNO_Escaneadas";
            this.Btn_GuiasNO_Escaneadas.Size = new System.Drawing.Size(94, 43);
            this.Btn_GuiasNO_Escaneadas.TabIndex = 25;
            this.Btn_GuiasNO_Escaneadas.Text = "Envia Guias NO Escaneadas";
            this.Btn_GuiasNO_Escaneadas.UseVisualStyleBackColor = true;
            this.Btn_GuiasNO_Escaneadas.Click += new System.EventHandler(this.Btn_GuiasNO_Escaneadas_Click);
            // 
            // Frm_RevisaColadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 450);
            this.Controls.Add(this.Btn_GuiasNO_Escaneadas);
            this.Controls.Add(this.Btn_ProcesaCAP);
            this.Controls.Add(this.Btn_CargaDatos);
            this.Controls.Add(this.Btn_MailColadas);
            this.Controls.Add(this.Chk_SoloVer);
            this.Controls.Add(this.Btn_NotificaLotes);
            this.Controls.Add(this.Btn_actualizaLote);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Btn_Reprocesacol);
            this.Controls.Add(this.Btn_Refresh);
            this.Controls.Add(this.Btn_RepararDup);
            this.Controls.Add(this.Btn_CertPEND);
            this.Controls.Add(this.Btn_GeneraDocumentacion);
            this.Controls.Add(this.Btn_CertificadosOK);
            this.Controls.Add(this.Btn_ProcesaViaje);
            this.Controls.Add(this.Lbl_Viaje);
            this.Controls.Add(this.Btn_GeneraDoc);
            this.Controls.Add(this.Btn_Copia);
            this.Controls.Add(this.PB);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.Btn_Generar);
            this.Controls.Add(this.Btn_CD);
            this.Controls.Add(this.Btn_DescargaPdf);
            this.Controls.Add(this.Btn_Actualiza);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_CargaTablaMySql);
            this.Name = "Frm_RevisaColadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_RevisaColadas";
            this.Load += new System.EventHandler(this.Frm_RevisaColadas_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_CargaTablaMySql;
        private System.Windows.Forms.Button Btn_CargaDatos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_Datos;
        private System.Windows.Forms.Button Btn_Actualiza;
        private System.Windows.Forms.Button Btn_DescargaPdf;
        private System.Windows.Forms.Button Btn_CD;
        private System.Windows.Forms.Button Btn_Generar;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.ProgressBar PB;
        private System.Windows.Forms.Button Btn_Copia;
        private System.Windows.Forms.Button Btn_GeneraDoc;
        private System.Windows.Forms.Label Lbl_Viaje;
        private System.Windows.Forms.Button Btn_ProcesaViaje;
        private System.Windows.Forms.Button Btn_CertificadosOK;
        private System.Windows.Forms.Button Btn_GeneraDocumentacion;
        private System.Windows.Forms.Button Btn_CertPEND;
        private System.Windows.Forms.Button Btn_RepararDup;
        private System.Windows.Forms.Button Btn_Refresh;
        private System.Windows.Forms.Button Btn_Reprocesacol;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.ComboBox Cmb_Estado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmb_Suc;
        private System.Windows.Forms.Button Btn_actualizaLote;
        private System.Windows.Forms.Button Btn_NotificaLotes;
        private System.Windows.Forms.CheckBox Chk_SoloVer;
        private System.Windows.Forms.Button Btn_MailColadas;
        private System.Windows.Forms.Button Btn_ProcesaCAP;
        private System.Windows.Forms.Button Btn_GuiasNO_Escaneadas;
    }
}