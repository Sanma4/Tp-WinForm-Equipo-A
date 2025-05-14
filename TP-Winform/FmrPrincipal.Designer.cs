namespace TP_Winform
{
    partial class FmrPrincipal
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarArticuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditarUnArticuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarUnArticuloToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNomrbeProducto = new System.Windows.Forms.Label();
            this.lblCodigoArticulo = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnCargarDatos = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarArticuloToolStripMenuItem,
            this.EditarUnArticuloToolStripMenuItem,
            this.eliminarUnArticuloToolStripMenuItem1});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.opcionesToolStripMenuItem.Text = "opciones";
            // 
            // agregarArticuloToolStripMenuItem
            // 
            this.agregarArticuloToolStripMenuItem.Name = "agregarArticuloToolStripMenuItem";
            this.agregarArticuloToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarArticuloToolStripMenuItem.Text = "Agregar Articulo";
            this.agregarArticuloToolStripMenuItem.Click += new System.EventHandler(this.agregarArticuloToolStripMenuItem_Click);
            // 
            // EditarUnArticuloToolStripMenuItem
            // 
            this.EditarUnArticuloToolStripMenuItem.Name = "EditarUnArticuloToolStripMenuItem";
            this.EditarUnArticuloToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.EditarUnArticuloToolStripMenuItem.Text = "Editar un Articulo";
            this.EditarUnArticuloToolStripMenuItem.Click += new System.EventHandler(this.EditarUnArticuloToolStripMenuItem_Click);
            // 
            // eliminarUnArticuloToolStripMenuItem1
            // 
            this.eliminarUnArticuloToolStripMenuItem1.Name = "eliminarUnArticuloToolStripMenuItem1";
            this.eliminarUnArticuloToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.eliminarUnArticuloToolStripMenuItem1.Text = "Eliminar un Articulo";
            this.eliminarUnArticuloToolStripMenuItem1.Click += new System.EventHandler(this.eliminarUnArticuloToolStripMenuItem1_Click);
            // 
            // lblNomrbeProducto
            // 
            this.lblNomrbeProducto.AutoSize = true;
            this.lblNomrbeProducto.Location = new System.Drawing.Point(94, 122);
            this.lblNomrbeProducto.Name = "lblNomrbeProducto";
            this.lblNomrbeProducto.Size = new System.Drawing.Size(85, 13);
            this.lblNomrbeProducto.TabIndex = 3;
            this.lblNomrbeProducto.Text = "ingrese el nobre:";
            // 
            // lblCodigoArticulo
            // 
            this.lblCodigoArticulo.AutoSize = true;
            this.lblCodigoArticulo.Location = new System.Drawing.Point(94, 90);
            this.lblCodigoArticulo.Name = "lblCodigoArticulo";
            this.lblCodigoArticulo.Size = new System.Drawing.Size(144, 13);
            this.lblCodigoArticulo.TabIndex = 4;
            this.lblCodigoArticulo.Text = "ingrese el codigo del articulo:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.Text = "notifyIcon2";
            this.notifyIcon2.Visible = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(284, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(284, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            // 
            // btnCargarDatos
            // 
            this.btnCargarDatos.Location = new System.Drawing.Point(442, 289);
            this.btnCargarDatos.Name = "btnCargarDatos";
            this.btnCargarDatos.Size = new System.Drawing.Size(75, 23);
            this.btnCargarDatos.TabIndex = 8;
            this.btnCargarDatos.Text = "Cargar datos";
            this.btnCargarDatos.UseVisualStyleBackColor = true;
            this.btnCargarDatos.Click += new System.EventHandler(this.btnCargarDatos_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(284, 175);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(284, 231);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 10;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(97, 182);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(87, 13);
            this.lblMarca.TabIndex = 11;
            this.lblMarca.Text = "ingrese la marca:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(97, 234);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(103, 13);
            this.lblCategoria.TabIndex = 12;
            this.lblCategoria.Text = "ingrese la Categoria:";
            // 
            // FmrPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnCargarDatos);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblCodigoArticulo);
            this.Controls.Add(this.lblNomrbeProducto);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FmrPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmrPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarArticuloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditarUnArticuloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarUnArticuloToolStripMenuItem1;
        private System.Windows.Forms.Label lblNomrbeProducto;
        private System.Windows.Forms.Label lblCodigoArticulo;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnCargarDatos;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCategoria;
    }
}