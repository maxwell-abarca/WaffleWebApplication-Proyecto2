using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Producto : BaseEntity
    {
        public string IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdCategoria { get; set; }
        public int Precio { get; set; }
        public string Imagen { get; set; }
        public int CedulaComercio { get; set; }
        public string Estado { get; set; }

        public Producto()
        {

        }
        public Producto(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 7)
            {
                IdProducto = infoArray[0];
                NombreProducto = infoArray[1];
                var idCategoria = 0;
                if (Int32.TryParse(infoArray[2], out idCategoria))
                    IdCategoria = idCategoria;
                else
                    throw new Exception("La categoria debe de ser un numero");
                var precio = 0;
                if (Int32.TryParse(infoArray[3], out precio))
                    Precio = precio;
                else
                    throw new Exception("El precio debe de ser un numero");
                Imagen = infoArray[4];
                var idComercio = 0;
                if (Int32.TryParse(infoArray[5], out precio))
                    CedulaComercio = idComercio;
                else
                    throw new Exception("Debe de ser un numero");
                Estado = infoArray[6];
            }
            else
            {
                throw new Exception("Requerido[idProducti,NombreProducto,IdCategoria,precio,IdComercio,Estado]");
            }
        }
    }
}
