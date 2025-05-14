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
    public partial class FmrPrincipal : Form
    {
        public FmrPrincipal()
        {
            InitializeComponent();
        }

        private void agregarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            From1 vtnAticulo = new From1();
            vtnAticulo.ShowDialog();
        }

        private void EditarUnArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 vtnEditar = new Form2();
            vtnEditar.ShowDialog();
        }

        private void eliminarUnArticuloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 vtnEliminar = new Form3();
            vtnEliminar.ShowDialog();
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            frmResultado vtnResultado = new frmResultado();
            vtnResultado.ShowDialog();
        }
    }
}
