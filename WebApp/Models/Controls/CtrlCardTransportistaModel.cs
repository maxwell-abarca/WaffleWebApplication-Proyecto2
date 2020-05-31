using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlCardTransportistaModel : CtrlBaseModel
    {
        public string ImageSource { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public string Status { get; set; }
        public string OnClick { get; set; }
        public string Label { get; set; }

        public CtrlCardTransportistaModel()
        {
            ViewName = "";
        }
    }
}