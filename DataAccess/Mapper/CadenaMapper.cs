using DataAccess.Dao;
using Entities;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class CadenaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_CEDULA_DUENO = "CEDULA_DUENO";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_LOGO = "LOGO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CADENA_PR" };
            var c = (Cadena)entity;
            operation.AddIntParam(DB_COL_CEDULA_DUENO, c.CedulaDueno);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_LOGO, c.Logo);
            return operation;
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CADENA_PR" };
            var c = (Cadena)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            return operation;
        }
        public SqlOperation GetCadenaUsuario(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CADENA_USUARIO_PROC" };
            var c = (Cadena)entity;
            operation.AddIntParam(DB_COL_CEDULA_DUENO, c.CedulaDueno);
            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CADENA_PR" };
            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CADENA_PR" };
            var c = (Cadena)entity;
            operation.AddIntParam(DB_COL_CEDULA_DUENO, c.CedulaDueno);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_LOGO, c.Logo);
            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CADENA_PR" };
            var c = (Cadena)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var cadena = BuildObject(row);
                lstResults.Add(cadena);
            }
            return lstResults;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var cadena = new Cadena
            {
                ID = GetIntValue(row, DB_COL_ID),
                CedulaDueno = GetIntValue(row, DB_COL_CEDULA_DUENO),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Logo = GetStringValue(row, DB_COL_LOGO)
            };

            return cadena;
        }
    }
}
