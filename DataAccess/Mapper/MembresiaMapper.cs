using DataAccess.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class MembresiaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_ID_MEMBRESIA = "ID_MEMBRESIA";
        private const string DB_COL_CEDULA_USUARIO = "CEDULA_USUARIO";
        private const string DB_COL_MONTO_MEMBRESIA = "MONTO_MEMBRESIA";
        private const string DB_COL_FECHA_INICIO = "FECHA_INICIO";
        private const string DB_COL_FECHA_FIN = "FECHA_FIN";
        private const string DB_COL_COMISION_BASE = "COMISION_BASE";
        private const string DB_COL_MONTO_KILOMETRAJE = "MONTO_KILOMETRAJE";
        private const string DB_COL_IMPUESTO = "IMPUESTO";
        private const string DB_COL_TIPO_MEMBRESIA = "TIPO_MEMBRESIA";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_MEMBRESIA_TRANSPORTISTA_PR" };

            var m = (Membresia)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, m.IdMembresia);
            operation.AddIntParam(DB_COL_CEDULA_USUARIO, m.Cedula);
            operation.AddIntParam(DB_COL_MONTO_MEMBRESIA, m.MontoMembresia);
            operation.AddDateParam(DB_COL_FECHA_INICIO, m.FechaAprobacion);
            operation.AddDateParam(DB_COL_FECHA_FIN, m.FechaExpiracion);
            operation.AddIntParam(DB_COL_COMISION_BASE, m.ComisionBase);
            operation.AddIntParam(DB_COL_MONTO_KILOMETRAJE, m.MontoKilometraje);
            operation.AddIntParam(DB_COL_IMPUESTO, m.Impuesto);
            operation.AddVarcharParam(DB_COL_TIPO_MEMBRESIA, m.Correo);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_MEMBRESIA_TRANSPORTISTA_PR" };

            var m = (Membresia)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, m.IdMembresia);
            operation.AddIntParam(DB_COL_CEDULA_USUARIO, m.Cedula);
            operation.AddIntParam(DB_COL_MONTO_MEMBRESIA, m.MontoMembresia);
            operation.AddDateParam(DB_COL_FECHA_INICIO, m.FechaAprobacion);
            operation.AddDateParam(DB_COL_FECHA_FIN, m.FechaExpiracion);
            operation.AddIntParam(DB_COL_COMISION_BASE, m.ComisionBase);
            operation.AddIntParam(DB_COL_MONTO_KILOMETRAJE, m.MontoKilometraje);
            operation.AddIntParam(DB_COL_IMPUESTO, m.Impuesto);
            operation.AddVarcharParam(DB_COL_TIPO_MEMBRESIA, m.Correo);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MEMBRESIA_TRANSPORTISTA_PR" };
            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_MEMBRESIA_TRANSPORTISTA_PR" };

            var m = (Membresia)entity;
            operation.AddIntParam(DB_COL_ID_MEMBRESIA, m.IdMembresia);
            operation.AddIntParam(DB_COL_CEDULA_USUARIO, m.Cedula);
            operation.AddIntParam(DB_COL_MONTO_MEMBRESIA, m.MontoMembresia);
            operation.AddDateParam(DB_COL_FECHA_INICIO, m.FechaAprobacion);
            operation.AddDateParam(DB_COL_FECHA_FIN, m.FechaExpiracion);
            operation.AddIntParam(DB_COL_COMISION_BASE, m.ComisionBase);
            operation.AddIntParam(DB_COL_MONTO_KILOMETRAJE, m.MontoKilometraje);
            operation.AddIntParam(DB_COL_IMPUESTO, m.Impuesto);
            operation.AddVarcharParam(DB_COL_TIPO_MEMBRESIA, m.Correo);

            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_MEMBRESIA_TRANSPORTISTA_PR" };

            var m = (Membresia)entity;
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
            var membresia = new Membresia
            {
                IdMembresia = GetIntValue(row, DB_COL_ID_MEMBRESIA),
                Cedula = GetIntValue(row, DB_COL_CEDULA_USUARIO),
                MontoMembresia = GetIntValue(row, DB_COL_MONTO_MEMBRESIA),
                FechaAprobacion = GetDateValue(row, DB_COL_FECHA_INICIO),
                FechaExpiracion = GetDateValue(row, DB_COL_FECHA_FIN),
                ComisionBase = GetIntValue(row, DB_COL_COMISION_BASE),
                MontoKilometraje = GetIntValue(row, DB_COL_MONTO_KILOMETRAJE),
                Impuesto = GetIntValue(row, DB_COL_IMPUESTO),
                Correo = GetStringValue(row, DB_COL_TIPO_MEMBRESIA)
            };
            return membresia;
        }
    }
}