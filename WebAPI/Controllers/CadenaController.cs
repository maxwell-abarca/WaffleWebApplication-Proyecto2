using CoreAPI;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using Entities;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class CadenaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new CadenaManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        public IHttpActionResult Get(string nombre)
        {
            try
            {
                var mng = new CadenaManager();
                var cadena = new Cadena
                {
                    Nombre = nombre
                };
                apiResp = new ApiResponse();
                apiResp.Data = cadena;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult GetCadenaUsuario(int CedulaDueno)
        {
            try
            {
                var mng = new CadenaManager();
                var list = new List<Cadena>();
                var cadena = new Cadena
                {
                    CedulaDueno = CedulaDueno
                };
                list = mng.GetCadenaUsuario(cadena);
                apiResp = new ApiResponse();
                apiResp.Data = list;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Post(Cadena cadena)
        {
            try
            {
                var mng = new CadenaManager();
                mng.Create(cadena);
                apiResp = new ApiResponse();
                apiResp.Message = "Cadena registrada correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Put(Cadena cadena)
        {
            try
            {
                var mng = new CadenaManager();
                mng.Update(cadena);
                apiResp = new ApiResponse();
                apiResp.Message = "Cadena actualizada correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Delete(Cadena cadena)
        {
            try
            {
                var mng = new CadenaManager();
                mng.Delete(cadena);
                apiResp = new ApiResponse();
                apiResp.Message = "Cadena eliminada correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}

