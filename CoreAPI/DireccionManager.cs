using System;
using System.Collections.Generic;
using DataAccess.Crud;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities;
using Exceptions;

namespace CoreAPI
{
    public class DireccionManager : BaseManager
    {
        private DireccionCrudFactory crudDireccion;

        public DireccionManager()
        {
            crudDireccion = new DireccionCrudFactory();
        }
        public void Create(Direccion direccion)
        {
            try
            {
                var d = crudDireccion;
                crudDireccion.Create(direccion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

        }
        public List<Direccion> RetrieveAll()
        {
            return crudDireccion.RetrieveAll<Direccion>();
        }

        public Direccion RetrieveById(Direccion direccion)
        {
            Direccion d = null;
            try
            {
                d = crudDireccion.Retrieve<Direccion>(direccion);
                if (d == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return d;
        }

        public void Update(Direccion direccion)
        {
            crudDireccion.Update(direccion);
        }

        public void Delete(Direccion direccion)
        {
            crudDireccion.Delete(direccion);
        }
        public Direccion Retrieve(Direccion direccion)
        {
            Direccion d = null;
            try
            {
                d = crudDireccion.Get<Direccion>(direccion);
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
    }
}
