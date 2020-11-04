namespace Gestor_OC_Gerdau
{
    partial class EnviosAutomaticos
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
            this.components = new System.ComponentModel.Container();
            this.Btn_EnviaPL = new System.Windows.Forms.Button();
            this.Lbl_Estado = new System.Windows.Forms.Label();
            this.Pb_Avance = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.Lbl_Inicio = new System.Windows.Forms.Label();
            this.Lbl_Fin = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Envia_ILC = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Btn_EnvioProdTosol = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_Envios = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Tm_Envios = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Envios)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_EnviaPL
            // 
            this.Btn_EnviaPL.Location = new System.Drawing.Point(194, 20);
            this.Btn_EnviaPL.Name = "Btn_EnviaPL";
            this.Btn_EnviaPL.Size = new System.Drawing.Size(102, 45);
            this.Btn_EnviaPL.TabIndex = 0;
            this.Btn_EnviaPL.Text = "Envio PL Electronico";
            this.Btn_EnviaPL.UseVisualStyleBackColor = true;
            this.Btn_EnviaPL.Click += new System.EventHandler(this.Btn_EnviaPL_Click);
            // 
            // Lbl_Estado
            // 
            this.Lbl_Estado.AutoSize = true;
            this.Lbl_Estado.Location = new System.Drawing.Point(340, 68);
            this.Lbl_Estado.Name = "Lbl_Estado";
            this.Lbl_Estado.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Estado.TabIndex = 1;
            this.Lbl_Estado.Text = "label1";
            // 
            // Pb_Avance
            // 
            this.Pb_Avance.Location = new System.Drawing.Point(12, 84);
            this.Pb_Avance.Name = "Pb_Avance";
            this.Pb_Avance.Size = new System.Drawing.Size(692, 20);
            this.Pb_Avance.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inicio:";
            // 
            // Lbl_Inicio
            // 
            this.Lbl_Inicio.AutoSize = true;
            this.Lbl_Inicio.Location = new System.Drawing.Point(90, 20);
            this.Lbl_Inicio.Name = "Lbl_Inicio";
            this.Lbl_Inicio.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Inicio.TabIndex = 4;
            this.Lbl_Inicio.Text = "label1";
            // 
            // Lbl_Fin
            // 
            this.Lbl_Fin.AutoSize = true;
            this.Lbl_Fin.Location = new System.Drawing.Point(90, 45);
            this.Lbl_Fin.Name = "Lbl_Fin";
            this.Lbl_Fin.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Fin.TabIndex = 5;
            this.Lbl_Fin.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fin:";
            // 
            // Btn_Envia_ILC
            // 
            this.Btn_Envia_ILC.Location = new System.Drawing.Point(333, 20);
            this.Btn_Envia_ILC.Name = "Btn_Envia_ILC";
            this.Btn_Envia_ILC.Size = new System.Drawing.Size(102, 45);
            this.Btn_Envia_ILC.TabIndex = 7;
            this.Btn_Envia_ILC.Text = "Envío Informe L.C";
            this.Btn_Envia_ILC.UseVisualStyleBackColor = true;
            this.Btn_Envia_ILC.Visible = false;
            this.Btn_Envia_ILC.Click += new System.EventHandler(this.Btn_Envia_ILC_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 45);
            this.button2.TabIndex = 8;
            this.button2.Text = "Envio PL Electronico";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // Btn_EnvioProdTosol
            // 
            this.Btn_EnvioProdTosol.Location = new System.Drawing.Point(626, 20);
            this.Btn_EnvioProdTosol.Name = "Btn_EnvioProdTosol";
            this.Btn_EnvioProdTosol.Size = new System.Drawing.Size(102, 45);
            this.Btn_EnvioProdTosol.TabIndex = 9;
            this.Btn_EnvioProdTosol.Text = "Envío Produccion TOSOL";
            this.Btn_EnvioProdTosol.UseVisualStyleBackColor = true;
            this.Btn_EnvioProdTosol.Visible = false;
            this.Btn_EnvioProdTosol.Click += new System.EventHandler(this.Btn_EnvioProdTosol_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Dtg_Envios);
            this.groupBox1.Location = new System.Drawing.Point(17, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 270);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Envios Planificados";
            // 
            // Dtg_Envios
            // 
            this.Dtg_Envios.AllowUserToAddRows = false;
            this.Dtg_Envios.AllowUserToDeleteRows = false;
            this.Dtg_Envios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Envios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Envios.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Envios.Name = "Dtg_Envios";
            this.Dtg_Envios.ReadOnly = true;
            this.Dtg_Envios.Size = new System.Drawing.Size(772, 251);
            this.Dtg_Envios.TabIndex = 0;
            // 
            // Tm_Envios
            // 
            this.Tm_Envios.Interval = 60000;
            this.Tm_Envios.Tick += new System.EventHandler(this.Tm_Envios_Tick);
            // 
            // EnviosAutomaticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_EnvioProdTosol);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Btn_Envia_ILC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Lbl_Fin);
            this.Controls.Add(this.Lbl_Inicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pb_Avance);
            this.Controls.Add(this.Lbl_Estado);
            this.Controls.Add(this.Btn_EnviaPL);
            this.Name = "EnviosAutomaticos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Envios Automaticos";
            this.Load += new System.EventHandler(this.EnviosAutomaticos_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Envios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_EnviaPL;
        private System.Windows.Forms.Label Lbl_Estado;
        private System.Windows.Forms.ProgressBar Pb_Avance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lbl_Inicio;
        private System.Windows.Forms.Label Lbl_Fin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Envia_ILC;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Btn_EnvioProdTosol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_Envios;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer Tm_Envios;
    }
}