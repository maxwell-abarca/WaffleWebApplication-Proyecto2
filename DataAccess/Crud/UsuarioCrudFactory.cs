using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities;

namespace DataAccess.Crud
{
    public class UsuarioCrudFactory : CrudFactory
    {
        UsuarioMapper mapper;

        public UsuarioCrudFactory() : base()
        {
            mapper = new UsuarioMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            var sqlOperation = mapper.GetCreateStatement(usuario);
            dao.ExecuteProcedure(sqlOperation);
        }

        public T GetUsuario<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetUsuario(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }
        public List<T> RetrieveTransportistas<T>(BaseEntity entity)
        {
            var lstTransportistas = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetTransportistas(entity));
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTransportistas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstTransportistas;
        }

        public T RetrieveCodigoUsuario<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCodigoUsuario(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }
        public override List<T> RetrieveAll<T>()
        {
            var lstUsuarios = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstUsuarios.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstUsuarios;
        }

        public override void Update(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(usuario));
        }
        public void UpdateCode(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            dao.ExecuteProcedure(mapper.UpdateCode(usuario));
        }
        public override void Delete(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(usuario));
        }

        public T GetRol<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRol(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }

        public T GetCorreo<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCorreo(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }
        public void UpdateContrasena(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            dao.ExecuteProcedure(mapper.UpdateContrasena(usuario));
        }
        public void UpdateEstado(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            dao.ExecuteProcedure(mapper.UpdateEsatdo(usuario));
        }
        public List<T> RetrieveTransportistasSolicitudes<T>(BaseEntity entity)
        {
            var lstTransportistas = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetTransportistasSolicitudes(entity));
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTransportistas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstTransportistas;
        }
        public void GetUpdateEstado(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            dao.ExecuteProcedure(mapper.GetUpdateEstado(usuario));
        }
        public T GetRetriveCedula<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveCedula(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }
        public List<T> GetTransportistasEstado<T>(BaseEntity entity)
        {
            var lstTransportistas = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetTransportistasEstado(entity));
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTransportistas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstTransportistas;
        }
    }
}
