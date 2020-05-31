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
    public class VehiculoController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            var mng = new VehiculoManager();
            apiResp = new ApiResponse();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        public IHttpActionResult Get(string placa)
        {
            try
            {
                var mng = new VehiculoManager();
                var vehiculo = new Vehiculo
                {
                    Placa = placa
                };
                apiResp = new ApiResponse();
                vehiculo = mng.RetrieveById(vehiculo);
                apiResp.Data = vehiculo;
                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Get(int cedulaDueno)
        {
            try
            {
                var mng = new VehiculoManager();
                apiResp = new ApiResponse();
                var list = new List<Vehiculo>();
                var vehiculo = new Vehiculo
                {
                    CedulaDueno = cedulaDueno
                };
                list = mng.RetrieveMisVehiculos(vehiculo);
                apiResp.Data = list;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        public IHttpActionResult Post(Vehiculo vehiculo)
        {
            try
            {
                var mng = new VehiculoManager();
                mng.Create(vehiculo);
                apiResp = new ApiResponse();
                apiResp.Message = "Vehiculo creado correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Vehiculo vehiculo)
        {
            try
            {
                var mng = new VehiculoManager();
                mng.Update(vehiculo);
                apiResp = new ApiResponse();
                apiResp.Message = "Vehiculo actualizado correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Vehiculo vehiculo)
        {
            try
            {
                var mng = new VehiculoManager();
                mng.Delete(vehiculo);
                apiResp = new ApiResponse();
                apiResp.Message = "Vehiculo eliminado correctamente";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}


