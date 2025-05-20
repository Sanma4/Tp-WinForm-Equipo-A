using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TP_Winform
{
    public partial class frmManejarImagenes : Form
    {
        private int Id = 0;
        public frmManejarImagenes()
        {
            InitializeComponent();
        }
        public frmManejarImagenes(int id)
        {
            InitializeComponent();
            Id = id;
        }
        private void Cargar()
        {
            ImagenNegocio negocio = new ImagenNegocio();
            dgvImagenes.DataSource = negocio.ListarImagenesId(Id);
        }
        private void frmManejarImagenes_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarImagen agregar = new frmAgregarImagen(Id);
            agregar.ShowDialog();
            Cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Imagen seleccionado = (Imagen)dgvImagenes.CurrentRow.DataBoundItem;
            frmAgregarImagen editar = new frmAgregarImagen(seleccionado, Id);
            editar.ShowDialog();
            Cargar();
        }
    }
}
