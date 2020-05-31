using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Direccion : BaseEntity
    {

        public int ID { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }


        public Direccion()
        {

        }
        public Direccion(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3)
            {
                var id = 0;
                if (Int32.TryParse(infoArray[0], out id))
                    ID = id;
                else
                    throw new Exception("El id debe de ser un número");

                var lat = 0.0;
                if (double.TryParse(infoArray[1], out lat))
                    Latitud = lat;
                else
                    throw new Exception("El id debe de ser un número decimal");

                var lon = 0.0;
                if (double.TryParse(infoArray[2], out lon))
                    Longitud = lon;
                else
                    throw new Exception("El id debe de ser un número decimal");

            }
            else
            {
                throw new Exception("Debe rellenar los campos necesarios para el registro");
            }
        }
    }
}
