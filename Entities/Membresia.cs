using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Membresia : BaseEntity
    {
        public int IdMembresia { get; set; }
        public int Cedula { get; set; }
        public  int MontoMembresia { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int ComisionBase { get; set; }
        public int MontoKilometraje { get; set; }
        public int Impuesto { get; set; }
        public string Correo { get; set; }

        public Membresia()
        {

        }
        public Membresia(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 9)
            {
                var idMembresia = 0;
                if (Int32.TryParse(infoArray[0], out idMembresia))
                    IdMembresia = idMembresia;
                else
                    throw new Exception("El id membresia debe de ser un número.");
                var cedulaUsuario = 0;
                if (Int32.TryParse(infoArray[1], out cedulaUsuario))
                    Cedula = cedulaUsuario;
                else
                    throw new Exception("La cedula del usuario debe de ser un número.");
                var monto = 0;
                if (Int32.TryParse(infoArray[2], out monto))
                    MontoMembresia = monto;
                else
                    throw new Exception("El monto debe de ser un número.");
                DateTime fechaAprobacion;
                if (DateTime.TryParse(infoArray[3], out fechaAprobacion))
                    FechaAprobacion = fechaAprobacion;
                else
                    throw new Exception("Fecha debe ser en formato DD/MM/YYYY");
                DateTime fechaExpiracion;
                if (DateTime.TryParse(infoArray[4], out fechaExpiracion))
                    FechaExpiracion = fechaExpiracion;
                else
                    throw new Exception("Fecha debe ser en formato DD/MM/YYYY");
                var comisionBase = 0;
                if (Int32.TryParse(infoArray[5], out comisionBase))
                    ComisionBase = comisionBase;
                else
                    throw new Exception("La comision base debe de ser un número.");
                var comisionKilometraje = 0;
                if (Int32.TryParse(infoArray[6], out comisionKilometraje))
                    MontoKilometraje = comisionKilometraje;
                else
                    throw new Exception("La comision kilometraje debe de ser un número.");
                var impuesto = 0;
                if (Int32.TryParse(infoArray[7], out impuesto))
                    Impuesto = impuesto;
                else
                    throw new Exception("El impuesto debe de ser un número.");
                Correo = infoArray[8];

            }
            else
            {
                throw new Exception("Todos los valores son requeridos.");
            }

        }
    }
}
