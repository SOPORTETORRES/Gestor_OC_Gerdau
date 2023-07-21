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
            // 
            // Frm_CopiaDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_RevisaInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CopiaDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de revision de documentos automaticos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_RevisaInfo;
    }
}