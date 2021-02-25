namespace Gestor_OC_Gerdau.Calidad
{
    partial class Frm_WB_Ver
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
            this.Wb = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // Wb
            // 
            this.Wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wb.Location = new System.Drawing.Point(0, 0);
            this.Wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.Wb.Name = "Wb";
            this.Wb.Size = new System.Drawing.Size(905, 487);
            this.Wb.TabIndex = 2;
            // 
            // Frm_WB_Ver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 487);
            this.Controls.Add(this.Wb);
            this.Name = "Frm_WB_Ver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Visualizacion de Lotes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser Wb;
    }
}