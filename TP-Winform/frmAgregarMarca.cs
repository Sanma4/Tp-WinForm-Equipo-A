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
    public partial class frmAgregarMarca : Form
    {
        private Marca marca = null;
        public frmAgregarMarca()
        {
            InitializeComponent();
        }
        public frmAgregarMarca(Marca marca)
        {
            InitializeComponent();
            this.marca = marca;
            Text = "Editar Marca";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                if (marca == null)
                {
                    marca = new Marca();
                    Text = "Agregar marca";
                }

                marca.Descripcion = txtDescripcion.Text;
                if(marca.Id != 0)
                {
                    negocio.Editar(marca);
                    MessageBox.Show("¡Marca editada correctamente!");

                }
                else
                {
                    negocio.Agregar(txtDescripcion.Text);
                    MessageBox.Show("¡Marca agregada correctamente!");
                }
           
                Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmAgregarMarca_Load(object sender, EventArgs e)
        {
            if (marca != null)
            {
                txtDescripcion.Text = marca.Descripcion;
            }
        }
    }
}
