using CoreAPI;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;
using Entities;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class ComercioController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new ComercioManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        public IHttpActionResult Get(string nombre)
        {
            try
            {
                var mng = new ComercioManager();
                var comercio = new Comercio
                {
                    NombreComercial = nombre
                };
                apiResp = new ApiResponse();
                apiResp.Data = comercio;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Post(Comercio comercio)
        {
            try
            {
                var mng = new ComercioManager();
                mng.Create(comercio);
                apiResp = new ApiResponse();
                apiResp.Message = "Comercio registrado correctamente";
                //apiResp.Data = comercio;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Put(Comercio comercio)
        {
            try
            {
                var mng = new ComercioManager();
                mng.Update(comercio);
                apiResp = new ApiResponse();
                apiResp.Message = "Comercio actualizado correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Delete(Comercio comercio)
        {
            try
            {
                var mng = new ComercioManager();
                mng.Delete(comercio);
                apiResp = new ApiResponse();
                apiResp.Message = "Comercio eliminado correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult GetComercios(int cedula)
        {
            try
            {
                var mng = new ComercioManager();
                var comercio = new Comercio
                {
                    CedulaDueno = cedula
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.GetComercio(comercio);
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult GetSolicitudesComercios(string estado)
        {
            try
            {
                var mng = new ComercioManager();
                var list = new List<Comercio>();
                var comercio = new Comercio
                {
                    Estado = estado
                };
                list = mng.RetrieveComerciosSolicitudes(comercio);
                apiResp = new ApiResponse();
                apiResp.Data = list;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult GetComerciosEstado(string est)
        {
            try
            {
                var mng = new ComercioManager();
                var list = new List<Comercio>();
                var comercio = new Comercio
                {
                    Estado = est
                };
                list = mng.GetComerciosEstado(comercio);
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
