namespace TP_Winform
{
    partial class frmAgregarImagen
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
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrlImagen = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pbxImagenes = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 110);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(61, 13);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "Url Imagen:";
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(88, 107);
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(175, 20);
            this.txtUrlImagen.TabIndex = 1;
            this.txtUrlImagen.TextChanged += new System.EventHandler(this.txtUrlImagen_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(88, 239);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(101, 39);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Aceptar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pbxImagenes
            // 
            this.pbxImagenes.Location = new System.Drawing.Point(299, 22);
            this.pbxImagenes.Name = "pbxImagenes";
            this.pbxImagenes.Size = new System.Drawing.Size(377, 316);
            this.pbxImagenes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagenes.TabIndex = 3;
            this.pbxImagenes.TabStop = false;
            // 
            // frmAgregarImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 375);
            this.Controls.Add(this.pbxImagenes);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtUrlImagen);
            this.Controls.Add(this.lblUrl);
            this.Name = "frmAgregarImagen";
            this.Text = "Agregar Imagen";
            this.Load += new System.EventHandler(this.frmAgregarImagen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrlImagen;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.PictureBox pbxImagenes;
    }
}