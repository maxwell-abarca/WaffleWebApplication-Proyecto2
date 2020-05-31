using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cadena : BaseEntity
    {
        public int ID { get; set; }
        public int CedulaDueno { get; set; }
        public string Nombre { get; set; }
        public string Logo { get; set; }


        public Cadena()
        {

        }
        public Cadena(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 4)
            {
                var id = 0;
                if (Int32.TryParse(infoArray[0], out id))
                    ID = id;
                else
                    throw new Exception("El id debe de ser un número");
                var cedula = 0;
                if (Int32.TryParse(infoArray[1], out cedula))
                    CedulaDueno = cedula;
                else
                    throw new Exception("La cédula debe de ser un número");
                Nombre = infoArray[2];
                Logo = infoArray[3];
            }
            else
            {
                throw new Exception("Debe rellenar los campos necesarios para el registro");
            }
        }
    }
}
