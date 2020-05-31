using WebAPI.Models;
using CoreAPI;
using Entities;
using Exceptions;
using System;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class CategoriaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        //GET api/categoria
        //Retrieve
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new CategoriaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }
        // GET api/categoria
        // Retrieve by id
        public IHttpActionResult Get(int idCategoria)
        {
            try
            {
                var mng = new CategoriaManager();
                var categoria = new Categoria
                {
                    IdCategoria = idCategoria
                };
                categoria = mng.RetrieveById(categoria);
                apiResp = new ApiResponse();
                apiResp.Data = categoria;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // POST
        // CREATE 
        public IHttpActionResult Post(Categoria categoria)
        {
            try
            {
                var mng = new CategoriaManager();
                mng.Create(categoria);
                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada.";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // PUT 
        // UPDATE
        public IHttpActionResult Put(Categoria categoria)
        {
            try
            {
                var mng = new CategoriaManager();
                mng.Update(categoria);
                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada.";
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // DELETE ==
        public IHttpActionResult Delete(Categoria categoria)
        {
            try
            {
                var mng = new CategoriaManager();
                mng.Delete(categoria);

                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));

            }
        }
    }
}