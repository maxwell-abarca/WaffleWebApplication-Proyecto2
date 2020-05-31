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
    public class PromocionCrudFactory : CrudFactory
    {
        PromocionMapper mapper;

        public PromocionCrudFactory() : base()
        {
            mapper = new PromocionMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var promocion = (Promocion)entity;
            var sqlOperation = mapper.GetCreateStatement(promocion);
            dao.ExecuteProcedure(sqlOperation);
        }
        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResults = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResults.Count > 0)
            {
                dic = lstResults[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }
        public override List<T> RetrieveAll<T>()
        {
            var lstPromocion = new List<T>();
            var lstResults = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResults.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResults);
                foreach (var c in objs)
                {
                    lstPromocion.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstPromocion;
        }
        public List<T> RetrieveMisPromociones<T>(BaseEntity entity)
        {
            var lstPromocion = new List<T>();
            var lstResults = dao.ExecuteQueryProcedure(mapper.GetRetrieveMisPromociones(entity));
            var dic = new Dictionary<string, object>();
            if (lstResults.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResults);
                foreach (var c in objs)
                {
                    lstPromocion.Add((T)Convert.ChangeType(c, typeof(T)));
                }

            }
            return lstPromocion;
        }
        public override void Update(BaseEntity entity)
        {
            var promocion = (Promocion)entity;
            var sqlOperation = mapper.GetUpdateStatement(promocion);
            dao.ExecuteProcedure(sqlOperation);
        }
        public override void Delete(BaseEntity entity)
        {
            var promocion = (Promocion)entity;
            var sqlOperation = mapper.GetDeleteStatement(promocion);
            dao.ExecuteProcedure(sqlOperation);
        }

    }
}
