using DataAccess.Crud;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ApplicationMessageManager
    {
        public AppMessageCrudFactory crudApp;
        public ApplicationMessageManager()
        {
            crudApp = new AppMessageCrudFactory();
        }
        public List<ApplicationMessage> RetrieveAll()
        {
            return crudApp.RetrieveAll<ApplicationMessage>();
        }
    }
}
