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
    public class ComercioManager : BaseManager
    {
        private ComercioCrudFactory crudComercio;
        private DireccionCrudFactory crudDireccion;
        private BitacoraCrudFactory crudBitacora;

        public ComercioManager()
        {
            crudComercio = new ComercioCrudFactory();
            crudDireccion = new DireccionCrudFactory();
            crudBitacora = new BitacoraCrudFactory();
        }
        public void Create(Comercio comercio)
        {
            try
            {
                var dirCrud = crudDireccion;
                var d = new Direccion
                {
                    Latitud = comercio.Latitud,
                    Longitud = comercio.Longitud
                };
                dirCrud.Create(d);
                Direccion dir = dirCrud.Retrieve<Direccion>(d);
                var c = crudComercio;
                comercio.IdDireccion = dir.ID;
                crudComercio.Create(comercio);
                Bitacora bitacora = new Bitacora();
                bitacora.Usuario = comercio.CedulaDueno.ToString();
                bitacora.Accion = "Se registro un comercio";
                bitacora.FechaAccion = DateTime.Now;
                crudBitacora.Create(bitacora);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

        }
        public List<Comercio> RetrieveAll()
        {
            return crudComercio.RetrieveAll<Comercio>();
        }
        public Comercio RetrieveById(Comercio comercio)
        {
            Comercio c = null;
            try
            {
                c = crudComercio.Retrieve<Comercio>(comercio);
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
        public void Update(Comercio comercio)
        {
            //var dirCrud = crudDireccion;
            //var d = new Direccion
            //{
            //    Latitud = comercio.Latitud,
            //    Longitud = comercio.Longitud
            //};
            //dirCrud.Create(d);
            //Direccion dir = dirCrud.Retrieve<Direccion>(d);
            //var c = crudComercio;
            //comercio.IdDireccion = dir.ID;
            crudComercio.Update(comercio);
        }
        public void Delete(Comercio comercio)
        {
            crudComercio.Delete(comercio);
        }
        public void GetUpdateEstado(Comercio comercio)
        {
            comercio.Estado = "EST-RECHAZADO";
            crudComercio.GetUpdateEstado(comercio);
            Bitacora bitacora = new Bitacora();
            bitacora.Usuario = "Administrador";
            bitacora.Accion = "Se rechazo la membresía del comercio";
            bitacora.FechaAccion = DateTime.Now;
            crudBitacora.Create(bitacora);
        }
        public List<Comercio> RetrieveComerciosSolicitudes(Comercio comercio)
        {
            var lstComercios = new List<Comercio>();
            try
            {
                lstComercios = crudComercio.RetrieveComerciosSolicitudes<Comercio>(comercio);
                if (lstComercios == null)
                {
                    /*Aún no existen transportistas*/
                    throw new BussinessException(7);
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return lstComercios;
        }
        public List<Comercio> GetComercio(Comercio comercio)
        {
            return crudComercio.GetComercios<Comercio>(comercio);
        }
        public List<Comercio> GetComerciosEstado(Comercio comercio)
        {
            var lstComercios = new List<Comercio>();
            try
            {
                lstComercios = crudComercio.GetComerciosEstado<Comercio>(comercio);
                if (lstComercios == null)
                {
                    throw new BussinessException(6);
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return lstComercios;
        }
    }
}
