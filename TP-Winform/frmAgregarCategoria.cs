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
    public partial class frmAgregarCategoria : Form
    {
        private Categoria categoria = null;
        public frmAgregarCategoria()
        {
            InitializeComponent();
        }
        public frmAgregarCategoria(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
            Text = "Editar categoría";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                    Text = "Agregar categoría";
                }
                categoria.Descripcion = txtDescripcion.Text;

                if (categoria.Id != 0)
                {
                    negocio.Editar(categoria);
                    MessageBox.Show("¡Categoría editada correctamente!");

                }
                else
                {
                    negocio.Agregar(txtDescripcion.Text);
                    MessageBox.Show("¡Categoría agregada correctamente!");
                }


                Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void frmAgregarCategoria_Load(object sender, EventArgs e)
        {

            if (categoria != null)
            {
                txtDescripcion.Text = categoria.Descripcion;
            }
        }
    }
}
