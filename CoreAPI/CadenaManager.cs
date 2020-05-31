using DataAccess.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class CadenaManager : BaseManager
    {
        private CadenaCrudFactory crudCadena;

        public CadenaManager()
        {
            crudCadena = new CadenaCrudFactory();
        }
        public void Create(Cadena cadena)
        {
            try
            {

                crudCadena.Create(cadena);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public List<Cadena> RetrieveAll()
        {
            return crudCadena.RetrieveAll<Cadena>();
        }
        public Cadena RetrieveById(Cadena cadena)
        {
            Cadena c = null;
            try
            {
                c = crudCadena.Retrieve<Cadena>(cadena);
                if (c == null)
                {
                    throw new BussinessException(1);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return c;
        }
        public List<Cadena> GetCadenaUsuario(Cadena cadena)
        {
            var lstCadenas = new List<Cadena>();

            try
            {
                lstCadenas = crudCadena.GetCadenaUsuario<Cadena>(cadena);
                if (lstCadenas == null)
                {
                    throw new BussinessException(1);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return lstCadenas;
        }
        
        public void Update(Cadena cadena)
        {
            crudCadena.Update(cadena);
        }
        public void Delete(Cadena cadena)
        {
            crudCadena.Delete(cadena);
        }

    }
}