using DataAccess.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using System.Security.Cryptography;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CoreAPI
{
    public class UsuarioManager : BaseManager
    {
        private UsuarioCrudFactory crudUsuario;
        private BitacoraCrudFactory crudBitacora;

        public static string codigo;
        public UsuarioManager()
        {
            crudUsuario = new UsuarioCrudFactory();
            crudBitacora = new BitacoraCrudFactory();
        }
        public void Create(Usuario usuario)
        {
            try
            {
                if (CalcularEdad(usuario.FechaNacimiento) < 18)
                {

                    throw new BussinessException(2);
                }
                if (usuario.FechaNacimiento > DateTime.Now)
                {
                    throw new BussinessException(4);
                }

                var c = crudUsuario.Retrieve<Usuario>(usuario);
                if (c != null)
                {
                    UpdateCode(usuario);
                }
                else
                {
                    Encriptacion(usuario);
                    SendMessage(usuario);
                    crudUsuario.Create(usuario);
                    SendMailAsync(usuario);
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public static string CodeGenerator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }
        public static void SendMessage(Usuario usuario)
        {
            try
            {
                var accountSid = "AC2397b9e7a2ecb49f9feb96cdce35ba2f";
                var authToken = "326edf73082170b7846005cd82dc62bf";
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber($"+506{usuario.Telefono}"));

                messageOptions.From = new PhoneNumber("+19788383505");
                codigo = CodeGenerator();
                messageOptions.Body = codigo;
                usuario.CodigoVerificacion = messageOptions.Body;

                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(messageOptions.Body);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

        }
        public void SendMailAsync(Usuario usuario)
        {

            var client = new SendGridClient("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");
            var from = new EmailAddress("teamcococenfo@gmail.com");
            var subject = "Bienvenidos a Waffle";
            var to = new EmailAddress(usuario.Correo);
            var plainTextContent = "message";
            var htmlContent = "<div>" +
                "<p>El grupo de desarrolladores de coco te da la Bienvenida a Waffle</p>" +
                "<div>";
            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                plainTextContent,
                htmlContent);
            client.SendEmailAsync(msg);
        }
        public static void Encriptacion(Usuario usuario)
        {
            StringBuilder sb = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] md5HashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(usuario.Contrasena));
                foreach (byte b in md5HashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }
            }
            usuario.Contrasena = sb.ToString();
        }
        public List<Usuario> RetrieveAll()
        {
            return crudUsuario.RetrieveAll<Usuario>();
        }
        public List<Usuario> RetrieveTransportistas(Usuario usuario)
        {
            var lstTransportistas = new List<Usuario>();
            try
            {
                lstTransportistas = crudUsuario.RetrieveTransportistas<Usuario>(usuario);
                if (lstTransportistas == null)
                {
                    /*Aún no existen transportistas*/
                    throw new BussinessException(7);
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return lstTransportistas;
        }
        public int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Month > fechaActual.Month)
            {
                --edad;
            }
            return edad;
        }
        public Usuario RetrieveById(Usuario usuario)
        {
            Usuario u = null;
            try
            {
                u = crudUsuario.Retrieve<Usuario>(usuario);
                if (u == null)
                {
                    /*No se encuentran resultados de la búsqueda*/
                    throw new BussinessException(2);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return u;
        }
        public Usuario RetrieveCodigoUsuario(Usuario usuario)
        {
            Usuario u = null;
            try
            {
                u = crudUsuario.RetrieveCodigoUsuario<Usuario>(usuario);
                if (u == null)
                {
                    throw new BussinessException(1);
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return u;

        }
        public void Update(Usuario usuario)
        {
            Encriptacion(usuario);
            crudUsuario.Update(usuario);
        }
        public void Delete(Usuario usuario)
        {
            crudUsuario.Delete(usuario);
        }
        public void UpdateCode(Usuario usuario)
        {
            SendMessage(usuario);
            crudUsuario.UpdateCode(usuario);
        }
        public Usuario GetUsuario(Usuario usuario)
        {
            Usuario u = null;
            Encriptacion(usuario);
            try
            {
                u = crudUsuario.GetUsuario<Usuario>(usuario);
                if (u == null)
                {
                    throw new BussinessException(1);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return u;
        }

        public Usuario GetCorreo(Usuario usuario)
        {
            Usuario u = null;
            try
            {
                u = crudUsuario.GetCorreo<Usuario>(usuario);
                if (u == null)
                {
                    throw new BussinessException(2);
                }
                else
                {
                    UpdateCode(u);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return u;
        }
        public void UpdateContrasena(Usuario usuario)
        {
            var c = GetCorreo(usuario);
            if (c != null)
            {
                Encriptacion(usuario);
                Update(usuario);
            }
        }
        public void UpdateEstado(Usuario usuario)
        {
            Update(usuario);
        }
        public Usuario GetUsuarioCorreo(Usuario usuario)
        {
            Usuario u = null;
            try
            {
                u = crudUsuario.Retrieve<Usuario>(usuario);
                if (u == null)
                {
                    /*No se encuentran resultados de la búsqueda*/
                    throw new BussinessException(2);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return u;
        }
        public List<Usuario> RetrieveTransportistasSolicitudes(Usuario usuario)
        {
            var lstTransportistas = new List<Usuario>();
            try
            {
                lstTransportistas = crudUsuario.RetrieveTransportistasSolicitudes<Usuario>(usuario);
                if (lstTransportistas == null)
                {
                    /*Aún no existen transportistas*/
                    throw new BussinessException(7);
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return lstTransportistas;
        }
        //public void GetUpdateEstado(Usuario usuario)
        //{
        //    //crudMembresia.Update(membresia);
        //    //usuario.Estado = 'EST-RECHAZADO';
        //    crudUsuario.GetUpdateEstado(usuario);
        //    Bitacora bitacora = new Bitacora();
        //    bitacora.Usuario = "Administrador";
        //    bitacora.Accion = "Se rechazo la membresía del transportista";
        //    bitacora.FechaAccion = DateTime.Now;
        //    crudBitacora.Create(bitacora);
        //}
        public List<Usuario> GetTransportistasEstado(Usuario usuario)
        {
            var lstTransportistas = new List<Usuario>();
            try
            {
                lstTransportistas = crudUsuario.GetTransportistasEstado<Usuario>(usuario);
                if (lstTransportistas == null)
                {
                    throw new BussinessException(5);
                } 

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return lstTransportistas;
        }
    }
}

