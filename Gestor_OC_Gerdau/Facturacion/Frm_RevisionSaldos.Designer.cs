namespace Gestor_OC_Gerdau.Facturacion
{
    partial class Frm_RevisionSaldos
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
            this.Btn_GeneraArchivoLC = new System.Windows.Forms.Button();
            this.Dtg_Datos = new System.Windows.Forms.DataGridView();
            this.Btn_CargaArchivo = new System.Windows.Forms.Button();
            this.Btn_compara = new System.Windows.Forms.Button();
            this.Dtg_ArcDAni = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Rb_Todos = new System.Windows.Forms.RadioButton();
            this.Rb_OK = new System.Windows.Forms.RadioButton();
            this.Rb_NOOK = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_ArcDAni)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_GeneraArchivoLC
            // 
            this.Btn_GeneraArchivoLC.Location = new System.Drawing.Point(13, 3);
            this.Btn_GeneraArchivoLC.Name = "Btn_GeneraArchivoLC";
            this.Btn_GeneraArchivoLC.Size = new System.Drawing.Size(115, 23);
            this.Btn_GeneraArchivoLC.TabIndex = 0;
            this.Btn_GeneraArchivoLC.Text = "Carga  Informe LC";
            this.Btn_GeneraArchivoLC.UseVisualStyleBackColor = true;
            this.Btn_GeneraArchivoLC.Click += new System.EventHandler(this.Btn_GeneraArchivoLC_Click);
            // 
            // Dtg_Datos
            // 
            this.Dtg_Datos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_Datos.Location = new System.Drawing.Point(13, 41);
            this.Dtg_Datos.Name = "Dtg_Datos";
            this.Dtg_Datos.Size = new System.Drawing.Size(622, 468);
            this.Dtg_Datos.TabIndex = 1;
            // 
            // Btn_CargaArchivo
            // 
            this.Btn_CargaArchivo.Location = new System.Drawing.Point(226, 3);
            this.Btn_CargaArchivo.Name = "Btn_CargaArchivo";
            this.Btn_CargaArchivo.Size = new System.Drawing.Size(115, 23);
            this.Btn_CargaArchivo.TabIndex = 2;
            this.Btn_CargaArchivo.Text = "Carga  archivo DANI";
            this.Btn_CargaArchivo.UseVisualStyleBackColor = true;
            this.Btn_CargaArchivo.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_compara
            // 
            this.Btn_compara.Location = new System.Drawing.Point(401, 3);
            this.Btn_compara.Name = "Btn_compara";
            this.Btn_compara.Size = new System.Drawing.Size(115, 23);
            this.Btn_compara.TabIndex = 3;
            this.Btn_compara.Text = "Comparar";
            this.Btn_compara.UseVisualStyleBackColor = true;
            this.Btn_compara.Click += new System.EventHandler(this.button2_Click);
            // 
            // Dtg_ArcDAni
            // 
            this.Dtg_ArcDAni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtg_ArcDAni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dtg_ArcDAni.Location = new System.Drawing.Point(641, 41);
            this.Dtg_ArcDAni.Name = "Dtg_ArcDAni";
            this.Dtg_ArcDAni.Size = new System.Drawing.Size(416, 468);
            this.Dtg_ArcDAni.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(595, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Ver Resultados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Rb_Todos
            // 
            this.Rb_Todos.AutoSize = true;
            this.Rb_Todos.Checked = true;
            this.Rb_Todos.Location = new System.Drawing.Point(716, 9);
            this.Rb_Todos.Name = "Rb_Todos";
            this.Rb_Todos.Size = new System.Drawing.Size(55, 17);
            this.Rb_Todos.TabIndex = 6;
            this.Rb_Todos.TabStop = true;
            this.Rb_Todos.Text = "Todos";
            this.Rb_Todos.UseVisualStyleBackColor = true;
            this.Rb_Todos.Visible = false;
            // 
            // Rb_OK
            // 
            this.Rb_OK.AutoSize = true;
            this.Rb_OK.Location = new System.Drawing.Point(777, 9);
            this.Rb_OK.Name = "Rb_OK";
            this.Rb_OK.Size = new System.Drawing.Size(64, 17);
            this.Rb_OK.TabIndex = 7;
            this.Rb_OK.Text = "Solo OK";
            this.Rb_OK.UseVisualStyleBackColor = true;
            this.Rb_OK.Visible = false;
            // 
            // Rb_NOOK
            // 
            this.Rb_NOOK.AutoSize = true;
            this.Rb_NOOK.Location = new System.Drawing.Point(861, 9);
            this.Rb_NOOK.Name = "Rb_NOOK";
            this.Rb_NOOK.Size = new System.Drawing.Size(59, 17);
            this.Rb_NOOK.TabIndex = 8;
            this.Rb_NOOK.Text = "NO OK";
            this.Rb_NOOK.UseVisualStyleBackColor = true;
            this.Rb_NOOK.Visible = false;
            // 
            // Frm_RevisionSaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 521);
            this.Controls.Add(this.Rb_NOOK);
            this.Controls.Add(this.Rb_OK);
            this.Controls.Add(this.Rb_Todos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Dtg_ArcDAni);
            this.Controls.Add(this.Btn_compara);
            this.Controls.Add(this.Btn_CargaArchivo);
            this.Controls.Add(this.Dtg_Datos);
            this.Controls.Add(this.Btn_GeneraArchivoLC);
            this.Name = "Frm_RevisionSaldos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Revisión de Saldos";
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dtg_ArcDAni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_GeneraArchivoLC;
        private System.Windows.Forms.DataGridView Dtg_Datos;
        private System.Windows.Forms.Button Btn_CargaArchivo;
        private System.Windows.Forms.Button Btn_compara;
        private System.Windows.Forms.DataGridView Dtg_ArcDAni;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton Rb_Todos;
        private System.Windows.Forms.RadioButton Rb_OK;
        private System.Windows.Forms.RadioButton Rb_NOOK;
    }
}