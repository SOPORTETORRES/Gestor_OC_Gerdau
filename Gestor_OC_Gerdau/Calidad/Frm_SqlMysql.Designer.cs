namespace Gestor_OC_Gerdau.Calidad
{
    partial class Frm_SqlMysql
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
            this.Dtg_Res = new System.Windows.Forms.DataGridView();
            this.Tx_sql = new System.Windows.Forms.TextBox();
            this.Btn_ejecuta = new System.Windows.Forms.Button();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Res)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Lbl_Msg);
            this.groupBox1.Controls.Add(this.Dtg_Res);
            this.groupBox1.Location = new System.Drawing.Point(5, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(863, 304);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultado";
            // 
            // Dtg_Res
            // 
            this.Dtg_Res.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Res.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Res.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Res.Name = "Dtg_Res";
            this.Dtg_Res.Size = new System.Drawing.Size(857, 285);
            this.Dtg_Res.TabIndex = 0;
            // 
            // Tx_sql
            // 
            this.Tx_sql.Location = new System.Drawing.Point(7, 6);
            this.Tx_sql.Multiline = true;
            this.Tx_sql.Name = "Tx_sql";
            this.Tx_sql.Size = new System.Drawing.Size(762, 104);
            this.Tx_sql.TabIndex = 1;
            this.Tx_sql.Text = "select * from lotes where length(respuesta)<200 and length(respuesta)>9";
            // 
            // Btn_ejecuta
            // 
            this.Btn_ejecuta.Location = new System.Drawing.Point(775, 12);
            this.Btn_ejecuta.Name = "Btn_ejecuta";
            this.Btn_ejecuta.Size = new System.Drawing.Size(75, 49);
            this.Btn_ejecuta.TabIndex = 2;
            this.Btn_ejecuta.Text = "Ejecuta";
            this.Btn_ejecuta.UseVisualStyleBackColor = true;
            this.Btn_ejecuta.Click += new System.EventHandler(this.Btn_ejecuta_Click);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Msg.Location = new System.Drawing.Point(60, 29);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(756, 260);
            this.Lbl_Msg.TabIndex = 1;
            this.Lbl_Msg.Text = "label1";
            this.Lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lbl_Msg.Visible = false;
            // 
            // Frm_SqlMysql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 425);
            this.Controls.Add(this.Btn_ejecuta);
            this.Controls.Add(this.Tx_sql);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_SqlMysql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_SqlMysql";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Res)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.DataGridView Dtg_Res;
        private System.Windows.Forms.TextBox Tx_sql;
        private System.Windows.Forms.Button Btn_ejecuta;
    }
}