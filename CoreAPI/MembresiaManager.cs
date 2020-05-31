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
    public class MembresiaManager : BaseManager
    {
        private MembresiaCrudFactory crudMembresia;
        private BitacoraCrudFactory crudBitacora;
        private UsuarioCrudFactory crudUsuario;

        public MembresiaManager()
        {
            crudMembresia = new MembresiaCrudFactory();
            crudBitacora = new BitacoraCrudFactory();
            crudUsuario = new UsuarioCrudFactory();
        }
        public void Create(Membresia membresia)
        {
            try
            {
                Usuario usuario = new Usuario();
                crudMembresia.Create(membresia);
                Bitacora bitacora = new Bitacora();
                bitacora.Usuario = "Administrador";
                bitacora.Accion = "Registro de la membresia del transportista";
                bitacora.FechaAccion = DateTime.Now;
                crudBitacora.Create(bitacora);
                SendMailAsync(membresia);
                //Usuario usuario = new Usuario();
                ////membresia.TipoMembresia = usuario.Correo;
                usuario.Cedula = membresia.Cedula;
                usuario.Estado = "EST_PROCESO";
                crudUsuario.UpdateEstado(usuario);     
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public List<Membresia> RetrieveAll()
        {
            return crudMembresia.RetrieveAll<Membresia>();
        }
        public Membresia RetrieveById(Membresia membresia)
        {
            Membresia m = null;
            try
            {
                m = crudMembresia.Retrieve<Membresia>(membresia);
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
        public void GetUpdateEstado(Usuario usuario)
        {
            //crudMembresia.Update(membresia);
            usuario.Estado = "EST_RECHAZADO";
            crudUsuario.GetUpdateEstado(usuario);
            Bitacora bitacora = new Bitacora();
            bitacora.Usuario = "Administrador";
            bitacora.Accion = "Se rechazo la membresía del transportista";
            bitacora.FechaAccion = DateTime.Now;
            crudBitacora.Create(bitacora);
        }
        public void Delete(Membresia membresia)
        {
            crudMembresia.Delete(membresia);
            Bitacora bitacora = new Bitacora();
            bitacora.Usuario = "Administrador";
            bitacora.Accion = "Eliminación de la membresia de un transportista";
            bitacora.FechaAccion = DateTime.Now;
            crudBitacora.Create(bitacora);
        }
        public void SendMailAsync(Membresia membresia)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("teamcococenfo@gmail.com");
            var subject = "Estado de la solicitud.";
            var to = new EmailAddress(membresia.Correo);
            var plainTextContent = "message";
           var htmlContent = "<div style=\"background-color: #FFF;\">" +
                "<div style=\"background-image: url(/Content/img/Logo.png)\";>" + "</div>"  +
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
