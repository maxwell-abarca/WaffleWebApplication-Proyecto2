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
    public class DireccionUsuarioManager : BaseManager
    {
        private DireccionUsuarioCrudFactory crudDireccion;

        public DireccionUsuarioManager()
        {
            crudDireccion=new DireccionUsuarioCrudFactory();
        }
        
        public void Create(DireccionUsuario dUsuario)
        {
            try
            {
                /*var d = crudDireccion.Retrieve<DireccionUsuario>(dUsuario);
                if (d != null)
                {
                    Update(dUsuario);
                }*/
                crudDireccion.Create(dUsuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public List<DireccionUsuario> RetrieveAll()
        {
            return crudDireccion.RetrieveAll<DireccionUsuario>();

        }
        public DireccionUsuario RetrieveById(DireccionUsuario dUsuario)
        {
            DireccionUsuario d = null;
            try
            {
                d = crudDireccion.Retrieve<DireccionUsuario>(dUsuario);
                if (d == null)
                {
                    /*No se han encontrado resultados de la búsqueda*/
                    throw new BussinessException(30);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return d;
        }
        public void Update(DireccionUsuario dUsuario)
        {
            crudDireccion.Update(dUsuario);
        }
        public void Delete(DireccionUsuario dUsuario)
        {
            crudDireccion.Delete(dUsuario);
        }


    }
}
