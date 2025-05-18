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
        private List<Image> UrlImagenes = new List<Image>();
        private int IndexImagen = 0;
        private List<Articulo> listaArticulos;
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
        public void CargarImagen(List<Imagen> imagenes)
        {
            UrlImagenes.Clear();
            IndexImagen = 0;
            foreach (var img in imagenes)
            {

                try
                {
                    Image imagen = Image.FromStream(System.Net.WebRequest.Create(img.Url).GetResponse().GetResponseStream());
                    UrlImagenes.Add(imagen);
                }
                catch (Exception ex)
                {
                    Image defaultImagen = Image.FromStream(System.Net.WebRequest.Create("https://media.istockphoto.com/id/1409329028/es/vector/no-hay-imagen-disponible-marcador-de-posici%C3%B3n-miniatura-icono-dise%C3%B1o-de-ilustraci%C3%B3n.jpg?s=612x612&w=0&k=20&c=Bd89b8CBr-IXx9mBbTidc-wu_gtIj8Py_EMr3hGGaPw=").GetResponse().GetResponseStream());
                    UrlImagenes.Add(defaultImagen);
                }
            }

            if (UrlImagenes.Count > 0)
            {
                pbxArticulo.Image = UrlImagenes[0];
            }
            else
            {
               pbxArticulo.Image = Image.FromStream(System.Net.WebRequest.Create("https://media.istockphoto.com/id/1409329028/es/vector/no-hay-imagen-disponible-marcador-de-posici%C3%B3n-miniatura-icono-dise%C3%B1o-de-ilustraci%C3%B3n.jpg?s=612x612&w=0&k=20&c=Bd89b8CBr-IXx9mBbTidc-wu_gtIj8Py_EMr3hGGaPw=").GetResponse().GetResponseStream());
            }

        }
        public void Cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ImagenNegocio imagen = new ImagenNegocio();
            try
            {
                listaArticulos = negocio.ListarArticulos();
                List<Imagen> listaImagen = imagen.ListarImagenes();
                dgvArticulo.DataSource = listaArticulos;
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
                CargarImagen(seleccionado.Imagen);

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

        private void pbxArticulo_Click(object sender, EventArgs e)
        {
            if (UrlImagenes.Count <= 1)
                return;

            IndexImagen++;
            if (IndexImagen >= UrlImagenes.Count)
                IndexImagen = 0;

            pbxArticulo.Image = UrlImagenes[IndexImagen];
        }
    }
}
