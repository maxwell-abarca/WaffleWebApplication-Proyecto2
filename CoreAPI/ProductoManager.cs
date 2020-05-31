using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;
using Entities;
using Exceptions;

namespace CoreAPI
{
    public class ProductoManager : BaseManager
    {
        private ProductoCrudFactory crudProducto;
        private BitacoraCrudFactory crudBitacora;

        public ProductoManager()
        {
            crudProducto = new ProductoCrudFactory();
            crudBitacora = new BitacoraCrudFactory();
        }
        public void Create(Producto producto)
        {
            try
            {
                //var c = crudProducto.Retrieve<Producto>(producto);

                //if (c != null)
                //{
                //    //Id ya existe.
                //    throw new BussinessException(3);
                //}
                //else
                //{
                    crudProducto.Create(producto);
                    Bitacora bitacora = new Bitacora();
                    bitacora.Usuario = "Comercio";
                    bitacora.Accion = "Registro de un producto";
                    bitacora.FechaAccion = DateTime.Now;
                    crudBitacora.Create(bitacora);
                //}
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

        }
        public List<Producto> RetrieveAll()
        {
            return crudProducto.RetrieveAll<Producto>();
        }

        public Producto RetrieveById(Producto producto)
        {
            Producto p = null;
            try
            {
                p = crudProducto.Retrieve<Producto>(producto);
                if (p == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return p;
        }



        public void Update(Producto producto)
        {
            crudProducto.Update(producto);
            Bitacora bitacora = new Bitacora();
            bitacora.Usuario = "Comercio";
            bitacora.Accion = "Modificación de un producto";
            bitacora.FechaAccion = DateTime.Now;
            crudBitacora.Create(bitacora);
        }

        public void Delete(Producto producto)
        {
            crudProducto.Delete(producto);
            Bitacora bitacora = new Bitacora();
            bitacora.Usuario = "comercio";
            bitacora.Accion = "Eliminación de un producto";
            bitacora.FechaAccion = DateTime.Now;
            crudBitacora.Create(bitacora);
        }
        public List<Producto> GetProductosComercio(Producto producto)
        {
            var lstProductos = new List<Producto>();
            try
            {
                lstProductos = crudProducto.GetProductosComercio<Producto>(producto);
                if (lstProductos == null)
                {
                    /*Aún no existen transportistas*/
                    throw new BussinessException(7);
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return lstProductos;
        }
    }
}
