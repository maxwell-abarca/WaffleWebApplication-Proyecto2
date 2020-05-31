using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Vehiculo : BaseEntity
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string TipoVehiculo { get; set; }
        public int CedulaDueno { get; set; }
        public int IdFlotilla { get; set; }

        public string Nombre { get; set; }

        public Vehiculo()
        {

        }
        public Vehiculo(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 6)
            {
                infoArray[1] = Placa;
                infoArray[2] = Marca;
                infoArray[3] = Modelo;
                infoArray[4] = TipoVehiculo;
                int cedulaDueno = 0;
                if (Int32.TryParse(infoArray[5], out cedulaDueno))
                    CedulaDueno = cedulaDueno;
                else
                    throw new Exception("La cédula del dueño debe de ser numeral");

                int idFlotilla = 0;
                if (Int32.TryParse(infoArray[5], out idFlotilla))
                    IdFlotilla = idFlotilla;
                else
                    throw new Exception("La identificacdor de la flotilla debe de ser numeral");
                infoArray[5] = Nombre;
            }
            else
            {
                throw new Exception("Debe rellenar los campos necesarios para el registro del vehiculo");
            }


        }


    }
}
