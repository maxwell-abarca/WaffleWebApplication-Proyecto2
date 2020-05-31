using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlCardComercioAdminModel : CtrlBaseModel
    {
        public string ImageSource { get; set; }
        public string NombreComercio { get; set; }
        public string Cedula { get; set; }
        public string DireccionEscrita { get; set; }
        public string Telefono { get; set; }
        public string OnClickFunction { get; set; }
        public string Label { get; set; }
        public string Visible { get; set; }

        public CtrlCardComercioAdminModel()
        {
            ViewName = "";
        }
    }
}