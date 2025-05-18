using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> ListarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio, M.Descripcion Marca, C.Descripcion Categoria, I.ImagenUrl, I.Id, I.IdArticulo from ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I where C.Id = A.IdCategoria and M.Id = A.IdMarca AND I.IdArticulo = A.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int IdArticulo = (int)datos.Lector["Id"];
                    Articulo existente = lista.FirstOrDefault(a => a.Id == IdArticulo);
                    if (existente == null)
                    {

                        Articulo aux = new Articulo();
                        aux.Id = (int)datos.Lector["Id"];
                        aux.Codigo = (string)datos.Lector["Codigo"];
                        aux.Nombre = (string)datos.Lector["Nombre"];
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                        aux.Precio = (decimal)datos.Lector["Precio"];
                        aux.Marca = new Marca();
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                        aux.Marca.Descripcion = (string)datos.Lector["Categoria"];
                        aux.Categoria = new Categoria();
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        aux.Imagen = new List<Imagen>();
                        if (!(datos.Lector["ImagenUrl"] is DBNull))
                        {
                            Imagen img = new Imagen();
                            img.Id = (int)datos.Lector["Id"];
                            img.Url = (string)datos.Lector["ImagenUrl"];
                            img.IdArticulo = (int)datos.Lector["IdArticulo"];
                            aux.Imagen.Add(img);
                            lista.Add(aux);

                        }
                        else
                        {
                            if (!(datos.Lector["ImagenUrl"] is DBNull))
                            {
                                Imagen img = new Imagen();
                                img.Id = (int)datos.Lector["Id"];
                                img.Url = (string)datos.Lector["ImagenUrl"];
                                img.IdArticulo = (int)datos.Lector["IdArticulo"];
                                existente.Imagen.Add(img);
                            }
                        }

                    }


                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
