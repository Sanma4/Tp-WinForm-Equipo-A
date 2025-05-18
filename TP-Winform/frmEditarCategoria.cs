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
    public partial class frmEditarCategoria : Form
    {
        private Categoria _categoria;
        public frmEditarCategoria()
        {
            InitializeComponent();
        }
        public frmEditarCategoria(Categoria categoria)
        {
            InitializeComponent();
            _categoria = categoria;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                negocio.Editar(_categoria);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void frmEditarCategoria_Load(object sender, EventArgs e)
        {
            txtDescripcion.Text = _categoria.Descripcion;
        }
    }
}
