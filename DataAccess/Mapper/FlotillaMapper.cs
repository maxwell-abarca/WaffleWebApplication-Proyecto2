using DataAccess.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class FlotillaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        public const string DB_COL_ID = "ID";
        public const string DB_COL_NOMBRE = "NOMBRE";
        public const string DB_COL_CEDULA_DUENO = "CEDULA_DUENO";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_FLOTILLA_PR" };
            var f = (Flotilla)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, f.Nombre);
            operation.AddIntParam(DB_COL_CEDULA_DUENO, f.CedulaDueno);
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_FLOTILLA_PR" };
            var f = (Flotilla)entity;
            operation.AddIntParam(DB_COL_CEDULA_DUENO, f.CedulaDueno);
            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_FLOTILLA_PR" };
            return operation;
        }
        public SqlOperation RetrieveMisFlotillas(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_MIS_FLOTILLAS_PR" };
            var f = (Flotilla)entity;
            operation.AddIntParam(DB_COL_CEDULA_DUENO, f.CedulaDueno);
            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_FLOTILLA_PR" };
            var f = (Flotilla)entity;
            operation.AddIntParam(DB_COL_ID, f.Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, f.Nombre);
           
            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_FLOTILLA_PR" };
            var f = (Flotilla)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, f.Nombre);
            return operation;
        }
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResult = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var flotilla = BuildObject(row);
                lstResult.Add(flotilla);
            }
            return lstResult;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var flotilla = new Flotilla
            {
                Id = GetIntValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                CedulaDueno = GetIntValue(row, DB_COL_CEDULA_DUENO)
            };
            return flotilla;

        }
    }
}
