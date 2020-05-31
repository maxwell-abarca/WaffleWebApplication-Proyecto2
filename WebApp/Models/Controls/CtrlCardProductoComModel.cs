using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlCardProductoComModel : CtrlBaseModel
    {
        public string ImageSource { get; set; }
        public string NombreProducto { get; set; }
        public string NombreComercio { get; set; }
        public string PrecioProducto { get; set; }
        public string OnClickFunction { get; set; }

        public CtrlCardProductoComModel()
        {
            ViewName = "";
        }

    }
}
