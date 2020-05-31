using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Promocion : BaseEntity
    {
        public string Codigo { get; set; }

        public string IdProducto { get; set; }


        public double Descuento { get; set; }

        public string Estado { get; set; }

        public int IdComercio { get; set; }
        public string NombreProducto { get; set; }

        public Promocion()
        {

        }
        public Promocion(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3)
            {
                infoArray[0] = Codigo;
                infoArray[1] = IdProducto;

                double descuento = 0;
                if (Double.TryParse(infoArray[2], out descuento))
                    Descuento = descuento;
                else
                    throw new Exception("El descuento debe de ser un valor numeral");
                infoArray[2] = Estado;
                int idComercio = 0;
                if (Int32.TryParse(infoArray[3], out idComercio))
                    IdComercio = idComercio;
                else
                    throw new Exception("El id del comercio debe de ser numeral");
                infoArray[4] = NombreProducto;
            }
            else
            {
                throw new Exception("Debe rellenar los campos necesarios para el registro");
            }
        }

    }
}
