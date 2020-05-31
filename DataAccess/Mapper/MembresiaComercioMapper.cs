using DataAccess.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class MembresiaComercioMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_ID_MEMBRESIA = "ID_MEMBRESIA";
        private const string DB_COL_CEDULA_COMERCIO = "CEDULA_COMERCIO";
        private const string DB_COL_CEDULA_DUENO = "CEDULA_DUENO";
        private const string DB_COL_MONTO_MEMBRESIA = "MONTO_MEMBRESIA";
        private const string DB_COL_FECHA_INICIO = "FECHA_INICIO";
        private const string DB_COL_FECHA_FIN = "FECHA_FIN";
        private const string DB_COL_COMISION = "COMISION";
        private const string DB_COL_IMPUESTO = "IMPUESTO";
        private const string DB_COL_CORREO= "CORREO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_MEMBRESIA_COMERCIO_PR" };

            var m = (MembresiaComercio)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, m.IdMembresia);
            operation.AddIntParam(DB_COL_CEDULA_COMERCIO, m.CedulaJuridica);
            operation.AddIntParam(DB_COL_CEDULA_DUENO, m.CedulaDueno);
            operation.AddIntParam(DB_COL_MONTO_MEMBRESIA, m.MontoMembresia);
            operation.AddDateParam(DB_COL_FECHA_INICIO, m.FechaAprobacion);
            operation.AddDateParam(DB_COL_FECHA_FIN, m.FechaExpiracion);
            operation.AddIntParam(DB_COL_COMISION, m.Comision);
            operation.AddIntParam(DB_COL_IMPUESTO, m.Impuesto);
            operation.AddVarcharParam(DB_COL_CORREO, m.Correo);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_MEMBRESIA_COMERCIO_PR" };

            var m = (MembresiaComercio)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, m.IdMembresia);
            operation.AddIntParam(DB_COL_CEDULA_COMERCIO, m.CedulaJuridica);
            operation.AddIntParam(DB_COL_MONTO_MEMBRESIA, m.MontoMembresia);
            operation.AddDateParam(DB_COL_FECHA_INICIO, m.FechaAprobacion);
            operation.AddDateParam(DB_COL_FECHA_FIN, m.FechaExpiracion);
            operation.AddIntParam(DB_COL_COMISION, m.Comision);
            operation.AddIntParam(DB_COL_IMPUESTO, m.Impuesto);
            operation.AddVarcharParam(DB_COL_CORREO, m.Correo);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MEMBRESIA_COMERCIO_PR" };
            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_MEMBRESIA_COMERCIO_PR" };

            var m = (MembresiaComercio)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, m.IdMembresia);
            operation.AddIntParam(DB_COL_CEDULA_COMERCIO, m.CedulaJuridica);
            operation.AddIntParam(DB_COL_MONTO_MEMBRESIA, m.MontoMembresia);
            operation.AddDateParam(DB_COL_FECHA_INICIO, m.FechaAprobacion);
            operation.AddDateParam(DB_COL_FECHA_FIN, m.FechaExpiracion);
            operation.AddIntParam(DB_COL_COMISION, m.Comision);
            operation.AddIntParam(DB_COL_IMPUESTO, m.Impuesto);
            operation.AddVarcharParam(DB_COL_CORREO, m.Correo);

            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_MEMBRESIA_COMERCIO_PR" };

            var m = (MembresiaComercio)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, m.IdMembresia);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var producto = BuildObject(row);
                lstResults.Add(producto);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var membresia = new MembresiaComercio
            {
                IdMembresia = GetIntValue(row, DB_COL_ID_MEMBRESIA),
                CedulaJuridica = GetIntValue(row, DB_COL_CEDULA_COMERCIO),
                CedulaDueno = GetIntValue(row, DB_COL_CEDULA_DUENO),
                MontoMembresia = GetIntValue(row, DB_COL_MONTO_MEMBRESIA),
                FechaAprobacion = GetDateValue(row, DB_COL_FECHA_INICIO),
                FechaExpiracion = GetDateValue(row, DB_COL_FECHA_FIN),
                Comision = GetIntValue(row, DB_COL_COMISION),
                Impuesto = GetIntValue(row, DB_COL_IMPUESTO),
                Correo = GetStringValue(row, DB_COL_CORREO)
            };
            return membresia;
        }
    }
}