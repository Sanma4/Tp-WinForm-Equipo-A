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
        private List<Imagen> listaImagen = new List<Imagen>();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public void OcultarColumnas()
        {
            dgvArticulo.Columns["Id"].Visible = false;
            //dgvArticulo.Columns["Imagen"].Visible = false;
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
            ImagenNegocio imagen = new ImagenNegocio();
            try
            {
                listaArticulos = negocio.ListarArticulos();
                listaImagen = imagen.ListarImagenes();
                dgvArticulo.DataSource = listaArticulos;
                CargarImagen(listaImagen[0].Url);
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
                if (seleccionado.Imagen.Count > 0)
                {
                    CargarImagen(seleccionado.Imagen[0].Url);
                }

            }
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;
            if (filtro != "")
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }

            dgvArticulo.DataSource = null; //Seteo la grilla en nada para no duplicar articulos
            dgvArticulo.DataSource = listaFiltrada; //Asigno nuevos datos
            OcultarColumnas();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {

            frmAltaProducto frmAlta = new frmAltaProducto();
            frmAlta.ShowDialog();
            Cargar();


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
            frmAltaProducto frmEdit = new frmAltaProducto(seleccionado);
            frmEdit.ShowDialog();
            Cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                var respuesta = MessageBox.Show("¿Esta seguro de eliminar este Articulo?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta != DialogResult.Yes)
                    return;

                negocio.Eliminar(seleccionado.Id);
                Cargar();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
            frmVerDetalle detalle = new frmVerDetalle(seleccionado);
            detalle.ShowDialog();

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmManejarCategorias manejar = new frmManejarCategorias();
            manejar.ShowDialog();
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            frmManejarMarcas manejar = new frmManejarMarcas();
            manejar.ShowDialog();
        }

        private void pbxArticulo_Click(object sender, EventArgs e)
        {
            foreach (var prod in listaArticulos)
            {
                prod.Imagen = listaImagen.FindAll(l => l.IdArticulo == prod.Id);
                if (prod.Imagen != null && prod.Imagen.Count > 0)
                {

                }
            }
        }

        private void pbxArticulo_MouseClick(object sender, MouseEventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;

            foreach (var prod in seleccionado.Imagen.FindAll(l => l.IdArticulo == seleccionado.Id))
            {
               CargarImagen(prod.Url);
            }
        }

        private void btnImagenes_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
            frmManejarImagenes imagenes = new frmManejarImagenes(seleccionado.Id);
            imagenes.ShowDialog();
            Cargar();
        }
    }
}
