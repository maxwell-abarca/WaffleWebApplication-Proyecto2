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
    public class CadenaCrudFactory : CrudFactory
    {
        CadenaMapper mapper;

        public CadenaCrudFactory() : base()
        {
            mapper = new CadenaMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var cadena = (Cadena)entity;
            var sqlOperation = mapper.GetCreateStatement(cadena);
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
            var lstCadenas = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCadenas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstCadenas;
        }
        public List<T> GetCadenaUsuario<T>(BaseEntity entity)
        {
            var lstCadenas = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCadenaUsuario(entity));
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCadenas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstCadenas;
        }

        public override void Update(BaseEntity entity)
        {
            var c = (Cadena)entity;
            var sqlOperation = mapper.GetUpdateStatement(c);
            dao.ExecuteProcedure(sqlOperation);
        }
        public override void Delete(BaseEntity entity)
        {
            var c = (Cadena)entity;
            var sqlOperation = mapper.GetDeleteStatement(c);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
