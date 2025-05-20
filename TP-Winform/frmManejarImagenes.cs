using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            List<Imagen> lista = negocio.ListarImagenesId(Id);
            dgvImagenes.DataSource = lista;
            CargarImagen(lista[0].Url);
        }
        private void CargarImagen(string url)
        {
            try
            {
                pbxImagenes.Load(url);
            }
            catch (Exception ex)
            {

                pbxImagenes.Load("https://media.istockphoto.com/id/1409329028/es/vector/no-hay-imagen-disponible-marcador-de-posici%C3%B3n-miniatura-icono-dise%C3%B1o-de-ilustraci%C3%B3n.jpg?s=612x612&w=0&k=20&c=Bd89b8CBr-IXx9mBbTidc-wu_gtIj8Py_EMr3hGGaPw=");
            }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Imagen seleccionado = (Imagen)dgvImagenes.CurrentRow.DataBoundItem;
            ImagenNegocio negocio = new ImagenNegocio();
            try
            {
                negocio.Eliminar(Id);
                MessageBox.Show("¿Esta seguro que quiere eliminar la imagen?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                Cargar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgvImagenes_SelectionChanged(object sender, EventArgs e)
        {
            Imagen seleccionado = (Imagen)dgvImagenes.CurrentRow.DataBoundItem;
            CargarImagen(seleccionado.Url);
        }
    }
}
