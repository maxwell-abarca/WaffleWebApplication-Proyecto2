using DataAccess.Crud;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class TransportistaInactivoManager : BaseManager
    {
        private TransportistaInactivoCrudFactory crudUsuario;
        public TransportistaInactivoManager()
        {
            crudUsuario = new TransportistaInactivoCrudFactory();
        }
        public List<Usuario> RetrieveAll()
        {
            return crudUsuario.RetrieveAll<Usuario>();
        }
    }
}

