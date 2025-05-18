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
    public partial class frmVerDetalle : Form
    {
        private Articulo _articulo;

        public frmVerDetalle()
        {
            InitializeComponent();
        }
        public frmVerDetalle(Articulo articulo)
        {
            InitializeComponent();
            _articulo = articulo;
            Text = "Detalle";
        }

        private void frmVerDetalle_Load(object sender, EventArgs e)
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
                    txtCodigo.Text = _articulo.Codigo ;
                    txtNombre.Text = _articulo.Nombre;
                    txtDescripcion.Text = _articulo.Descripcion;
                    cboMarca.SelectedValue = _articulo.Marca.Id;
                    cboCategoria.SelectedValue = _articulo.Categoria.Id;
                    txtPrecio.Text = _articulo.Precio.ToString();
                    
                    foreach (var control in new Control[]{ txtCodigo, txtNombre, txtDescripcion, txtImagen, txtPrecio})
                    {
                        ((TextBox)control).ReadOnly = true;
                    }

                    cboMarca.Enabled = false;
                    cboCategoria.Enabled = false;
                    if (_articulo.Imagen != null && _articulo.Imagen.Count > 0)
                    {
                        txtImagen.Text = _articulo.Imagen[0].Url;
                    }
                    CargarImagen(txtImagen.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarImagen(string url)
        {
            try
            {
                pbxAgregarArticulo.Load(url);
            }
            catch (Exception )
            {
                pbxAgregarArticulo.Load("https://media.istockphoto.com/id/1409329028/es/vector/no-hay-imagen-disponible-marcador-de-posici%C3%B3n-miniatura-icono-dise%C3%B1o-de-ilustraci%C3%B3n.jpg?s=612x612&w=0&k=20&c=Bd89b8CBr-IXx9mBbTidc-wu_gtIj8Py_EMr3hGGaPw=");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

