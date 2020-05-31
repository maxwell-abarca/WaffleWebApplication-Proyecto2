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
    public class PromocionManager : BaseManager
    {
        private PromocionCrudFactory crudPromocion;

        public PromocionManager()
        {
            crudPromocion = new PromocionCrudFactory();
        }
        public void Create(Promocion promocion)
        {
            try
            {
                var p = crudPromocion.Retrieve<Promocion>(promocion);
                if (p != null)
                {
                    /*Ya la promocion se encuentra existente*/
                    throw new BussinessException(10);
                }
                crudPromocion.Create(promocion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public List<Promocion> RetrieveAll()
        {
            return crudPromocion.RetrieveAll<Promocion>();
        }
        public List<Promocion> RetrieveMisPromociones(Promocion promocion)
        {
            return crudPromocion.RetrieveMisPromociones<Promocion>(promocion);
        }
        public Promocion Retrieve(Promocion promocion)
        {
            Promocion p = null;
            try
            {
                if (p == null)
                {
                    /*No se han encontrado resultados de la búsqueda*/
                    throw new BussinessException(11);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return p;
        }
        public void Update(Promocion promocion)
        {
            crudPromocion.Update(promocion);
        }
        public void Delete(Promocion promocion)
        {
            crudPromocion.Delete(promocion);
        }



    }
}
