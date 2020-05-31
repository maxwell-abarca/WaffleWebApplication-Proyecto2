using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MembresiaComercio : BaseEntity
    {
        public int IdMembresia { get; set; }
        public int CedulaJuridica { get; set; }
        public int CedulaDueno { get; set; }
        public int MontoMembresia { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int Comision { get; set; }
        public int Impuesto { get; set; }
        public string Correo { get; set; }

        public MembresiaComercio()
        {

        }
        public MembresiaComercio(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 9)
            {
                var idMembresia = 0;
                if (Int32.TryParse(infoArray[0], out idMembresia))
                    IdMembresia = idMembresia;
                else
                    throw new Exception("El id membresia debe de ser un número.");
                var cedulaComercio = 0;
                if (Int32.TryParse(infoArray[1], out cedulaComercio))
                    CedulaJuridica = cedulaComercio;
                else
                    throw new Exception("La cedula del comercio debe de ser un número.");
                var cedulaDueno = 0;
                if (Int32.TryParse(infoArray[2], out cedulaDueno))
                    CedulaDueno = cedulaDueno;
                else
                    throw new Exception("La cedula del usuario debe de ser un número.");
                var monto = 0;
                if (Int32.TryParse(infoArray[3], out monto))
                    MontoMembresia = monto;
                else
                    throw new Exception("El monto debe de ser un número.");
                DateTime fechaAprobacion;
                if (DateTime.TryParse(infoArray[4], out fechaAprobacion))
                    FechaAprobacion = fechaAprobacion;
                else
                    throw new Exception("Fecha debe ser en formato DD/MM/YYYY");
                DateTime fechaExpiracion;
                if (DateTime.TryParse(infoArray[5], out fechaExpiracion))
                    FechaExpiracion = fechaExpiracion;
                else
                    throw new Exception("Fecha debe ser en formato DD/MM/YYYY");
                var comisionBase = 0;
                if (Int32.TryParse(infoArray[6], out comisionBase))
                    Comision = comisionBase;
                else
                    throw new Exception("La comision debe de ser un número.");
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