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
    public class ProductoController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/producto
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new ProductoManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }
        // GET api/producto/5
        // Retrieve by id
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new ProductoManager();
                var producto = new Producto
                {
                    NombreProducto = id
                };

                producto = mng.RetrieveById(producto);
                apiResp = new ApiResponse();
                apiResp.Data = producto;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Producto producto)
        {
            try
            {
                var mng = new ProductoManager();
                mng.Create(producto);
                apiResp = new ApiResponse();
                apiResp.Message = "Acción ejecutada.";
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
        public IHttpActionResult Put(Producto producto)
        {
            try
            {
                var mng = new ProductoManager();
                mng.Update(producto);

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
        public IHttpActionResult Delete(Producto producto)
        {
            try
            {
                var mng = new ProductoManager();
                mng.Delete(producto);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }
        public IHttpActionResult GetProductosComercio(int cedulaComercio)
        {
            try
            {
                var mng = new ProductoManager();
                var list = new List<Producto>();
                var producto = new Producto
                {
                    CedulaComercio = cedulaComercio
                };
                list = mng.GetProductosComercio(producto);
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
