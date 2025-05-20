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
                datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio, M.Descripcion Marca, C.Descripcion Categoria, I.ImagenUrl, I.Id IdImagen, I.IdArticulo from ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I where C.Id = A.IdCategoria and M.Id = A.IdMarca AND I.IdArticulo = A.Id");
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
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                        aux.Categoria = new Categoria();
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        aux.Imagen = new List<Imagen>();
                        if (!(datos.Lector["ImagenUrl"] is DBNull))
                        {
                            Imagen img = new Imagen
                            {
                                Id = (int)datos.Lector["IdImagen"],
                                Url = (string)datos.Lector["ImagenUrl"],
                                IdArticulo = (int)datos.Lector["IdArticulo"]

                            };
                            aux.Imagen.Add(img);
                        }
                        lista.Add(aux);

                    }
                    else
                    {
                        if (!(datos.Lector["ImagenUrl"] is DBNull))
                        {
                            Imagen img = new Imagen
                            {
                                Id = (int)datos.Lector["IdImagen"],
                                Url = (string)datos.Lector["ImagenUrl"]
                            };
                            existente.Imagen.Add(img);
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
        public void Agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Articulos values(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio); " + "Select SCOPE_IDENTITY()");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@Precio", articulo.Precio);

                articulo.Id = Convert.ToInt32(datos.ejecutarScalar());

                datos.cerrarConexion();

                foreach (var img in articulo.Imagen)
                {
                    AccesoDatos datosImg = new AccesoDatos();

                    datosImg.setearConsulta("INSERT INTO IMAGENES VALUES (@IdArticulo, @Url)");
                    datosImg.setearParametro("@IdArticulo", articulo.Id);
                    datosImg.setearParametro("@Url", img.Url);

                    datosImg.ejecutarAccion();
                }

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

        public void Modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Articulos set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio where Id = @Id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@Id", articulo.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            if (articulo.Imagen != null && articulo.Imagen.Count > 0)
            {

                AccesoDatos datosImg = new AccesoDatos();
                try
                {
                    datosImg.setearConsulta("Update Imagenes set ImagenUrl = @Url where Id = @Id");
                    datosImg.setearParametro("@Url", articulo.Imagen[0].Url);
                    datosImg.setearParametro("@Id", articulo.Imagen[0].Id);

                    datosImg.ejecutarAccion();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    datosImg.cerrarConexion();
                }

            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete from Articulos where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();

                
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            AccesoDatos datosImg = new AccesoDatos();
            try
            {
                datosImg.setearConsulta("Delete from Imagenes where IdArticulo = @Id");
                datosImg.setearParametro("@Id", id);
                datosImg.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datosImg.cerrarConexion();
            }
        }
    }
}
