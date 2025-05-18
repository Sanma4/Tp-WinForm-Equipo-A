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
    public partial class frmManejarMarcas : Form
    {
        public frmManejarMarcas()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarMarca agregar = new frmAgregarMarca();
            agregar.ShowDialog();
            Cargar();
        }

        private void frmManejarMarcas_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                dgvMarcas.DataSource = negocio.ListarMarcas();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Marca seleccionado = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
            frmEditarMarca marca = new frmEditarMarca(seleccionado);
            marca.ShowDialog();
        }
    }
}
