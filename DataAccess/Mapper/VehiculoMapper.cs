using DataAccess.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class VehiculoMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        public const string DB_COL_PLACA = "PLACA";
        public const string DB_COL_MARCA = "MARCA";
        public const string DB_COL_MODELO = "MODELO";
        public const string DB_COL_TIPO_VEHICULO = "TIPO_VEHICULO";
        public const string DB_COL_CEDULA_DUENO = "CEDULA_DUENO";
        public const string DB_COL_ID_FLOTILLA = "ID_FLOTILLA";
        public const string DB_COL_NOMBRE_FLOTILLA = "NOMBRE";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_VEHICULO_PR" };
            var v = (Vehiculo)entity;
            operation.AddVarcharParam(DB_COL_PLACA, v.Placa);
            operation.AddVarcharParam(DB_COL_MARCA, v.Marca);
            operation.AddVarcharParam(DB_COL_MODELO, v.Modelo);
            operation.AddVarcharParam(DB_COL_TIPO_VEHICULO, v.TipoVehiculo);
            operation.AddIntParam(DB_COL_CEDULA_DUENO, v.CedulaDueno);
            operation.AddIntParam(DB_COL_ID_FLOTILLA, v.IdFlotilla);
            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_VEHICULO_PR" };
            return operation;
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_VEHICULO_PR" };
            var v = (Vehiculo)entity;
            operation.AddVarcharParam(DB_COL_PLACA, v.Placa);
            return operation;
        }
        public SqlOperation RetrieveMisVehiculos(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_MIS_VEHICULOS_PR" };
            var v = (Vehiculo)entity;
            operation.AddIntParam(DB_COL_CEDULA_DUENO, v.CedulaDueno);
            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_VEHICULO_PR" };
            var v = (Vehiculo)entity;
            operation.AddVarcharParam(DB_COL_PLACA, v.Placa);
            operation.AddVarcharParam(DB_COL_MARCA, v.Marca);
            operation.AddVarcharParam(DB_COL_MODELO, v.Modelo);
            operation.AddVarcharParam(DB_COL_TIPO_VEHICULO, v.TipoVehiculo);
            operation.AddIntParam(DB_COL_CEDULA_DUENO, v.CedulaDueno);
            operation.AddIntParam(DB_COL_ID_FLOTILLA, v.IdFlotilla);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_VEHICULO_PR" };
            var v = (Vehiculo)entity;
            operation.AddVarcharParam(DB_COL_PLACA, v.Placa);
            return operation;
        }
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResult = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var vehiculo = BuildObject(row);
                lstResult.Add(vehiculo);
            }
            return lstResult;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var vehiculo = new Vehiculo
            {
                Placa = GetStringValue(row, DB_COL_PLACA),
                Marca = GetStringValue(row, DB_COL_MARCA),
                Modelo = GetStringValue(row, DB_COL_MODELO),
                TipoVehiculo = GetStringValue(row, DB_COL_TIPO_VEHICULO),
                CedulaDueno = GetIntValue(row, DB_COL_CEDULA_DUENO),
                IdFlotilla = GetIntValue(row, DB_COL_ID_FLOTILLA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE_FLOTILLA)
            };
            return vehiculo;
        }


    }


}
