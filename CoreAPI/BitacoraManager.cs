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
    public class BitacoraManager
    {
        private BitacoraCrudFactory crudBitacora;

        public BitacoraManager()
        {
            crudBitacora = new BitacoraCrudFactory();
        }
        public void Create(Bitacora bitacora)
        {
            try
            {
                /**var c = crudBitacora.Retrieve<Bitacora>(bitacora);
                if (c != null)
                {
                    //Bitacora already exist
                    throw new BussinessException(3);
                }**/
                crudBitacora.Create(bitacora);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

        }
        public List<Bitacora> RetrieveAll()
        {
            return crudBitacora.RetrieveAll<Bitacora>();
        }

        public Bitacora RetrieveById(Bitacora bitacora)
        {
            Bitacora b = null;
            try
            {
                b = crudBitacora.Retrieve<Bitacora>(bitacora);
                if (b == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return b;
        }
        public void Update(Bitacora bitacora)
        {
            crudBitacora.Update(bitacora);
        }
        public void Delete(Bitacora bitacora)
        {
            crudBitacora.Delete(bitacora);
        }
    }
}
