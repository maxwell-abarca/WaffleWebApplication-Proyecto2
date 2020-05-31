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
    public class DireccionUsuarioCrudFactory : CrudFactory
    {
        DireccionUsuarioMapper mapper;

        public DireccionUsuarioCrudFactory() : base()
        {
            mapper = new DireccionUsuarioMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var dUsuario = (DireccionUsuario)entity;
            var sqlOperation = mapper.GetCreateStatement(dUsuario);
            dao.ExecuteProcedure(sqlOperation);
        }
        public override List<T> RetrieveAll<T>()
        {
            var lstDireccionesUsuario = new List<T>();
            var lstResults = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResults.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResults);
                foreach (var c in objs)
                {
                    lstDireccionesUsuario.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstDireccionesUsuario;
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
        public override void Update(BaseEntity entity)
        {
            var dUsuario = (DireccionUsuario)entity;
            var sqlOperation = mapper.GetUpdateStatement(dUsuario);
            dao.ExecuteProcedure(sqlOperation);
        }
        public override void Delete(BaseEntity entity)
        {
            var dUsuario = (DireccionUsuario)entity;
            var sqlOperation = mapper.GetDeleteStatement(dUsuario);
            dao.ExecuteProcedure(sqlOperation);
        }

    }
}
