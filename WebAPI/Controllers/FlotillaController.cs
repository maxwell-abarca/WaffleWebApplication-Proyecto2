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
    public class FlotillaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            var mng = new FlotillaManager();
            apiResp = new ApiResponse();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        public IHttpActionResult Get(string nombre)
        {
            try
            {
                var mng = new FlotillaManager();
                apiResp = new ApiResponse();
                var flotilla = new Flotilla
                {
                    Nombre = nombre
                };
                flotilla = mng.RetrieveById(flotilla);
                apiResp.Data = flotilla;
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult GetMisFLotillas(int cedulaDueno)
        {
            try
            {
                var mng = new FlotillaManager();
                apiResp = new ApiResponse();
                var list = new List<Flotilla>();
                var flotilla = new Flotilla
                {
                    CedulaDueno = cedulaDueno
                };
                list = mng.RetrieveMisFlotillas(flotilla);
                apiResp.Data = list;
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Flotilla flotilla)
        {
            try
            {
                var mng = new FlotillaManager();
                mng.Create(flotilla);
                apiResp = new ApiResponse();
                apiResp.Message = "Flotilla creada correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Put(Flotilla flotilla)
        {
            try
            {
                var mng = new FlotillaManager();
                mng.Update(flotilla);
                apiResp = new ApiResponse();
                apiResp.Message = "Flotilla actualizada correctamente";
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Delete(Flotilla flotilla)
        {
            try
            {
                var mng = new FlotillaManager();
                mng.Delete(flotilla);
                apiResp = new ApiResponse();
                apiResp.Message = "Flotilla eliminada correctamente";
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}
