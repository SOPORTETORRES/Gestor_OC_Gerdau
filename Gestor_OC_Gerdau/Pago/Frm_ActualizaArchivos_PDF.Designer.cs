namespace Gestor_OC_Gerdau.Pago
{
    partial class Frm_ActualizaArchivos_PDF
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
            this.label2 = new System.Windows.Forms.Label();
            this.Tx_PathOrigen = new System.Windows.Forms.TextBox();
            this.Tx_PathDestino = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Btn_Inicia = new System.Windows.Forms.Button();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path Origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Path Destino";
            // 
            // Tx_PathOrigen
            // 
            this.Tx_PathOrigen.Location = new System.Drawing.Point(137, 13);
            this.Tx_PathOrigen.Name = "Tx_PathOrigen";
            this.Tx_PathOrigen.Size = new System.Drawing.Size(409, 20);
            this.Tx_PathOrigen.TabIndex = 2;
            // 
            // Tx_PathDestino
            // 
            this.Tx_PathDestino.Location = new System.Drawing.Point(137, 43);
            this.Tx_PathDestino.Name = "Tx_PathDestino";
            this.Tx_PathDestino.Size = new System.Drawing.Size(409, 20);
            this.Tx_PathDestino.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(7, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 314);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archivos no Actualizados";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(790, 295);
            this.dataGridView1.TabIndex = 0;
            // 
            // Btn_Inicia
            // 
            this.Btn_Inicia.Location = new System.Drawing.Point(681, 24);
            this.Btn_Inicia.Name = "Btn_Inicia";
            this.Btn_Inicia.Size = new System.Drawing.Size(84, 35);
            this.Btn_Inicia.TabIndex = 5;
            this.Btn_Inicia.Text = "Inicia Proceso";
            this.Btn_Inicia.UseVisualStyleBackColor = true;
            this.Btn_Inicia.Click += new System.EventHandler(this.Btn_Inicia_Click);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Msg.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Msg.Location = new System.Drawing.Point(12, 91);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(753, 75);
            this.Lbl_Msg.TabIndex = 6;
            this.Lbl_Msg.Text = "Path Destino";
            this.Lbl_Msg.Click += new System.EventHandler(this.Lbl_Msg_Click);
            // 
            // Frm_ActualizaArchivos_PDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 518);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.Btn_Inicia);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Tx_PathDestino);
            this.Controls.Add(this.Tx_PathOrigen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_ActualizaArchivos_PDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de aActualización de Archivos PDF, Módulo Comercial";
            this.Load += new System.EventHandler(this.Frm_ActualizaArchivos_PDF_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tx_PathOrigen;
        private System.Windows.Forms.TextBox Tx_PathDestino;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Btn_Inicia;
        private System.Windows.Forms.Label Lbl_Msg;
    }
}