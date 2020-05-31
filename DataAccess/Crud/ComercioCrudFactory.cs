using DataAccess.Dao;
using DataAccess.Mapper;
using Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class ComercioCrudFactory : CrudFactory
    {
        ComercioMapper mapper;

        public ComercioCrudFactory() : base()
        {
            mapper = new ComercioMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var comercio = (Comercio)entity;
            var sqlOperation = mapper.GetCreateStatement(comercio);
            dao.ExecuteProcedure(sqlOperation);
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
        public override List<T> RetrieveAll<T>()
        {
            var lstComercios = new List<T>();
            var lstResults = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResults.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResults);
                foreach (var c in objs)
                {
                    lstComercios.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstComercios;
        }
        public override void Update(BaseEntity entity)
        {
            var comercio = (Comercio)entity;
            var sqlOperation = mapper.GetUpdateStatement(comercio);
            dao.ExecuteProcedure(sqlOperation);
        }
        public override void Delete(BaseEntity entity)
        {
            var comercio = (Comercio)entity;
            var sqlOperation = mapper.GetDeleteStatement(comercio);
            dao.ExecuteProcedure(sqlOperation);
        }
        public void GetUpdateEstado(BaseEntity entity)
        {
            var comercio = (Comercio)entity;
            dao.ExecuteProcedure(mapper.GetUpdateEstado(comercio));
        }
        public List<T> RetrieveComerciosSolicitudes<T>(BaseEntity entity)
        {
            var lstComercios = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetSolicitudesComercios(entity));
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstComercios.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstComercios;
        }
        public List<T> GetComercios<T>(BaseEntity entity)
        {
            var lstComercios = new List<T>();
            var lstResults = dao.ExecuteQueryProcedure(mapper.GetComercios(entity));
            var dic = new Dictionary<string, object>();
            if (lstResults.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResults);
                foreach (var c in objs)
                {
                    lstComercios.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstComercios;
        }
        public List<T> GetComerciosEstado<T>(BaseEntity entity)
        {
            var lstComercios = new List<T>();
            var lstResults = dao.ExecuteQueryProcedure(mapper.GetComerciosEstado(entity));
            var dic = new Dictionary<string, object>();
            if (lstResults.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResults);
                foreach (var c in objs)
                {
                    lstComercios.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstComercios;
        }
    }
}
