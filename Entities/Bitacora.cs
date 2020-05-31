using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bitacora : BaseEntity
    {
        public string Usuario { get; set; }
        public string Accion { get; set; }
        public DateTime FechaAccion { get; set; }

        public Bitacora()
        {

        }
        public Bitacora(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3)
            {
                Usuario = infoArray[0];
                Accion = infoArray[1];
                DateTime fecha;
                if (DateTime.TryParse(infoArray[2], out fecha))
                    FechaAccion = fecha;
                else
                    throw new Exception("Fecha debe ser en formato DD/MM/YYYY");
            }
            else
            {
                throw new Exception("All values are require[id,cedulaUsuario,accion,fechaAccion]");
            }
        }
    }
}
