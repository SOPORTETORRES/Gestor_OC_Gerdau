namespace Gestor_OC_Gerdau.Logistica
{
    partial class Frm_ProcesaGDE
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
            this.button1 = new System.Windows.Forms.Button();
            this.Dtg_Datos = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.Lbl_NroGuia = new System.Windows.Forms.Label();
            this.Tx_NroGuia = new System.Windows.Forms.TextBox();
            this.Tx_Msg = new System.Windows.Forms.TextBox();
            this.Btn_CopiaGuia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "CargaDatos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dtg_Datos
            // 
            this.Dtg_Datos.AllowUserToAddRows = false;
            this.Dtg_Datos.AllowUserToDeleteRows = false;
            this.Dtg_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Datos.Location = new System.Drawing.Point(5, 85);
            this.Dtg_Datos.Name = "Dtg_Datos";
            this.Dtg_Datos.ReadOnly = true;
            this.Dtg_Datos.Size = new System.Drawing.Size(790, 361);
            this.Dtg_Datos.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(228, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Procesa Datos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Location = new System.Drawing.Point(680, 9);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(87, 34);
            this.Btn_Salir.TabIndex = 3;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.AutoSize = true;
            this.Lbl_Msg.Location = new System.Drawing.Point(225, 39);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Msg.TabIndex = 4;
            this.Lbl_Msg.Text = "label1";
            // 
            // Lbl_NroGuia
            // 
            this.Lbl_NroGuia.AutoSize = true;
            this.Lbl_NroGuia.Location = new System.Drawing.Point(372, 2);
            this.Lbl_NroGuia.Name = "Lbl_NroGuia";
            this.Lbl_NroGuia.Size = new System.Drawing.Size(54, 13);
            this.Lbl_NroGuia.TabIndex = 5;
            this.Lbl_NroGuia.Text = "Nro. Guía";
            // 
            // Tx_NroGuia
            // 
            this.Tx_NroGuia.Location = new System.Drawing.Point(373, 17);
            this.Tx_NroGuia.Name = "Tx_NroGuia";
            this.Tx_NroGuia.Size = new System.Drawing.Size(64, 20);
            this.Tx_NroGuia.TabIndex = 6;
            // 
            // Tx_Msg
            // 
            this.Tx_Msg.Location = new System.Drawing.Point(5, 59);
            this.Tx_Msg.Name = "Tx_Msg";
            this.Tx_Msg.Size = new System.Drawing.Size(790, 20);
            this.Tx_Msg.TabIndex = 7;
            // 
            // Btn_CopiaGuia
            // 
            this.Btn_CopiaGuia.Location = new System.Drawing.Point(460, 2);
            this.Btn_CopiaGuia.Name = "Btn_CopiaGuia";
            this.Btn_CopiaGuia.Size = new System.Drawing.Size(135, 34);
            this.Btn_CopiaGuia.TabIndex = 8;
            this.Btn_CopiaGuia.Text = "Conecta a Servidor web";
            this.Btn_CopiaGuia.UseVisualStyleBackColor = true;
            this.Btn_CopiaGuia.Visible = false;
            this.Btn_CopiaGuia.Click += new System.EventHandler(this.Btn_CopiaGuia_Click);
            // 
            // Frm_ProcesaGDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_CopiaGuia);
            this.Controls.Add(this.Tx_Msg);
            this.Controls.Add(this.Tx_NroGuia);
            this.Controls.Add(this.Lbl_NroGuia);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Dtg_Datos);
            this.Controls.Add(this.button1);
            this.Name = "Frm_ProcesaGDE";
            this.Text = "Frm_ProcesaGDE";
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView Dtg_Datos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.Label Lbl_NroGuia;
        private System.Windows.Forms.TextBox Tx_NroGuia;
        private System.Windows.Forms.TextBox Tx_Msg;
        private System.Windows.Forms.Button Btn_CopiaGuia;
    }
}