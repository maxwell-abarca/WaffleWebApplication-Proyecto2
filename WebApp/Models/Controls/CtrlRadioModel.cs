using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlRadioModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string Label { get; set; }

        public string Value { get; set; }

        public CtrlRadioModel()
        {
            ViewName = "";
        }

    }
}