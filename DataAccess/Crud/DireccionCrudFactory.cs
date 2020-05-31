using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities;

namespace DataAccess.Crud
{
    public class DireccionCrudFactory : CrudFactory
    {
        DireccionMapper mapper;

        public DireccionCrudFactory() : base()
        {
            mapper = new DireccionMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var dir = (Direccion)entity;
            var sqlOperation = mapper.GetCreateStatement(dir);
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
            var lstProducto = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProducto.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProducto;
        }

        public override void Update(BaseEntity entity)
        {
            var dir = (Direccion)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(dir));
        }
        public override void Delete(BaseEntity entity)
        {
            var dir = (Direccion)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(dir));
        }
        public T Get<T>(BaseEntity entity)
        {
            var lstResults = dao.ExecuteQueryProcedure(mapper.GetRetrive(entity));
            var dic = new Dictionary<string, object>();
            if (lstResults.Count > 0)
            {
                dic = lstResults[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
    }
}