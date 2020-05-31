using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CorreoUsuario",
                routeTemplate: "api/{controller}/{correo}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "UpdateContrasena",
                routeTemplate: "api/{controller}/{cedula}/{contrasena}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DireccionByLatLng",
                routeTemplate: "api/{controller}/{latitud}/{longitud}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GetCadenaUsuario",
                routeTemplate: "api/{controller}/{CedulaDueno}",
                defaults: new { id = RouteParameter.Optional }
            ); 
            config.Routes.MapHttpRoute(
                name: "GetTransportistasSolicitudes",
                routeTemplate: "api/{controller}/{idRol}/{estado}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "CreateComercio",
                routeTemplate: "api/{controller}/{comercio}/{latitud}/{longitud}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GetComercios",
                routeTemplate: "api/{controller}/{comercio}/{cedula}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "RetrieveProductosPorComercio",
                routeTemplate: "api/{controller}/{producto}/{CedulaComercio}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GetCorreo",
                routeTemplate: "api/{controller}/{correo}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GetTransportistasEstado",
                routeTemplate: "api/{controller}/{estado}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GetComerciosEstado",
                routeTemplate: "api/{controller}/{est}",
                defaults: new { id = RouteParameter.Optional }
            ); 
        }
    }
}
