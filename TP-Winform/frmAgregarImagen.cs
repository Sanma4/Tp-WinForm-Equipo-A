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
    public partial class frmAgregarImagen : Form
    {
        private Imagen imagen = null;
        private int IdArticulo;
        public frmAgregarImagen(int IdArticulo)
        {
            InitializeComponent();
            this.IdArticulo = IdArticulo;
        }
        public frmAgregarImagen(Imagen imagen, int IdArticulo)
        {
            InitializeComponent();
            this.imagen = imagen;
            this.IdArticulo = IdArticulo;
            Text = "Editar Imagen";
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
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (imagen == null)
                imagen = new Imagen();
            ImagenNegocio negocio = new ImagenNegocio();
            try
            {
                imagen.Url = txtUrlImagen.Text;
                imagen.IdArticulo = IdArticulo;

                if (imagen.Id != 0)
                {
                    negocio.Editar(imagen);
                    MessageBox.Show("¡Su imagen ha sido editada correctamente!");
                }
                else
                {
                    negocio.Agregar(imagen);
                    MessageBox.Show("¡Su imagen ha sido agregada correctamente!");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            Close();
        }

        private void frmAgregarImagen_Load(object sender, EventArgs e)
        {
            if (imagen != null)
            {
                txtUrlImagen.Text = imagen.Url;
                CargarImagen(imagen.Url);
            }
        }

        private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            CargarImagen(txtUrlImagen.Text);
        }
    }
}
