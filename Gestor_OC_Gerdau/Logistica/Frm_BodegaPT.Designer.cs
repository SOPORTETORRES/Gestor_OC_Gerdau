namespace Gestor_OC_Gerdau.Logistica
{
    partial class Frm_BodegaPT
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
            this.Btn_CargaDatos = new System.Windows.Forms.Button();
            this.dtg_datos = new System.Windows.Forms.DataGridView();
            this.Btn_ObtenerObj = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_IntegrarSaldo = new System.Windows.Forms.Button();
            this.Btn_verificar = new System.Windows.Forms.Button();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.Tx_It = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Lbl_Avance = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Btn_Redondea = new System.Windows.Forms.Button();
            this.Lbl_Resultado = new System.Windows.Forms.Label();
            this.Tx_IdSucursal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_datos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(629, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Prueba 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_CargaDatos
            // 
            this.Btn_CargaDatos.Location = new System.Drawing.Point(503, 10);
            this.Btn_CargaDatos.Name = "Btn_CargaDatos";
            this.Btn_CargaDatos.Size = new System.Drawing.Size(75, 41);
            this.Btn_CargaDatos.TabIndex = 1;
            this.Btn_CargaDatos.Text = "Carga Datos";
            this.Btn_CargaDatos.UseVisualStyleBackColor = true;
            this.Btn_CargaDatos.Click += new System.EventHandler(this.Btn_CargaDatos_Click);
            // 
            // dtg_datos
            // 
            this.dtg_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_datos.Location = new System.Drawing.Point(13, 13);
            this.dtg_datos.Name = "dtg_datos";
            this.dtg_datos.Size = new System.Drawing.Size(484, 472);
            this.dtg_datos.TabIndex = 2;
            // 
            // Btn_ObtenerObj
            // 
            this.Btn_ObtenerObj.Location = new System.Drawing.Point(503, 67);
            this.Btn_ObtenerObj.Name = "Btn_ObtenerObj";
            this.Btn_ObtenerObj.Size = new System.Drawing.Size(123, 45);
            this.Btn_ObtenerObj.TabIndex = 3;
            this.Btn_ObtenerObj.Text = "Procesa Datos";
            this.Btn_ObtenerObj.UseVisualStyleBackColor = true;
            this.Btn_ObtenerObj.Click += new System.EventHandler(this.Btn_ObtenerObj_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_IntegrarSaldo);
            this.groupBox1.Controls.Add(this.Btn_verificar);
            this.groupBox1.Controls.Add(this.Lbl_Msg);
            this.groupBox1.Controls.Add(this.Tx_It);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(513, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 199);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Integración  Guía Despacho";
            // 
            // Btn_IntegrarSaldo
            // 
            this.Btn_IntegrarSaldo.Location = new System.Drawing.Point(93, 149);
            this.Btn_IntegrarSaldo.Name = "Btn_IntegrarSaldo";
            this.Btn_IntegrarSaldo.Size = new System.Drawing.Size(96, 27);
            this.Btn_IntegrarSaldo.TabIndex = 4;
            this.Btn_IntegrarSaldo.Text = "Integrar saldo";
            this.Btn_IntegrarSaldo.UseVisualStyleBackColor = true;
            this.Btn_IntegrarSaldo.Click += new System.EventHandler(this.Btn_IntegrarSaldo_Click);
            // 
            // Btn_verificar
            // 
            this.Btn_verificar.Location = new System.Drawing.Point(105, 60);
            this.Btn_verificar.Name = "Btn_verificar";
            this.Btn_verificar.Size = new System.Drawing.Size(59, 27);
            this.Btn_verificar.TabIndex = 3;
            this.Btn_verificar.Text = "Verificar";
            this.Btn_verificar.UseVisualStyleBackColor = true;
            this.Btn_verificar.Click += new System.EventHandler(this.button2_Click);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.AutoSize = true;
            this.Lbl_Msg.Location = new System.Drawing.Point(79, 115);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(65, 13);
            this.Lbl_Msg.TabIndex = 2;
            this.Lbl_Msg.Text = "IT a Integrar";
            // 
            // Tx_It
            // 
            this.Tx_It.Location = new System.Drawing.Point(23, 64);
            this.Tx_It.Name = "Tx_It";
            this.Tx_It.Size = new System.Drawing.Size(76, 20);
            this.Tx_It.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IT a Integrar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Lbl_Avance);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Location = new System.Drawing.Point(503, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 103);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Avance del Proceso";
            // 
            // Lbl_Avance
            // 
            this.Lbl_Avance.AutoSize = true;
            this.Lbl_Avance.Location = new System.Drawing.Point(12, 59);
            this.Lbl_Avance.Name = "Lbl_Avance";
            this.Lbl_Avance.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Avance.TabIndex = 7;
            this.Lbl_Avance.Text = "label2";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(278, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // Btn_Redondea
            // 
            this.Btn_Redondea.Location = new System.Drawing.Point(519, 239);
            this.Btn_Redondea.Name = "Btn_Redondea";
            this.Btn_Redondea.Size = new System.Drawing.Size(71, 27);
            this.Btn_Redondea.TabIndex = 7;
            this.Btn_Redondea.Text = "Redondea";
            this.Btn_Redondea.UseVisualStyleBackColor = true;
            this.Btn_Redondea.Click += new System.EventHandler(this.Btn_Redondea_Click);
            // 
            // Lbl_Resultado
            // 
            this.Lbl_Resultado.AutoSize = true;
            this.Lbl_Resultado.Location = new System.Drawing.Point(629, 246);
            this.Lbl_Resultado.Name = "Lbl_Resultado";
            this.Lbl_Resultado.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Resultado.TabIndex = 8;
            this.Lbl_Resultado.Text = "label2";
            // 
            // Tx_IdSucursal
            // 
            this.Tx_IdSucursal.Location = new System.Drawing.Point(669, 92);
            this.Tx_IdSucursal.Name = "Tx_IdSucursal";
            this.Tx_IdSucursal.Size = new System.Drawing.Size(46, 20);
            this.Tx_IdSucursal.TabIndex = 10;
            this.Tx_IdSucursal.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(663, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Id Sucursal";
            // 
            // Frm_BodegaPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.Tx_IdSucursal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lbl_Resultado);
            this.Controls.Add(this.Btn_Redondea);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_ObtenerObj);
            this.Controls.Add(this.dtg_datos);
            this.Controls.Add(this.Btn_CargaDatos);
            this.Controls.Add(this.button1);
            this.Name = "Frm_BodegaPT";
            this.Text = "Frm_BodegaPT";
            this.Load += new System.EventHandler(this.Frm_BodegaPT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_datos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_CargaDatos;
        private System.Windows.Forms.DataGridView dtg_datos;
        private System.Windows.Forms.Button Btn_ObtenerObj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_verificar;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.TextBox Tx_It;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_IntegrarSaldo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Lbl_Avance;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Btn_Redondea;
        private System.Windows.Forms.Label Lbl_Resultado;
        private System.Windows.Forms.TextBox Tx_IdSucursal;
        private System.Windows.Forms.Label label2;
    }
}