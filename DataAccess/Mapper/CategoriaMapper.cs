using DataAccess.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class CategoriaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_CATEGORIA = "ID_CATEGORIA";
        private const string DB_COL_NOMBRE_CATEGORIA = "NOMBRE_CATEGORIA";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CATEGORIA_PR" };

            var c = (Categoria)entity;
            operation.AddIntParam(DB_COL_ID_CATEGORIA, c.IdCategoria);
            operation.AddVarcharParam(DB_COL_NOMBRE_CATEGORIA, c.NombreCategoria);

            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            return new SqlOperation { ProcedureName = "RET_ALL_CATEGORIA_PR" };
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CATEGORIA_PR" };
            var c = (Categoria)entity;
            operation.AddIntParam(DB_COL_ID_CATEGORIA, c.IdCategoria);
            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CATEGORIA_PR" };
            var c = (Categoria)entity;
            operation.AddIntParam(DB_COL_ID_CATEGORIA, c.IdCategoria);
            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CATEGORIA_PR" };

            var c = (Categoria)entity;
            operation.AddIntParam(DB_COL_ID_CATEGORIA, c.IdCategoria);
            operation.AddVarcharParam(DB_COL_NOMBRE_CATEGORIA, c.NombreCategoria);

            return operation;
        }
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var categoria = BuildObject(row);
                lstResults.Add(categoria);
            }

            return lstResults;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var categoria = new Categoria
            {
                IdCategoria = GetIntValue(row, DB_COL_ID_CATEGORIA),
                NombreCategoria = GetStringValue(row, DB_COL_NOMBRE_CATEGORIA)
            };

            return categoria;
        }
    }
}
