using System;

namespace Entities
{
    public class Comercio : BaseEntity
    {
        public int CedulaJuridica { get; set; }
        public int CedulaDueno { get; set; }
        public int IdCadena { get; set; }
        public int IdCategoria { get; set; }
        public int IdDireccion { get; set; }
        public string NombreComercial { get; set; }
        public string RegimenTributario { get; set; }
        public string Telefono { get; set; }
        public string DireccionEscrita { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public string Foto { get; set; } 
        public double Latitud { get; set; } 
        public double Longitud { get; set; } 
        public Comercio()
        {

        }
        public Comercio(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 11)
            {
                var cedulaJuridica = 0;
                if (Int32.TryParse(infoArray[0], out cedulaJuridica))
                    CedulaJuridica = cedulaJuridica;
                else
                    throw new Exception("La cédula juridica debe de ser un número");
                var cedulaDueno = 0;
                if (Int32.TryParse(infoArray[1], out cedulaDueno))
                    CedulaDueno = cedulaDueno;
                else
                    throw new Exception("La cédula del dueño del comercio debe de ser un número");
                var idCategoria = 0;
                if (Int32.TryParse(infoArray[2], out idCategoria))
                    IdCategoria = idCategoria;
                else
                    throw new Exception("La categoria del comercio debe de ser un número");
                /*  var idDireccion = 0;
                  if (Int32.TryParse(infoArray[3], out idDireccion))
                      IdDireccion = idDireccion;
                  else
                      throw new Exception("La direccion del comercio debe de ser el id de la direccion");*/
                infoArray[3] = NombreComercial;
                infoArray[4] = RegimenTributario;
                infoArray[5] = Telefono;
                infoArray[6] = DireccionEscrita;
                infoArray[7] = HoraApertura;
                infoArray[8] = HoraCierre;
                DateTime creacion;
                if (DateTime.TryParse(infoArray[10], out creacion))
                    FechaCreacion = creacion;
                else
                    throw new Exception("Error en la fecha de creación");
                infoArray[9] = Estado;
                infoArray[10] = Foto;
            }
            else
            {
                throw new Exception("Debe rellenar los campos necesarios para el registro");
            }

        }


    }
}
