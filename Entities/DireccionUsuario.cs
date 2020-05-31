using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DireccionUsuario : BaseEntity
    {
        public int Id { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int IdUsuario { get; set; }

        public DireccionUsuario()
        {

        }
        public DireccionUsuario(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 4)
            {
                int id = 0;
                if (Int32.TryParse(infoArray[0], out id))
                    Id = id;
                else
                    throw new Exception("El id de la direccion debe de ser numeral");
                var latitud = 0.0;
                if (double.TryParse(infoArray[1], out latitud))
                    Latitud = latitud;
                else
                    throw new Exception("La latitud debe de ser decimal");
                var longitud = 0.0;
                if (double.TryParse(infoArray[2], out longitud))
                    Longitud = longitud;
                else
                    throw new Exception("La longitud debe de ser decimal");
                int idUsuario = 0;
                if (Int32.TryParse(infoArray[3], out idUsuario))
                    IdUsuario = idUsuario;
                else
                    throw new Exception("El id del usuario debe de ser numeral");
            }
            else
            {
                throw new Exception("Debe rellenar los campos necesarios para el registro");
            }

        }

    }
}
