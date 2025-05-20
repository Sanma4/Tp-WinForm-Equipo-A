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
                    txtId.Text = _articulo.Id.ToString();
                    txtCodigo.Text = _articulo.Codigo ;
                    txtNombre.Text = _articulo.Nombre;
                    txtDescripcion.Text = _articulo.Descripcion;
                    cboMarca.SelectedValue = _articulo.Marca.Id;
                    cboCategoria.SelectedValue = _articulo.Categoria.Id;
                    txtPrecio.Text = _articulo.Precio.ToString();
                    
                    
                    foreach (var control in new Control[]{ txtCodigo, txtNombre, txtDescripcion,txtId, txtPrecio})
                    {
                        ((TextBox)control).ReadOnly = true;
                    }

                    cboMarca.Enabled = false;
                    cboCategoria.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

