using DataAccess.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class PromocionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        public const string DB_COL_CODIGO = "CODIGO";
        public const string DB_COL_ID_PRODUCTO = "ID_PRODUCTO";
        public const string DB_COL_DESCUENTO = "DESCUENTO";
        public const string DB_COL_ESTADO = "ESTADO";
        public const string DB_COL_ID_COMERCIO = "ID_COMERCIO";
        public const string DB_COL_NOMBRE_PRODUCTO = "NOMBRE_PRODUCTO";
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PROMOCION_PR" };
            var p = (Promocion)entity;
            operation.AddVarcharParam(DB_COL_CODIGO, p.Codigo);
            operation.AddVarcharParam(DB_COL_ID_PRODUCTO, p.IdProducto);
            operation.AddDoubleParam(DB_COL_DESCUENTO, p.Descuento);
            operation.AddVarcharParam(DB_COL_ESTADO, p.Estado);
            operation.AddIntParam(DB_COL_ID_COMERCIO, p.IdComercio);
            return operation;
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PROMOCION_PR" };
            var p = (Promocion)entity;
            operation.AddVarcharParam(DB_COL_CODIGO, p.Codigo);
            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PROMOCION_PR" };
            return operation;
        }
        public SqlOperation GetRetrieveMisPromociones(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_MIS_PROMOCIONES_PR" };
            var p = (Promocion)entity;
            operation.AddIntParam(DB_COL_ID_COMERCIO, p.IdComercio);
            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PROMOCION_PR" };
            var p = (Promocion)entity;
            operation.AddVarcharParam(DB_COL_CODIGO, p.Codigo);
            operation.AddVarcharParam(DB_COL_ID_PRODUCTO, p.IdProducto);
            operation.AddDoubleParam(DB_COL_DESCUENTO, p.Descuento);
            operation.AddVarcharParam(DB_COL_ESTADO, p.Estado);

            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_PROMOCION_PR" };
            var p = (Promocion)entity;
            operation.AddVarcharParam(DB_COL_CODIGO, p.Codigo);
            return operation;
        }
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRow)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRow)
            {
                var promocion = BuildObject(row);
                lstResults.Add(promocion);
            }
            return lstResults;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var promocion = new Promocion
            {
                Codigo = GetStringValue(row, DB_COL_CODIGO),
                IdProducto = GetStringValue(row, DB_COL_ID_PRODUCTO),
                Descuento = GetDoubleValue(row, DB_COL_DESCUENTO),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                IdComercio = GetIntValue(row, DB_COL_ID_COMERCIO),
                NombreProducto = GetStringValue(row, DB_COL_NOMBRE_PRODUCTO)
            };
            return promocion;
        }

    }
}
