using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities;

namespace DataAccess.Mapper
{
    public class DireccionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_LATITUD = "LATITUD";
        private const string DB_COL_LONGITUD = "LONGITUD";
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var dir = new Direccion
            {
                ID = GetIntValue(row, DB_COL_ID),
                Latitud = GetDoubleValue(row, DB_COL_LATITUD),
                Longitud = GetDoubleValue(row, DB_COL_LONGITUD)
            };

            return dir;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var dir = BuildObject(row);
                lstResults.Add(dir);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_DIRECCION_PROC" };

            var d = (Direccion)entity;
            operation.AddDoubleParam(DB_COL_LATITUD, d.Latitud);
            operation.AddDoubleParam(DB_COL_LONGITUD, d.Longitud);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_DIRECCION_PROC" };

            var d = (Direccion)entity;
            operation.AddIntParam(DB_COL_ID, d.ID);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_DIRECCION_PROC" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DIRECCION_PROC" };

            var d = (Direccion)entity;
            operation.AddDoubleParam(DB_COL_LATITUD, d.Latitud);
            operation.AddDoubleParam(DB_COL_LONGITUD, d.Longitud);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_DIRECCION_PROC" };

            var d = (Direccion)entity;
            operation.AddDoubleParam(DB_COL_LATITUD, d.Latitud);
            operation.AddDoubleParam(DB_COL_LONGITUD, d.Longitud);

            return operation;
        }
        public SqlOperation GetRetrive(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DIRECCION_PR" };
            var d = (Direccion)entity;
            operation.AddIntParam(DB_COL_ID, d.ID);
            return operation;
        }
    }
}
