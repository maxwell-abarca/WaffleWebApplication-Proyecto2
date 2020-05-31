using CoreAPI;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DireccionUsuarioController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            var mng = new DireccionUsuarioManager();
            apiResp = new ApiResponse();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        public IHttpActionResult Get(int idUsuario)
        {
            try
            {
                var mng = new DireccionUsuarioManager();
                var direccionUsuario = new DireccionUsuario
                {
                    IdUsuario = idUsuario
                };
                direccionUsuario = mng.RetrieveById(direccionUsuario);
                apiResp = new ApiResponse();
                apiResp.Data = direccionUsuario;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }
        public IHttpActionResult Post(DireccionUsuario dUsuario)
        {
            try
            {
                var mng = new DireccionUsuarioManager();
                mng.Create(dUsuario);
                apiResp = new ApiResponse();
                apiResp.Message = "Direccion creada correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Put(DireccionUsuario dUsuario)
        {
            try
            {
                var mng = new DireccionUsuarioManager();
                mng.Update(dUsuario);
                apiResp = new ApiResponse();
                apiResp.Message = "Direccion actualizada correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Delete(DireccionUsuario dUsuario)
        {
            try
            {
                var mng = new DireccionUsuarioManager();
                mng.Delete(dUsuario);
                apiResp = new ApiResponse();
                apiResp.Message = "Direccion eliminada correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}
