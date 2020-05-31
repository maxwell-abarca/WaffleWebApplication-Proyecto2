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
    public class TransportistaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult GetTransportistasSolicitudes(int idRol)
        {
            try
            {
                var mng = new UsuarioManager();
                var list = new List<Usuario>();
                var usuario = new Usuario
                {
                    IdRol = idRol
                };
                list = mng.RetrieveTransportistasSolicitudes(usuario);
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