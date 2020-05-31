using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Flotilla : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CedulaDueno { get; set; }



        public Flotilla()
        {

        }
        public Flotilla(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                int id = 0;
                if (Int32.TryParse(infoArray[0], out id))
                    Id = id;
                else
                    throw new Exception("El id debe de ser númeral");
                infoArray[1] = Nombre;
                int cedulaDueno = 0;
                if (Int32.TryParse(infoArray[2], out cedulaDueno))
                    CedulaDueno = cedulaDueno;
                else
                    throw new Exception("La cédula debe de ser numeral");
            }
            else
            {
                throw new Exception("Debe rellenar los campos necesarios");
            }
        }
    }
}


