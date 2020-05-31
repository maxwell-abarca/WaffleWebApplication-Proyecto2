using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario : BaseEntity
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Correo { get; set; }

        public string Contrasena { get; set; }

        public string Telefono { get; set; }
        public string FotoPerfil { get; set; }
        public string Estado { get; set; }

        public string TipoIdentificacion { get; set; }

        public string CodigoVerificacion { get; set; }

        public int IdRol { get; set; }

        public Usuario()
        {

        }
        public Usuario(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 14)
            {
                var cedula = 0;
                if (Int32.TryParse(infoArray[0], out cedula))
                    Cedula = cedula;
                else
                    throw new Exception("La cédula debe de ser numeral");
                Nombre = infoArray[1];
                PrimerApellido = infoArray[2];
                SegundoApellido = infoArray[3];
                DateTime fechaNacimiento;

                if (DateTime.TryParse(infoArray[4], out fechaNacimiento))
                    FechaNacimiento = fechaNacimiento;
                else
                    throw new Exception("El formato de la fecha es erróneo");
                Correo = infoArray[5];
                Contrasena = infoArray[6];
                Telefono = infoArray[7];

                FotoPerfil = infoArray[8];
                Estado = infoArray[9];
                TipoIdentificacion = infoArray[10];
                CodigoVerificacion = infoArray[11];

            }
            else
            {
                throw new Exception("Debe llenar los campos necesarios para el registro");
            }
        }
    }
}
