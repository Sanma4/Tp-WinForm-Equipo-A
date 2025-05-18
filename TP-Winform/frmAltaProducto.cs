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
using static System.Net.Mime.MediaTypeNames;

namespace TP_Winform
{
    public partial class frmAltaProducto : Form
    {
        private Articulo _articulo;
        public frmAltaProducto()
        {
            InitializeComponent();
        }
        public frmAltaProducto(Articulo articulo)
        {
            InitializeComponent();
            _articulo = articulo;
            Text = "Editar artículo";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MarcaNegocio marca = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();
            try
            {

                cboMarca.DataSource = marca.ListarMarcas();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource = categoria.ListarCategorias();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                if (_articulo != null)
                {
                    txtCodigo.Text = _articulo.Codigo;
                    txtNombre.Text = _articulo.Nombre;
                    txtDescripcion.Text = _articulo.Descripcion;
                    cboMarca.SelectedValue = _articulo.Marca.Id;
                    cboCategoria.SelectedValue = _articulo.Categoria.Id;
                    txtPrecio.Text = _articulo.Precio.ToString();

                    if (_articulo.Imagen != null && _articulo.Imagen.Count > 0)
                    {
                        txtImagen.Text = _articulo.Imagen[0].Url;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private void txtImagen_TextChanged_1(object sender, EventArgs e)
        {
            CargarImagen(txtImagen.Text);
        }

        private void CargarImagen(string urlImagen)
        {
            try
            {
                pbxAgregarArticulo.Load(urlImagen);
            }
            catch (Exception)
            {
                pbxAgregarArticulo.Load("https://media.istockphoto.com/id/1409329028/es/vector/no-hay-imagen-disponible-marcador-de-posici%C3%B3n-miniatura-icono-dise%C3%B1o-de-ilustraci%C3%B3n.jpg?s=612x612&w=0&k=20&c=Bd89b8CBr-IXx9mBbTidc-wu_gtIj8Py_EMr3hGGaPw=");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (_articulo == null)
                {
                   _articulo = new Articulo();
                    Text = "Agregar artículo";
                }


                _articulo.Nombre = txtNombre.Text;
                _articulo.Descripcion = txtDescripcion.Text;
                _articulo.Codigo = txtCodigo.Text;
                _articulo.Precio = decimal.Parse(txtPrecio.Text);
                _articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                _articulo.Marca = (Marca)cboMarca.SelectedItem;




                if (_articulo.Id != 0)
                {
                    _articulo.Imagen[0].Url = txtImagen.Text;
                    negocio.Modificar(_articulo);
                    MessageBox.Show("¡Artículo modificado correctamente!");
                }
                else
                {
                    _articulo.Imagen.Add(new Imagen
                    {
                        Url = txtImagen.Text
                    });
                    negocio.Agregar(_articulo);
                    MessageBox.Show("¡Artículo agregado correctamente!");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
