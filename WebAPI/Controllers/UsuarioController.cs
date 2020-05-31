using CoreAPI;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [ExceptionFilter]

    public class UsuarioController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/usuario
        // Retrieve
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new UsuarioManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }

        public IHttpActionResult Get(int id, string nombre)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    Cedula = id,
                    Nombre = nombre
                };
                usuario = mng.RetrieveById(usuario);
                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Usuario usuario)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Create(usuario);


                apiResp = new ApiResponse();
                apiResp.Message = "Usuario registrado";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Put(Usuario usuario)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Update(usuario);
                apiResp = new ApiResponse();
                apiResp.Message = "La acción fué ejecutada.";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Delete(Usuario usuario)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Delete(usuario);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fué ejecutada.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Get(string correo, string contrasena)
        {
            try
            {
                var mng = new UsuarioManager();

                var usuario = new Usuario
                {
                    Correo = correo,
                    Contrasena = contrasena
                };


                usuario = mng.GetUsuario(usuario);
                apiResp = new ApiResponse();
                apiResp.Data = usuario;


                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Get(string codigo)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    CodigoVerificacion = codigo
                };
                usuario = mng.RetrieveCodigoUsuario(usuario);

                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }


        public IHttpActionResult GetCorreo(string correo)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    Correo = correo
                };
                usuario = mng.GetCorreo(usuario);

                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult GetTransportistas(int idRol)
        {
            try
            {
                var mng = new UsuarioManager();
                var list = new List<Usuario>();
                var usuario = new Usuario
                {
                    IdRol = idRol
                };
                list = mng.RetrieveTransportistas(usuario);
                apiResp = new ApiResponse();
                apiResp.Data = list;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult UpdateContrasena(string correo)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    Correo = correo
                };
                mng.UpdateContrasena(usuario);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fué ejecutada.";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        //public IHttpActionResult UpdateEstado(Usuario usuario)
        //{
        //    try
        //    {
        //        var mng = new UsuarioManager();
        //        mng.UpdateEstado(usuario);
        //        apiResp = new ApiResponse();
        //        apiResp.Message = "Acción ejecutada.";
        //        return Ok(apiResp);
        //    }
        //    catch (BussinessException bex)
        //    {
        //        return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
        //    }
        //}
        public IHttpActionResult GetUsuarioCorreo(int id)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    Cedula = id
                };
                usuario = mng.GetUsuarioCorreo(usuario);
                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        //public IHttpActionResult GetUpdateEstado(Usuario usuario)
        //{
        //    try
        //    {
        //        var mng = new MembresiaManager();
        //        mng.GetUpdateEstado(usuario);
        //        apiResp = new ApiResponse();
        //        apiResp.Message = "Acción ejecutada.";
        //        return Ok(apiResp);
        //    }
        //    catch (BussinessException bex)
        //    {
        //        return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
        //    }
        //}
        public IHttpActionResult GetRetriveCedula(int cedula)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    Cedula = cedula
                };
                usuario = mng.GetUsuarioCorreo(usuario);
                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult GetTransportistasEstado(string estado)
        {
            try
            {
                var mng = new UsuarioManager();
                var list = new List<Usuario>();
                var usuario = new Usuario
                {
                    Estado = estado
                };
                list = mng.GetTransportistasEstado(usuario);
                apiResp = new ApiResponse();
                apiResp.Data = list;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
