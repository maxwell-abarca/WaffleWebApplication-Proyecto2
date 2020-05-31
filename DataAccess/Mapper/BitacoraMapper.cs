using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities;

namespace DataAccess.Mapper
{
    public class BitacoraMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_USUARIO = "USUARIO";
        private const string DB_COL_ACCION = "ACCION";
        private const string DB_COL_FECHA_ACCION = "FECHA_ACCION";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_BITACORA_PR" };

            var b = (Bitacora)entity;
            operation.AddVarcharParam(DB_COL_USUARIO, b.Usuario);
            operation.AddVarcharParam(DB_COL_ACCION, b.Accion);
            operation.AddDateParam(DB_COL_FECHA_ACCION, b.FechaAccion);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_BITACORA_PR" };

            var b = (Bitacora)entity;
            operation.AddVarcharParam(DB_COL_USUARIO, b.Usuario);
            operation.AddVarcharParam(DB_COL_ACCION, b.Accion);
            operation.AddDateParam(DB_COL_FECHA_ACCION, b.FechaAccion);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_BITACORA_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_BITACORA_PR" };

            var b = (Bitacora)entity;
            operation.AddVarcharParam(DB_COL_USUARIO, b.Usuario);
            operation.AddVarcharParam(DB_COL_ACCION, b.Accion);
            operation.AddDateParam(DB_COL_FECHA_ACCION, b.FechaAccion);

            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_BITACORA_PR" };

            var b = (Bitacora)entity;
            operation.AddVarcharParam(DB_COL_USUARIO, b.Usuario);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var bitacora = BuildObject(row);
                lstResults.Add(bitacora);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var bitacora = new Bitacora
            {
                Usuario = GetStringValue(row, DB_COL_USUARIO),
                Accion = GetStringValue(row, DB_COL_ACCION),
                FechaAccion = GetDateValue(row, DB_COL_FECHA_ACCION)
            };

            return bitacora;
        }
    }
}
