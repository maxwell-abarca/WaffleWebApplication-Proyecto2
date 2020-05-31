using CoreAPI;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class MembresiaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/membresia
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new MembresiaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }
        // GET api/membresia/5
        // Retrieve by id
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new MembresiaManager();
                var membresia = new Membresia
                {
                    IdMembresia = id
                };

                membresia = mng.RetrieveById(membresia);
                apiResp = new ApiResponse();
                apiResp.Data = membresia;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // POST 
        // CREATE
        public IHttpActionResult Post(Membresia membresia)
        {
            try
            {
                var mng = new MembresiaManager();
                mng.Create(membresia);

                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada correctamente.";

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
        public IHttpActionResult Put(Usuario usuario)
        {
            try
            {
                var mng = new MembresiaManager();
                mng.GetUpdateEstado(usuario);

                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(Membresia membresia)
        {
            try
            {
                var mng = new MembresiaManager();
                mng.Delete(membresia);

                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
