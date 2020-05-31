using System;
using System.Web.Http;
using CoreAPI;
using Entities;
using Exceptions;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class DireccionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        
        [HttpGet]
        public IHttpActionResult DireccionByLatLng(double latitud, double longitud)
        {
            try
            {
                var mng = new DireccionManager();
                var dir = new Direccion
                {
                    Latitud = latitud,
                    Longitud = longitud
                };

                dir = mng.RetrieveById(dir);
                apiResp = new ApiResponse();
                apiResp.Data = dir;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new DireccionManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Post(Direccion dir)
        {
            try
            {
                var mng = new DireccionManager();
                mng.Create(dir);

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

        public IHttpActionResult Put(Direccion dir)
        {
            try
            {
                var mng = new DireccionManager();
                mng.Update(dir);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var mng = new DireccionManager();
                var dir = new Direccion
                {
                    ID = id
                };
                mng.Delete(dir);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new DireccionManager();
                var direccion = new Direccion
                {
                    ID = id
                };
                direccion = mng.Retrieve(direccion);
                apiResp = new ApiResponse();
                apiResp.Data = direccion;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }
    }
}