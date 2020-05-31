using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Controls;

namespace WebApp.Models.Helpers
{
    public static class ControlExtensions
    {
        public static HtmlString CtrlButton(this HtmlHelper html, string viewName, string id, string label, string onClickFunction = "", string style = "")
        {
            var ctrl = new CtrlButtonModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                Class = style
            };

            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlInput(this HtmlHelper html, string viewName, string id, string label, string placeholder, string type, string columnDataName)
        {
            var ctrl = new CtrlInputModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                PlaceHolder = placeholder,
                Type = type,
                ColumnDataName = columnDataName
            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlImage(this HtmlHelper html, string viewName, string id, string width)
        {
            var ctrl = new CtrlImageModel
            {
                ViewName = viewName,
                Id = id,
                Width = width

            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlRadio(this HtmlHelper html, string viewName, string id, string label, string type, string value)
        {
            var ctrl = new CtrlRadioModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                Type = type,
                Value = value

            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlCardProducto(this HtmlHelper html, string viewName, string id, string ImageSource, string NombreProducto, string NombreComercio, string PrecioProducto)
        {
            var ctrl = new CtrlCardProductoModel
            {
                ViewName = viewName,
                Id = id,
                ImageSource = ImageSource,
                NombreProducto = NombreProducto,
                NombreComercio = NombreComercio,
                PrecioProducto = PrecioProducto

            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlDisabledInput(this HtmlHelper html, string viewName, string id, string label, string placeholder, string type, string columnDataName)
        {
            var ctrl = new CtrlDisabledInputModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                PlaceHolder = placeholder,
                Type = type,
                ColumnDataName = columnDataName
            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlTable(this HtmlHelper html, string viewName, string id, string title,
                       string columnsTitle, string ColumnsDataName, string onSelectFunction, string colorHeader)
        {
            var ctrl = new CtrlTableModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName,
                FunctionName = onSelectFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlSelect(this HtmlHelper html, string viewName, string id, string label)
        {
            var ctrl = new CtrlSelectModel
            {
                ViewName = viewName,
                Id = id,
                Label = label


            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlMap(this HtmlHelper html, string viewName, string id, string style)
        {
            var ctrl = new CtrlMapModel
            {
                ViewName = viewName,
                Id = id,
                Class = style
            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlCardComercio(this HtmlHelper html, string viewName, string id, string ImageSource,
               string NombreComercio, string DireccionEscrita, string OnClickFunction, Object ComercioData)
        {
            var ctrl = new CtrlCardComercioModel
            {
                ViewName = viewName,
                Id = id,
                ImageSource = ImageSource,
                NombreComercio = NombreComercio,
                DireccionEscrita = DireccionEscrita,
                OnClickFunction = OnClickFunction,
                ComercioData = ComercioData
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlCardComercioAdmin(this HtmlHelper html, string viewName, string id, string ImageSource,
            string NombreComercio, string Cedula, string DireccionEscrita, string Telefono, string OnClickFunction, string Label, string Visible)
        {
            var ctrl = new CtrlCardComercioAdminModel
            {
                ViewName = viewName,
                Id = id,
                ImageSource = ImageSource,
                NombreComercio = NombreComercio,
                Cedula = Cedula,
                DireccionEscrita = DireccionEscrita,
                Telefono = Telefono,
                OnClickFunction = OnClickFunction,
                Label = Label,
                Visible = Visible
            };

            return new HtmlString(ctrl.GetHtml());
        }

        /*        public static HtmlString CtrlCardComercioAdmin(this HtmlHelper html, string viewName, string id, string ImageSource,
                       string NombreComercio, string DireccionEscrita)
                {
                    var ctrl = new CtrlCardComercioAdminModel
                    {
                        ViewName = viewName,
                        Id = id,
                        ImageSource = ImageSource,
                        NombreComercio = NombreComercio,
                        DireccionEscrita = DireccionEscrita
                    };

                    return new HtmlString(ctrl.GetHtml());
                }*/
        public static HtmlString CtrlCardProductoCom(this HtmlHelper html, string viewName, string id, string ImageSource, string NombreProducto, string NombreComercio, string PrecioProducto, string OnClickFunction)
        {
            var ctrl = new CtrlCardProductoComModel
            {
                ViewName = viewName,
                Id = id,
                ImageSource = ImageSource,
                NombreProducto = NombreProducto,
                NombreComercio = NombreComercio,
                PrecioProducto = PrecioProducto,
                OnClickFunction = OnClickFunction

            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlCardProductoAdmin(this HtmlHelper html, string viewName, string id, string ImageSource, string NombreProducto, string NombreComercio, string PrecioProducto)
        {
            var ctrl = new CtrlCardProductoAdminModel
            {
                ViewName = viewName,
                Id = id,
                ImageSource = ImageSource,
                NombreProducto = NombreProducto,
                NombreComercio = NombreComercio,
                PrecioProducto = PrecioProducto

            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlCardTransportista(this HtmlHelper html, string viewName, string id, string ImageSource, string Name, string Identification, string Status, string OnClick, string Label)
        {
            var ctrl = new CtrlCardTransportistaModel
            {
                ViewName = viewName,
                Id = id,
                ImageSource = ImageSource,
                Name = Name,
                Identification = Identification,
                Status = Status,
                OnClick = OnClick,
                Label = Label

            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlCardSoliocitudesT(this HtmlHelper html, string viewName, string id, string ImageSource, string Name, string Identification, string Email, string Phone, string Deny, string Accept)
        {
            var ctrl = new CtrlCardSolicitudUsuarioModel
            {
                ViewName = viewName,
                Id = id,
                ImageSource = ImageSource,
                Name = Name,
                Identification = Identification,
                Email = Email,
                Phone = Phone,
                Deny = Deny,
                Accept = Accept

            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlMap(this HtmlHelper html, string viewName, string id, string style)
        {
            var ctrl = new CtrlMapModel
            {
                ViewName = viewName,
                Id = id,
                Class = style
            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlCardComercio(this HtmlHelper html, string viewName, string id, string ImageSource,
               string NombreComercio, string DireccionEscrita, string OnClickFunction, Object ComercioData)
        {
            var ctrl = new CtrlCardComercioModel
            {
                ViewName = viewName,
                Id = id,
                ImageSource = ImageSource,
                NombreComercio = NombreComercio,
                DireccionEscrita = DireccionEscrita,
                OnClickFunction = OnClickFunction,
                ComercioData = ComercioData
            };

            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlCardComercioAdmin(this HtmlHelper html, string viewName, string id, string ImageSource,
               string NombreComercio, string DireccionEscrita)
        {
            var ctrl = new CtrlCardComercioAdminModel
            {
                ViewName = viewName,
                Id = id,
                ImageSource = ImageSource,
                NombreComercio = NombreComercio,
                DireccionEscrita = DireccionEscrita
            };

            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlCardProductoCom(this HtmlHelper html, string viewName, string id, string ImageSource, string NombreProducto, string NombreComercio, string PrecioProducto, string OnClickFunction)
        {
            var ctrl = new CtrlCardProductoComModel
            {
                ViewName = viewName,
                Id = id,
                ImageSource = ImageSource,
                NombreProducto = NombreProducto,
                NombreComercio = NombreComercio,
                PrecioProducto = PrecioProducto,
                OnClickFunction = OnClickFunction

            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlCardProductoAdmin(this HtmlHelper html, string viewName, string id, string ImageSource, string NombreProducto, string NombreComercio, string PrecioProducto)
        {
            var ctrl = new CtrlCardProductoAdminModel
            {
                ViewName = viewName,
                Id = id,
                ImageSource = ImageSource,
                NombreProducto = NombreProducto,
                NombreComercio = NombreComercio,
                PrecioProducto = PrecioProducto

            };
            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlChart(this HtmlHelper html, string viewName, string id, string title,
    string labels, string chartType, string onLoadFunction)
        {
            var ctrl = new CtrlChartModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Labels = labels,
                ChartType = chartType,
                OnLoadFunction = onLoadFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }
    }
}