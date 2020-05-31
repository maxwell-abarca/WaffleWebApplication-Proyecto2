using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Categoria : BaseEntity
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }

        public Categoria()
        {

        }

        public Categoria(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                var idCategoria = 0;
                if (Int32.TryParse(infoArray[0], out idCategoria))
                    IdCategoria = idCategoria;
                else
                    throw new Exception("La categoria del comercio debe de ser un número");
                NombreCategoria = infoArray[1];
            }
            else
            {
                throw new Exception("Todos los campos deben estar llenos.");
            }
        }
    }
}
