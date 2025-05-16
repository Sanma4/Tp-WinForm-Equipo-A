using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Winform
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void agregarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaProducto vtnAticulo = new frmAltaProducto();
            vtnAticulo.ShowDialog();
        }

        private void EditarUnArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaProducto alta = new frmAltaProducto();
            alta.ShowDialog();
        }

        private void eliminarUnArticuloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEliminar vtnEliminar = new frmEliminar();
            vtnEliminar.ShowDialog();
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            frmResultado vtnResultado = new frmResultado();
            vtnResultado.ShowDialog();
        }


    }
}
