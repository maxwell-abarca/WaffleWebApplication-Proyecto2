using DataAccess.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class CategoriaManager : BaseManager
    {
        private CategoriaCrudFactory crudCategoria;
        private BitacoraCrudFactory crudBitacora;
        public CategoriaManager()
        {
            crudCategoria = new CategoriaCrudFactory();
            crudBitacora = new BitacoraCrudFactory();
        }

        public void Create(Categoria categoria)
        {
            try
            {
                var c = crudCategoria.Retrieve<Categoria>(categoria);

                if (c != null)
                {
                    //Categoria ya existe.
                    throw new BussinessException(3);
                }
                else
                {
                    crudCategoria.Create(categoria);
                    Bitacora bitacora = new Bitacora();
                    bitacora.Usuario = "Administrador";
                    bitacora.Accion = "Registro de una categoría";
                    bitacora.FechaAccion = DateTime.Now;
                    crudBitacora.Create(bitacora);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public List<Categoria> RetrieveAll()
        {
            return crudCategoria.RetrieveAll<Categoria>();
        }
        public Categoria RetrieveById(Categoria categoria)
        {
            Categoria c = null;
            try
            {
                c = crudCategoria.Retrieve<Categoria>(categoria);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Categoria categoria)
        {
            crudCategoria.Update(categoria);
            Bitacora bitacora = new Bitacora();
            bitacora.Usuario = "Administrador";
            bitacora.Accion = "Modificacón de una categoría";
            bitacora.FechaAccion = DateTime.Now;
            crudBitacora.Create(bitacora);
        }

        public void Delete(Categoria categoria)
        {
            crudCategoria.Delete(categoria);
            Bitacora bitacora = new Bitacora();
            bitacora.Usuario = "Administrador";
            bitacora.Accion = "Eliminación de una categoría";
            bitacora.FechaAccion = DateTime.Now;
            crudBitacora.Create(bitacora);
        }
    }
}

