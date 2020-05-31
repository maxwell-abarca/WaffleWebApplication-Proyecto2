using DataAccess.Crud;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ComercioInactivoManager : BaseManager
    {
        private ComercioInactivoCrudFactory crudComercio;

        public ComercioInactivoManager()
        {
            crudComercio = new ComercioInactivoCrudFactory();
        }
        public List<Comercio> RetrieveAll()
        {
            return crudComercio.RetrieveAll<Comercio>();
        }
    }
}
