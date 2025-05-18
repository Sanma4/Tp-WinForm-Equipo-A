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
    public partial class frmEditarMarca : Form
    {
        private Marca _marca;
        public frmEditarMarca()
        {
            InitializeComponent();
        }
        public frmEditarMarca(Marca marca)
        {
            InitializeComponent();
            _marca = marca;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                negocio.Editar(_marca);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmEditarMarca_Load(object sender, EventArgs e)
        {
            txtDescripcion.Text = _marca.Descripcion;
        }
    }
}
