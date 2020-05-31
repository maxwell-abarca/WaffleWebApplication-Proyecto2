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
    public class VehiculoManager : BaseManager
    {
        private VehiculoCrudFactory crudVehiculo;
        private FlotillaCrudFactory crudFlotilla;

        public VehiculoManager()
        {
            crudVehiculo = new VehiculoCrudFactory();
            crudFlotilla = new FlotillaCrudFactory();

        }
        public void Create(Vehiculo vehiculo)
        {
            try
            {
                var v = crudVehiculo.Retrieve<Vehiculo>(vehiculo);
                if (v != null)
                {
                    throw new BussinessException(13);
                }

                /*Si el vehiculo no existe entonces que cree el vehiculo con el id de la flotilla*/
                var consulta = crudVehiculo.RetrieveMisVehiculos<Vehiculo>(vehiculo);
                if (consulta.Count == 0)
                {
                    var flotilla = new Flotilla
                    {
                        CedulaDueno = vehiculo.CedulaDueno
                    };
                    var f = crudFlotilla.Retrieve<Flotilla>(flotilla);
                    vehiculo.IdFlotilla = f.Id;
                    crudVehiculo.Create(vehiculo);
                }
                else
                {
                    crudVehiculo.Create(vehiculo);
                }



            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Vehiculo> RetrieveAll()
        {
            return crudVehiculo.RetrieveAll<Vehiculo>();
        }
        public Vehiculo RetrieveById(Vehiculo vehiculo)
        {
            Vehiculo v = null;
            try
            {
                v = crudVehiculo.Retrieve<Vehiculo>(vehiculo);
                if (v == null)
                {
                    /*No se han encontrado resultados de la búsqueda*/
                    throw new BussinessException(14);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return v;
        }
        public List<Vehiculo> RetrieveMisVehiculos(Vehiculo vehiculo)
        {
            var listMisVehiculos = new List<Vehiculo>();
            try
            {
                listMisVehiculos = crudVehiculo.RetrieveMisVehiculos<Vehiculo>(vehiculo);
                if (listMisVehiculos == null)
                {
                    /*No se encontraron resultados de la búsqueda*/
                    throw new BussinessException(15);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return listMisVehiculos;
        }
        public void Update(Vehiculo vehiculo)
        {
            crudVehiculo.Update(vehiculo);
        }

        public void Delete(Vehiculo vehiculo)
        {
            crudVehiculo.Delete(vehiculo);
        }

    }
}
