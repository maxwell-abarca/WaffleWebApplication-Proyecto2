using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlCardSolicitudUsuarioModel : CtrlBaseModel
    {
        public string ImageSource { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Deny { get; set; }
        public string Accept { get; set; }

        public CtrlCardSolicitudUsuarioModel()
        {
            ViewName = "";
        }
    }
}