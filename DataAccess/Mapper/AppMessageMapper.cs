using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities;

namespace DataAccess.Mapper
{
    public class AppMessageMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_MENSAJE = "MENSAJE";


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var appMessage = BuildObject(row);
                lstResults.Add(appMessage);
            }
            return lstResults;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var appMessage = new ApplicationMessage
            {
                Id = GetIntValue(row, DB_COL_ID),
                Message = GetStringValue(row, DB_COL_MENSAJE)
            };
            return appMessage;

        }


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_EXCEPCION_PROC" };
            var m = (ApplicationMessage)entity;
            operation.AddIntParam(DB_COL_ID, m.Id);

            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_EXCEPCION_PROC" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
