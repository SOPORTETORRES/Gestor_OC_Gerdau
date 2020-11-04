namespace Gestor_OC_Gerdau
{
    partial class Frm_ppal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Btn_ObtenerDatos = new System.Windows.Forms.Button();
            this.Dtg = new System.Windows.Forms.DataGridView();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.dtg_det = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_CrearArchivo = new System.Windows.Forms.Button();
            this.Btn_subirArchivos = new System.Windows.Forms.Button();
            this.Btn_PruebasFTP = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Btn_procesar = new System.Windows.Forms.Button();
            this.PB_Avance = new System.Windows.Forms.ProgressBar();
            this.Lb_Msg = new System.Windows.Forms.Label();
            this.TX_Estado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_det)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_ObtenerDatos
            // 
            this.Btn_ObtenerDatos.Location = new System.Drawing.Point(683, 12);
            this.Btn_ObtenerDatos.Name = "Btn_ObtenerDatos";
            this.Btn_ObtenerDatos.Size = new System.Drawing.Size(97, 38);
            this.Btn_ObtenerDatos.TabIndex = 0;
            this.Btn_ObtenerDatos.Text = "Obtener Datos";
            this.Btn_ObtenerDatos.UseVisualStyleBackColor = true;
            this.Btn_ObtenerDatos.Click += new System.EventHandler(this.Btn_ObtenerDatos_Click);
            // 
            // Dtg
            // 
            this.Dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg.Location = new System.Drawing.Point(12, 31);
            this.Dtg.Name = "Dtg";
            this.Dtg.Size = new System.Drawing.Size(665, 111);
            this.Dtg.TabIndex = 1;
            this.Dtg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dtg_CellContentClick);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Location = new System.Drawing.Point(683, 122);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(97, 38);
            this.Btn_Salir.TabIndex = 2;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // dtg_det
            // 
            this.dtg_det.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_det.Location = new System.Drawing.Point(743, 225);
            this.dtg_det.Name = "dtg_det";
            this.dtg_det.Size = new System.Drawing.Size(37, 25);
            this.dtg_det.TabIndex = 3;
            this.dtg_det.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(665, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "OC  POR ENVIAR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(12, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(665, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Log de Envio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_CrearArchivo
            // 
            this.Btn_CrearArchivo.Location = new System.Drawing.Point(707, 300);
            this.Btn_CrearArchivo.Name = "Btn_CrearArchivo";
            this.Btn_CrearArchivo.Size = new System.Drawing.Size(73, 38);
            this.Btn_CrearArchivo.TabIndex = 6;
            this.Btn_CrearArchivo.Text = "Crear Archivo";
            this.Btn_CrearArchivo.UseVisualStyleBackColor = true;
            this.Btn_CrearArchivo.Visible = false;
            this.Btn_CrearArchivo.Click += new System.EventHandler(this.Btn_CrearArchivo_Click);
            // 
            // Btn_subirArchivos
            // 
            this.Btn_subirArchivos.Location = new System.Drawing.Point(683, 171);
            this.Btn_subirArchivos.Name = "Btn_subirArchivos";
            this.Btn_subirArchivos.Size = new System.Drawing.Size(97, 38);
            this.Btn_subirArchivos.TabIndex = 7;
            this.Btn_subirArchivos.Text = "Subier Archivos al FTP";
            this.Btn_subirArchivos.UseVisualStyleBackColor = true;
            this.Btn_subirArchivos.Visible = false;
            this.Btn_subirArchivos.Click += new System.EventHandler(this.Btn_subirArchivos_Click);
            // 
            // Btn_PruebasFTP
            // 
            this.Btn_PruebasFTP.Location = new System.Drawing.Point(707, 256);
            this.Btn_PruebasFTP.Name = "Btn_PruebasFTP";
            this.Btn_PruebasFTP.Size = new System.Drawing.Size(73, 38);
            this.Btn_PruebasFTP.TabIndex = 8;
            this.Btn_PruebasFTP.Text = "Envio Mail";
            this.Btn_PruebasFTP.UseVisualStyleBackColor = true;
            this.Btn_PruebasFTP.Visible = false;
            this.Btn_PruebasFTP.Click += new System.EventHandler(this.Btn_PruebasFTP_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Btn_procesar
            // 
            this.Btn_procesar.Location = new System.Drawing.Point(683, 67);
            this.Btn_procesar.Name = "Btn_procesar";
            this.Btn_procesar.Size = new System.Drawing.Size(97, 38);
            this.Btn_procesar.TabIndex = 9;
            this.Btn_procesar.Text = "Procesar Archivo";
            this.Btn_procesar.UseVisualStyleBackColor = true;
            this.Btn_procesar.Click += new System.EventHandler(this.Btn_procesar_Click);
            // 
            // PB_Avance
            // 
            this.PB_Avance.Location = new System.Drawing.Point(100, 148);
            this.PB_Avance.Name = "PB_Avance";
            this.PB_Avance.Size = new System.Drawing.Size(488, 18);
            this.PB_Avance.TabIndex = 10;
            this.PB_Avance.Visible = false;
            // 
            // Lb_Msg
            // 
            this.Lb_Msg.AutoSize = true;
            this.Lb_Msg.Location = new System.Drawing.Point(97, 171);
            this.Lb_Msg.Name = "Lb_Msg";
            this.Lb_Msg.Size = new System.Drawing.Size(35, 13);
            this.Lb_Msg.TabIndex = 11;
            this.Lb_Msg.Text = "label3";
            this.Lb_Msg.Visible = false;
            // 
            // TX_Estado
            // 
            this.TX_Estado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TX_Estado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TX_Estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TX_Estado.Location = new System.Drawing.Point(12, 221);
            this.TX_Estado.Multiline = true;
            this.TX_Estado.Name = "TX_Estado";
            this.TX_Estado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TX_Estado.Size = new System.Drawing.Size(673, 278);
            this.TX_Estado.TabIndex = 13;
            // 
            // Frm_ppal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 499);
            this.Controls.Add(this.TX_Estado);
            this.Controls.Add(this.Lb_Msg);
            this.Controls.Add(this.PB_Avance);
            this.Controls.Add(this.Btn_procesar);
            this.Controls.Add(this.Btn_PruebasFTP);
            this.Controls.Add(this.Btn_subirArchivos);
            this.Controls.Add(this.Btn_CrearArchivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtg_det);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Dtg);
            this.Controls.Add(this.Btn_ObtenerDatos);
            this.Name = "Frm_ppal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Envio y Gestion de OC con Gerdau";
            this.Load += new System.EventHandler(this.Frm_ppal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_det)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_ObtenerDatos;
        private System.Windows.Forms.DataGridView Dtg;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.DataGridView dtg_det;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_CrearArchivo;
        private System.Windows.Forms.Button Btn_subirArchivos;
        private System.Windows.Forms.Button Btn_PruebasFTP;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Btn_procesar;
        private System.Windows.Forms.ProgressBar PB_Avance;
        private System.Windows.Forms.Label Lb_Msg;
        internal System.Windows.Forms.TextBox TX_Estado;
    }
}

