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
    public partial class frmPrincipal : Form
    {
        private List<Articulo> listaArticulos;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public void OcultarColumnas()
        {
            dgvArticulo.Columns["Id"].Visible = false;
            dgvArticulo.Columns["Imagen"].Visible = false;
            dgvArticulo.Columns["Codigo"].Visible = false;
        }
        public void CargarImagen(string url)
        {
            try
            {
                pbxArticulo.Load(url);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://media.istockphoto.com/id/1409329028/es/vector/no-hay-imagen-disponible-marcador-de-posici%C3%B3n-miniatura-icono-dise%C3%B1o-de-ilustraci%C3%B3n.jpg?s=612x612&w=0&k=20&c=Bd89b8CBr-IXx9mBbTidc-wu_gtIj8Py_EMr3hGGaPw=");
            }
        }
        public void Cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.ListarArticulos();
                dgvArticulo.DataSource = listaArticulos;
                CargarImagen(listaArticulos[0].Imagen.Url);
                OcultarColumnas();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dgvArticulo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulo.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                CargarImagen(seleccionado.Imagen.Url);
            }
        }
    }
}
