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
    public partial class frmManejarCategorias : Form
    {
        public frmManejarCategorias()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarCategoria agregar = new frmAgregarCategoria();
            agregar.ShowDialog();
            Cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Categoria seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            frmAgregarCategoria editar = new frmAgregarCategoria(seleccionado);
            editar.ShowDialog();
            Cargar();
        }

        private void frmManejarCategorias_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                dgvCategorias.DataSource = negocio.ListarMarcas();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
