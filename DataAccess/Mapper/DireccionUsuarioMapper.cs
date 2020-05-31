using DataAccess.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class DireccionUsuarioMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        public const string DB_COL_ID = "ID";
        public const string DB_COL_LATITUD = "LATITUD";
        public const string DB_COL_LONGITUD = "LONGITUD";
        public const string DB_COL_ID_USUARIO = "ID_USUARIO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_DIRECCION_USUARIO_PR" };
            var dUsuario = (DireccionUsuario)entity;
            operation.AddDoubleParam(DB_COL_LATITUD, dUsuario.Latitud);
            operation.AddDoubleParam(DB_COL_LONGITUD, dUsuario.Longitud);
            operation.AddIntParam(DB_COL_ID_USUARIO, dUsuario.IdUsuario);
            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_DIRECCION_USUARIO_PR" };
            return operation;
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DIRECCION_USUARIO_PR" };
            var dUsuario = (DireccionUsuario)entity;
            operation.AddIntParam(DB_COL_ID_USUARIO, dUsuario.IdUsuario);
            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_DIRECCION_USUARIO_PR" };
            var dUsuario = (DireccionUsuario)entity;

            operation.AddDoubleParam(DB_COL_LATITUD, dUsuario.Latitud);
            operation.AddDoubleParam(DB_COL_LONGITUD, dUsuario.Longitud);
            operation.AddIntParam(DB_COL_ID_USUARIO, dUsuario.IdUsuario);

            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_DIRECCION_USUARIO_PR" };
            var dUsuario = (DireccionUsuario)entity;
            operation.AddDoubleParam(DB_COL_LATITUD, dUsuario.Latitud);
            operation.AddDoubleParam(DB_COL_LONGITUD, dUsuario.Longitud);
            operation.AddIntParam(DB_COL_ID_USUARIO, dUsuario.IdUsuario);
            return operation;
        }
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRow)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRow)
            {
                var dUsuario = BuildObject(row);
                lstResults.Add(dUsuario);
            }
            return lstResults;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var dUsuario = new DireccionUsuario
            {
                Id = GetIntValue(row, DB_COL_ID),
                Latitud = GetDoubleValue(row, DB_COL_LATITUD),
                Longitud = GetDoubleValue(row, DB_COL_LONGITUD),
                IdUsuario = GetIntValue(row, DB_COL_ID_USUARIO)
            };
            return dUsuario;
        }

    }
}
