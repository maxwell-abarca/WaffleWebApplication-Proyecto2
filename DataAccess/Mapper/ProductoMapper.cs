using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities;

namespace DataAccess.Mapper
{
    public class ProductoMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_PRODUCTO = "ID_PRODUCTO";
        private const string DB_COL_NOMBRE_PRODUCTO = "NOMBRE_PRODUCTO";
        private const string DB_COL_ID_CATEGORIA = "ID_CATEGORIA";
        private const string DB_COL_PRECIO = "PRECIO";
        private const string DB_COL_IMAGEN = "IMAGEN";
        private const string DB_COL_CEDULA_COMERCIO = "CEDULA_COMERCIO";
        private const string DB_COL_ESTADO = "ESTADO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PRODUCTO_PR" };

            var p = (Producto)entity;
            operation.AddVarcharParam(DB_COL_ID_PRODUCTO, p.IdProducto);
            operation.AddVarcharParam(DB_COL_NOMBRE_PRODUCTO, p.NombreProducto);
            operation.AddIntParam(DB_COL_ID_CATEGORIA, p.IdCategoria);
            operation.AddIntParam(DB_COL_PRECIO, p.Precio);
            operation.AddVarcharParam(DB_COL_IMAGEN, p.Imagen);
            operation.AddIntParam(DB_COL_CEDULA_COMERCIO, p.CedulaComercio);
            operation.AddVarcharParam(DB_COL_ESTADO, p.Estado);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRODUCTO_PR" };

            var p = (Producto)entity;
            operation.AddVarcharParam(DB_COL_ID_PRODUCTO, p.IdProducto);
            operation.AddVarcharParam(DB_COL_NOMBRE_PRODUCTO, p.NombreProducto);
            operation.AddIntParam(DB_COL_ID_CATEGORIA, p.IdCategoria);
            operation.AddIntParam(DB_COL_PRECIO, p.Precio);
            operation.AddVarcharParam(DB_COL_IMAGEN, p.Imagen);
            operation.AddIntParam(DB_COL_CEDULA_COMERCIO, p.CedulaComercio);
            operation.AddVarcharParam(DB_COL_ESTADO, p.Estado);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PRODUCTO_PR" };
            return operation;
        }
       

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PRODUCTO_PR" };

            var p = (Producto)entity;
            operation.AddVarcharParam(DB_COL_ID_PRODUCTO, p.IdProducto);
            operation.AddVarcharParam(DB_COL_NOMBRE_PRODUCTO, p.NombreProducto);
            operation.AddIntParam(DB_COL_ID_CATEGORIA, p.IdCategoria);
            operation.AddIntParam(DB_COL_PRECIO, p.Precio);
            operation.AddVarcharParam(DB_COL_IMAGEN, p.Imagen);
            operation.AddVarcharParam(DB_COL_ESTADO, p.Estado);

            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_PRODUCTO_PR" };

            var p = (Producto)entity;
            operation.AddVarcharParam(DB_COL_ID_PRODUCTO, p.IdProducto);
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
            var producto = new Producto
            {
                IdProducto = GetStringValue(row, DB_COL_ID_PRODUCTO),
                NombreProducto = GetStringValue(row, DB_COL_NOMBRE_PRODUCTO),
                IdCategoria = GetIntValue(row, DB_COL_ID_CATEGORIA),
                Precio = GetIntValue(row, DB_COL_PRECIO),
                Imagen = GetStringValue(row, DB_COL_IMAGEN),
                CedulaComercio = GetIntValue(row, DB_COL_CEDULA_COMERCIO),
                Estado = GetStringValue(row, DB_COL_ESTADO)
            };

            return producto;
        }
        public SqlOperation GetProductosComercio(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRODUCTOS_POR_COMERCIOS_PR" };
            var u = (Producto)entity;
            operation.AddIntParam(DB_COL_CEDULA_COMERCIO, u.CedulaComercio);
            return operation;
        }
    }
}