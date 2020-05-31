using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccess.Dao;

namespace DataAccess.Mapper
{
    public class UsuarioMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_CEDULA = "CEDULA";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_PRIMER_APELLIDO = "PRIMER_APELLIDO";
        private const string DB_COL_SEGUNDO_APELLIDO = "SEGUNDO_APELLIDO";
        private const string DB_COL_FECHA_NACIMIENTO = "FECHA_NACIMIENTO";
        private const string DB_COL_CORREO = "CORREO";
        private const string DB_COL_CONTRASENA = "CONTRASENA";
        private const string DB_COL_TELEFONO = "TELEFONO";
        private const string DB_COL_FOTO_PERFIL = "FOTO_PERFIL";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_TIPO_IDENTIFICACION = "TIPO_IDENTIFICACION";
        private const string DB_COL_CODIGO_VERIFICACION = "CODIGO_VERIFICACION";
        private const string DB_COL_ID_ROL = "ID_ROL";





        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_USUARIO_PR" };
            var u = (Usuario)entity;
            operation.AddIntParam(DB_COL_CEDULA, u.Cedula);
            operation.AddVarcharParam(DB_COL_NOMBRE, u.Nombre);
            operation.AddVarcharParam(DB_COL_PRIMER_APELLIDO, u.PrimerApellido);
            operation.AddVarcharParam(DB_COL_SEGUNDO_APELLIDO, u.SegundoApellido);
            operation.AddDateParam(DB_COL_FECHA_NACIMIENTO, u.FechaNacimiento);
            operation.AddVarcharParam(DB_COL_CORREO, u.Correo);
            operation.AddVarcharParam(DB_COL_CONTRASENA, u.Contrasena);
            operation.AddVarcharParam(DB_COL_TELEFONO, u.Telefono);
            operation.AddVarcharParam(DB_COL_FOTO_PERFIL, u.FotoPerfil);
            operation.AddVarcharParam(DB_COL_ESTADO, u.Estado);
            operation.AddVarcharParam(DB_COL_TIPO_IDENTIFICACION, u.TipoIdentificacion);
            operation.AddVarcharParam(DB_COL_CODIGO_VERIFICACION, u.CodigoVerificacion);
            operation.AddIntParam(DB_COL_ID_ROL, u.IdRol);
            return operation;
        }
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_PR" };
            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, u.Nombre);
            operation.AddIntParam(DB_COL_CEDULA, u.Cedula);

            return operation;
        }
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USUARIO_PR" };
            return operation;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USUARIO_PR" };
            var u = (Usuario)entity;
            operation.AddIntParam(DB_COL_CEDULA, u.Cedula);
            operation.AddVarcharParam(DB_COL_NOMBRE, u.Nombre);
            operation.AddVarcharParam(DB_COL_PRIMER_APELLIDO, u.PrimerApellido);
            operation.AddVarcharParam(DB_COL_SEGUNDO_APELLIDO, u.SegundoApellido);
            operation.AddDateParam(DB_COL_FECHA_NACIMIENTO, u.FechaNacimiento);
            operation.AddVarcharParam(DB_COL_CORREO, u.Correo);
            operation.AddVarcharParam(DB_COL_CONTRASENA, u.Contrasena);
            operation.AddVarcharParam(DB_COL_TELEFONO, u.Telefono);
            operation.AddVarcharParam(DB_COL_FOTO_PERFIL, u.FotoPerfil);
            operation.AddVarcharParam(DB_COL_ESTADO, u.Estado);
            operation.AddVarcharParam(DB_COL_TIPO_IDENTIFICACION, u.TipoIdentificacion);
            operation.AddVarcharParam(DB_COL_CODIGO_VERIFICACION, u.CodigoVerificacion);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USUARIO_PR" };
            var u = (Usuario)entity;
            operation.AddIntParam(DB_COL_CEDULA, u.Cedula);

            return operation;
        }
        public SqlOperation GetCodigoUsuario(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_CODIGO_PR" };
            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_CODIGO_VERIFICACION, u.CodigoVerificacion);

            return operation;
        }
        public SqlOperation GetUsuario(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "GET_USUARIO_PROC" };
            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_CORREO, u.Correo);
            operation.AddVarcharParam(DB_COL_CONTRASENA, u.Contrasena);

            return operation;
        }
        public SqlOperation UpdateCode(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USUARIO_CODE_PR" };
            var u = (Usuario)entity;
            operation.AddIntParam(DB_COL_CEDULA, u.Cedula);
            operation.AddVarcharParam(DB_COL_CODIGO_VERIFICACION, u.CodigoVerificacion);
            return operation;
        }
        public SqlOperation GetRol(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "GET_ROL_PROC" };
            var u = (Usuario)entity;
            operation.AddIntParam(DB_COL_CEDULA, u.Cedula);

            return operation;
        }

        public SqlOperation GetCorreo(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "VERIFICAR_CORREO_PROC" };
            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_CORREO, u.Correo);

            return operation;
        }
        public SqlOperation GetTransportistas(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_TRANSPORTISTA_PR" };
            var u = (Usuario)entity;
            operation.AddIntParam(DB_COL_ID_ROL, u.IdRol);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var usuario = BuildObject(row);
                lstResults.Add(usuario);
            }
            return lstResults;
        }
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var usuario = new Usuario
            {
                Cedula = GetIntValue(row, DB_COL_CEDULA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                PrimerApellido = GetStringValue(row, DB_COL_PRIMER_APELLIDO),
                SegundoApellido = GetStringValue(row, DB_COL_SEGUNDO_APELLIDO),
                FechaNacimiento = GetDateValue(row, DB_COL_FECHA_NACIMIENTO),
                Correo = GetStringValue(row, DB_COL_CORREO),
                Contrasena = GetStringValue(row, DB_COL_CONTRASENA),
                Telefono = GetStringValue(row, DB_COL_TELEFONO),
                FotoPerfil = GetStringValue(row, DB_COL_FOTO_PERFIL),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                TipoIdentificacion = GetStringValue(row, DB_COL_TIPO_IDENTIFICACION),
                CodigoVerificacion = GetStringValue(row, DB_COL_CODIGO_VERIFICACION),
                IdRol = GetIntValue(row, DB_COL_ID_ROL)
            };
            return usuario;
        }
        public SqlOperation UpdateContrasena(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CONTRASENA_PROC" };
            var u = (Usuario)entity;
            operation.AddIntParam(DB_COL_CEDULA, u.Cedula);
            operation.AddVarcharParam(DB_COL_CONTRASENA, u.Contrasena);

            return operation;
        }
        public SqlOperation UpdateEsatdo(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ESTADO_PROC" };
            var u = (Usuario)entity;
            operation.AddIntParam(DB_COL_CEDULA, u.Cedula);
            operation.AddVarcharParam(DB_COL_ESTADO, u.Estado);

            return operation;
        }
        public SqlOperation GetTransportistasSolicitudes(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_TRANSPORTISTA_SOLICITUDES_PR" };
            var u = (Usuario)entity;
            operation.AddIntParam(DB_COL_ID_ROL, u.IdRol);
            return operation;
        }
        public SqlOperation GetUpdateEstado(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USUARIO_ESTADO_PR" };
            var u = (Usuario)entity;
            operation.AddIntParam(DB_COL_CEDULA, u.Cedula);
            operation.AddVarcharParam(DB_COL_ESTADO, u.Estado);

            return operation;
        }
        public SqlOperation GetRetriveCedula(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CEDULA_USUARIO_PR" };
            var u = (Usuario)entity;
            operation.AddIntParam(DB_COL_CEDULA, u.Cedula);

            return operation;
        }

        public SqlOperation GetTransportistasEstado(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRANSPORTISTAS_INACTIVOS_PR" };
            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_ESTADO, u.Estado);

            return operation;
        }
    }
}
