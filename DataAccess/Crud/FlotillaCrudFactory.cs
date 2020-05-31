using DataAccess.Dao;
using DataAccess.Mapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class FlotillaCrudFactory : CrudFactory
    {
        FlotillaMapper mapper;
        public FlotillaCrudFactory() : base()
        {
            mapper = new FlotillaMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var f = (Flotilla)entity;
            var sqlOperation = mapper.GetCreateStatement(f);
            dao.ExecuteProcedure(sqlOperation);
        }
        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResults = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResults.Count > 0)
            {
                dic = lstResults[0];
                var obj = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstFlotillas = new List<T>();
            var lstResults = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResults.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResults);
                foreach (var c in objs)
                {
                    lstFlotillas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstFlotillas;
        }
        public List<T> RetrieveMisFlotillas<T>(BaseEntity entity)
        {
            var lstFlotillas = new List<T>();

            var lstResults = dao.ExecuteQueryProcedure(mapper.RetrieveMisFlotillas(entity));

            if (lstResults.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResults);
                foreach (var c in objs)
                {
                    lstFlotillas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstFlotillas;
        }
        public override void Update(BaseEntity entity)
        {
            var f = (Flotilla)entity;
            var sqlOperation = mapper.GetUpdateStatement(f);
            dao.ExecuteProcedure(sqlOperation);
        }
        public override void Delete(BaseEntity entity)
        {
            var f = (Flotilla)entity;
            var sqlOperation = mapper.GetDeleteStatement(f);
            dao.ExecuteProcedure(sqlOperation);
        }


    }
}
