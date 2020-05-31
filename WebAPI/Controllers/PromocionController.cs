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
    public class PromocionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new PromocionManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        public IHttpActionResult Get(string codigo)
        {
            try
            {
                var mng = new PromocionManager();
                var promocion = new Promocion
                {
                    Codigo = codigo
                };
                promocion = mng.Retrieve(promocion);
                apiResp = new ApiResponse();
                apiResp.Data = promocion;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Get(int idComercio)
        {
            try
            {
                var mng = new PromocionManager();
                apiResp = new ApiResponse();
                var list = new List<Promocion>();
                var promocion = new Promocion
                {
                    IdComercio = idComercio
                };
                list = mng.RetrieveMisPromociones(promocion);
                apiResp.Data = list;
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Post(Promocion promocion)
        {
            try
            {
                var mng = new PromocionManager();
                mng.Create(promocion);
                apiResp = new ApiResponse();
                apiResp.Message = "Promoción creada correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Put(Promocion promocion)
        {
            try
            {
                var mng = new PromocionManager();
                mng.Update(promocion);
                apiResp = new ApiResponse();
                apiResp.Message = "Promoción actualizada correctamente";
                return Ok(apiResp);
            }

            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Delete(Promocion promocion)
        {
            try
            {
                var mng = new PromocionManager();
                mng.Delete(promocion);
                apiResp = new ApiResponse();
                apiResp.Message = "Promocion eliminada correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}
