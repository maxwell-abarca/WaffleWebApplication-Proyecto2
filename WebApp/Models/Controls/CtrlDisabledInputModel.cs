using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlDisabledInputModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string PlaceHolder { get; set; }
        public string Type { get; set; }
        public string ColumnDataName { get; set; }


        public CtrlDisabledInputModel()
        {
            ViewName = "";
        }
    }
}