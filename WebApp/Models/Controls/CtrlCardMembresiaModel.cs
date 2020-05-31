using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlCardMembresiaModel : CtrlBaseModel
    {
        public string NombreMembresia { get; set; }
        public string Descripcion { get; set; }
        public double PrecioMembresia { get; set; }
        public CtrlCardMembresiaModel()
        {
            ViewName = "";
        }
    }
}