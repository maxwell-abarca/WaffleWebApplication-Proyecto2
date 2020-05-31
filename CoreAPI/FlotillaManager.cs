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
    public class FlotillaManager : BaseManager
    {
        private FlotillaCrudFactory crudFlotilla;

        public FlotillaManager()
        {
            crudFlotilla = new FlotillaCrudFactory();
        }
        public void Create(Flotilla flotilla)
        {
            try
            {

                crudFlotilla.Create(flotilla);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public List<Flotilla> RetrieveAll()
        {
            return crudFlotilla.RetrieveAll<Flotilla>();
        }
        public List<Flotilla> RetrieveMisFlotillas(Flotilla flotilla)
        {
            var list = new List<Flotilla>();
            try
            {
                list = crudFlotilla.RetrieveMisFlotillas<Flotilla>(flotilla);
                if (list == null)
                {
                    throw new BussinessException(90);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return list;
        }
        public Flotilla RetrieveById(Flotilla flotilla)
        {
            Flotilla f = null;
            try
            {
                f = crudFlotilla.Retrieve<Flotilla>(flotilla);
                if (f == null)
                {
                    /*No se encontraron resultados de la búsqueda*/
                    throw new BussinessException(17);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return f;
        }
        public void Update(Flotilla flotilla)
        {
            crudFlotilla.Update(flotilla);
        }
        public void Delete(Flotilla flotilla)
        {
            crudFlotilla.Delete(flotilla);
        }

    }
}
