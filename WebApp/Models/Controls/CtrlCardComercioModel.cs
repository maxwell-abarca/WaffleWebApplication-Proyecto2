using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlCardComercioModel : CtrlBaseModel
    {
        public string ImageSource { get; set; }
        public string NombreComercio { get; set; }
        public string DireccionEscrita { get; set; }
        public string OnClickFunction { get; set; }
        public Object ComercioData { get; set; }

        public CtrlCardComercioModel()
        {
            ViewName = "";
        }
    }
}