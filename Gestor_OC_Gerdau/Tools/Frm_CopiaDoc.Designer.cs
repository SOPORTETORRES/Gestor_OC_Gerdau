namespace Gestor_OC_Gerdau.Tools
{
    partial class Frm_CopiaDoc
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
            this.Btn_RevisaInfo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dtg_Resultado = new System.Windows.Forms.DataGridView();
            this.Btn_Procesar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_RevisaInfo
            // 
            this.Btn_RevisaInfo.Location = new System.Drawing.Point(116, 25);
            this.Btn_RevisaInfo.Name = "Btn_RevisaInfo";
            this.Btn_RevisaInfo.Size = new System.Drawing.Size(184, 23);
            this.Btn_RevisaInfo.TabIndex = 0;
            this.Btn_RevisaInfo.Text = "Revisa Informacion";
            this.Btn_RevisaInfo.UseVisualStyleBackColor = true;
            this.Btn_RevisaInfo.Click += new System.EventHandler(this.Btn_RevisaInfo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Dtg_Resultado);
            this.groupBox1.Location = new System.Drawing.Point(6, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 655);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultado";
            // 
            // Dtg_Resultado
            // 
            this.Dtg_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Resultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dtg_Resultado.Location = new System.Drawing.Point(3, 16);
            this.Dtg_Resultado.Name = "Dtg_Resultado";
            this.Dtg_Resultado.Size = new System.Drawing.Size(741, 636);
            this.Dtg_Resultado.TabIndex = 0;
            // 
            // Btn_Procesar
            // 
            this.Btn_Procesar.Location = new System.Drawing.Point(529, 25);
            this.Btn_Procesar.Name = "Btn_Procesar";
            this.Btn_Procesar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Procesar.TabIndex = 2;
            this.Btn_Procesar.Text = "Procesar";
            this.Btn_Procesar.UseVisualStyleBackColor = true;
            this.Btn_Procesar.Click += new System.EventHandler(this.Btn_Procesar_Click);
            // 
            // Frm_CopiaDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 751);
            this.Controls.Add(this.Btn_Procesar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_RevisaInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CopiaDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de revision de documentos automaticos";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Resultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_RevisaInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dtg_Resultado;
        private System.Windows.Forms.Button Btn_Procesar;
    }
}