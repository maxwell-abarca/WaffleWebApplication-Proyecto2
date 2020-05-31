using DataAccess.Crud;
using Entities;
using Exceptions;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class MembresiaComercioManager : BaseManager
    {
        private MembresiaComercioCrudFactory crudMembresia;
        private BitacoraCrudFactory crudBitacora;
        private ComercioCrudFactory crudComercio;
        private UsuarioCrudFactory crudUsuario;

        public MembresiaComercioManager()
        {
            crudMembresia = new MembresiaComercioCrudFactory();
            crudBitacora = new BitacoraCrudFactory();
            crudComercio = new ComercioCrudFactory();
            crudUsuario = new UsuarioCrudFactory();
        }
        public void Create(MembresiaComercio membresia)
        {
            try
            {
                Comercio comercio = new Comercio();
                Usuario usuario = new Usuario();
                Usuario u = null;
                usuario.Cedula = membresia.CedulaDueno;
                u = crudUsuario.GetRetriveCedula<Usuario>(usuario);
                if (u == null)
                {
                    /*No se encuentran resultados de la búsqueda*/
                    throw new BussinessException(2);
                }
                membresia.Correo = u.Correo;
                crudMembresia.Create(membresia);
                Bitacora bitacora = new Bitacora();
                bitacora.Usuario = "Administrador";
                bitacora.Accion = "Registro de la membresia de un comercio";
                bitacora.FechaAccion = DateTime.Now;
                crudBitacora.Create(bitacora);
                SendMailAsync(membresia);
                comercio.CedulaJuridica = membresia.CedulaJuridica;
                comercio.Estado = "EST_PROCESO";               
                crudComercio.GetUpdateEstado(comercio);
            }                            
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public List<MembresiaComercio> RetrieveAll()
        {
            return crudMembresia.RetrieveAll<MembresiaComercio>();
        }
        public MembresiaComercio RetrieveById(MembresiaComercio membresia)
        {
            MembresiaComercio m = null;
            try
            {
                m = crudMembresia.Retrieve<MembresiaComercio>(membresia);
                if (m == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return m;
        }
        public void GetUpdateEstado(Comercio comercio)
        {
            //crudMembresia.Update(membresia);
            comercio.Estado = "EST_RECHAZADO";
            crudComercio.GetUpdateEstado(comercio);
            Bitacora bitacora = new Bitacora();
            bitacora.Usuario = "Administrador";
            bitacora.Accion = "Se rechazo la membresía del comercio";
            bitacora.FechaAccion = DateTime.Now;
            crudBitacora.Create(bitacora);
        }
        public void Delete(MembresiaComercio membresia)
        {
            crudMembresia.Delete(membresia);
            Bitacora bitacora = new Bitacora();
            bitacora.Usuario = "Administrador";
            bitacora.Accion = "Eliminación de la membresia de un comercio";
            bitacora.FechaAccion = DateTime.Now;
            crudBitacora.Create(bitacora);
        }
        public void SendMailAsync(MembresiaComercio membresia)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("teamcococenfo@gmail.com");
            var subject = "Estado de la solicitud.";
            var to = new EmailAddress(membresia.Correo);
            var plainTextContent = "message";
            var htmlContent = "<div style=\"background-color: #FFF;\">" +
                 "<div style=\"background-image: url(/Content/img/Logo.png)\";>" + "</div>" +
                  "<h1 style=\"font-size: 20px;\">Bienvenido a Waffle</h1>" +
                  "<p> Gracias por crear una cuenta con nosotros.</p>" +
                  "<p style=\"font-size: 10px;\"> Su solicitud ha sido aprobada.</p>" +
                  "<p style=\"font-size: 15px; color: #F1C40F;\"> Si quiere ingresar a nuestra plataforma ingrese al link que se muestra a continuación.</p>" +
                  "<a href = 'http://localhost:44301/'>Waffle</a>" +
                  "<div>";
            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                plainTextContent,
                htmlContent);
            client.SendEmailAsync(msg);
        }
    }
}
