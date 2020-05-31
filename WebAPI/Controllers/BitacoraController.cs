using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CoreAPI;
using Entities;
using Exceptions;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class BitacoraController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/bitacora
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new BitacoraManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }
        // GET api/bitacora/5
        // Retrieve by id
        public IHttpActionResult Get(string usuario, string accion, DateTime fecha)
        {
            try
            {
                var mng = new BitacoraManager();
                var bitacora = new Bitacora
                {
                    Usuario = usuario,
                    Accion = accion,
                    FechaAccion = fecha
                };

                bitacora = mng.RetrieveById(bitacora);
                apiResp = new ApiResponse();
                apiResp.Data = bitacora;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Bitacora bitacora)
        {

            try
            {
                var mng = new BitacoraManager();
                mng.Create(bitacora);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Bitacora bitacora)
        {
            try
            {
                var mng = new BitacoraManager();
                mng.Update(bitacora);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(Bitacora bitacora)
        {
            try
            {
                var mng = new BitacoraManager();
                mng.Delete(bitacora);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}