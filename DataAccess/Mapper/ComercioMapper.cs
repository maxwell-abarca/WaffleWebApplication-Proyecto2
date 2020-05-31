using DataAccess.Dao;
using Entities;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class ComercioMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        public const string DB_COL_CEDULA_JURIDICA = "CEDULA_JURIDICA";
        public const string DB_COL_CEDULA_DUENO = "CEDULA_DUENO";
        public const string DB_COL_ID_CADENA = "ID_CADENA";
        public const string DB_COL_ID_CATEGORIA = "ID_CATEGORIA";
        public const string DB_COL_ID_DIRECCION = "ID_DIRECCION";
        public const string DB_COL_NOMBRE_COMERCIAL = "NOMBRE_COMERCIAL";
        public const string DB_COL_REGIMEN_TRIBUTARIO = "REGIMEN_TRIBUTARIO";
        public const string DB_COL_TELEFONO = "TELEFONO";
        public const string DB_COL_DIRECCION_ESCRITA = "DIRECCION_ESCRITA";
        public const string DB_COL_HORA_APERTURA = "HORA_APERTURA";
        public const string DB_COL_HORA_CIERRE = "HORA_CIERRE";
        public const string DB_COL_FECHA_CREACION = "FECHA_CREACION";
        public const string DB_COL_ESTADO = "ESTADO";
        public const string DB_COL_FOTO = "FOTO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_COMERCIO_PR" };
            var c = (Comercio)entity;
            operation.AddIntParam(DB_COL_CEDULA_JURIDICA, c.CedulaJuridica);
            operation.AddIntParam(DB_COL_CEDULA_DUENO, c.CedulaDueno);
            operation.AddIntParam(DB_COL_ID_CADENA, c.IdCadena);
            operation.AddIntParam(DB_COL_ID_CATEGORIA, c.IdCategoria);
            operation.AddIntParam(DB_COL_ID_DIRECCION, c.IdDireccion);
            operation.AddVarcharParam(DB_COL_NOMBRE_COMERCIAL, c.NombreComercial);
            operation.AddVarcharParam(DB_COL_REGIMEN_TRIBUTARIO, c.RegimenTributario);
            operation.AddVarcharParam(DB_COL_TELEFONO, c.Telefono);
            operation.AddVarcharParam(DB_COL_DIRECCION_ESCRITA, c.DireccionEscrita);
            operation.AddVarcharParam(DB_COL_HORA_APERTURA, c.HoraApertura);
            operation.AddVarcharParam(DB_COL_HORA_CIERRE, c.HoraCierre);
            operation.AddDateParam(DB_COL_FECHA_CREACION, c.FechaCreacion);
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddVarcharParam(DB_COL_FOTO, c.Foto);

            return operation;
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_COMERCIO_PR" };
            var c = (Comercio)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE_COMERCIAL, c.NombreComercial);
            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_COMERCIO_PR" };
            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_COMERCIO_PR" };
            var c = (Comercio)entity;
            operation.AddIntParam(DB_COL_ID_CADENA, c.IdCadena);
            operation.AddIntParam(DB_COL_ID_CATEGORIA, c.IdCategoria);
            //operation.AddIntParam(DB_COL_ID_DIRECCION, c.IdDireccion);
            operation.AddVarcharParam(DB_COL_NOMBRE_COMERCIAL, c.NombreComercial);
            operation.AddVarcharParam(DB_COL_REGIMEN_TRIBUTARIO, c.RegimenTributario);
            operation.AddVarcharParam(DB_COL_TELEFONO, c.Telefono);
            operation.AddVarcharParam(DB_COL_HORA_APERTURA, c.HoraApertura);
            operation.AddVarcharParam(DB_COL_HORA_CIERRE, c.HoraCierre);
            operation.AddVarcharParam(DB_COL_DIRECCION_ESCRITA, c.DireccionEscrita);
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddVarcharParam(DB_COL_FOTO, c.Foto);
            operation.AddIntParam(DB_COL_CEDULA_JURIDICA, c.CedulaJuridica);

            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_COMERCIO_PR" };
            var c = (Comercio)entity;
            operation.AddIntParam(DB_COL_CEDULA_JURIDICA, c.CedulaJuridica);
            operation.AddVarcharParam(DB_COL_NOMBRE_COMERCIAL, c.NombreComercial);
            return operation;
        }
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRow)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRow)
            {
                var comercio = BuildObject(row);
                lstResults.Add(comercio);
            }
            return lstResults;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var comercio = new Comercio
            {
                CedulaJuridica = GetIntValue(row, DB_COL_CEDULA_JURIDICA),
                CedulaDueno = GetIntValue(row, DB_COL_CEDULA_DUENO),
                IdCadena = GetIntValue(row, DB_COL_ID_CADENA),
                IdCategoria = GetIntValue(row, DB_COL_ID_CATEGORIA),
                IdDireccion = GetIntValue(row, DB_COL_ID_DIRECCION),
                NombreComercial = GetStringValue(row, DB_COL_NOMBRE_COMERCIAL),
                RegimenTributario = GetStringValue(row, DB_COL_REGIMEN_TRIBUTARIO),
                Telefono = GetStringValue(row, DB_COL_TELEFONO),
                DireccionEscrita = GetStringValue(row, DB_COL_DIRECCION_ESCRITA),
                HoraApertura = GetStringValue(row, DB_COL_HORA_APERTURA),
                HoraCierre = GetStringValue(row, DB_COL_HORA_CIERRE),
                FechaCreacion = GetDateValue(row, DB_COL_FECHA_CREACION),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                Foto = GetStringValue(row, DB_COL_FOTO)
            };
            return comercio;
        }
        public SqlOperation GetSolicitudesComercios(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_COMERCIO_SOLICITUDES_PR" };
            var c = (Comercio)entity;                       
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);
            return operation;
        }
        public SqlOperation GetUpdateEstado(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_COMERCIO_ESTADO_PR" };
            var c = (Comercio)entity;
            operation.AddIntParam(DB_COL_CEDULA_JURIDICA, c.CedulaJuridica);
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);

            return operation;
        }

        public SqlOperation GetComercios(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_COMERCIOS_DUENO_PR" };
            var c = (Comercio)entity;
            operation.AddIntParam(DB_COL_CEDULA_DUENO, c.CedulaDueno);
            return operation;
        }
        public SqlOperation GetComerciosEstado(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_COMERCIOS_INACTIVOS_PR" };
            var c = (Comercio)entity;
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);
            return operation;
        }
    }
}
