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
    public class VehiculoCrudFactory : CrudFactory
    {
        VehiculoMapper mapper;

        public VehiculoCrudFactory() : base()
        {
            mapper = new VehiculoMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var v = (Vehiculo)entity;
            var sqlOperation = mapper.GetCreateStatement(v);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var obj = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            return default(T);
        }
        public override List<T> RetrieveAll<T>()
        {
            var lstVehiculos = new List<T>();
            var lstResults = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResults.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResults);
                foreach (var c in objs)
                {
                    lstVehiculos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstVehiculos;
        }
        public List<T> RetrieveMisVehiculos<T>(BaseEntity entity)
        {
            var lstVehiculos = new List<T>();
            var lstResults = dao.ExecuteQueryProcedure(mapper.RetrieveMisVehiculos(entity));
            if (lstResults.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResults);
                foreach (var c in objs)
                {
                    lstVehiculos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstVehiculos;
        }
        public override void Update(BaseEntity entity)
        {
            var v = (Vehiculo)entity;
            var sqlOperation = mapper.GetUpdateStatement(v);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var v = (Vehiculo)entity;
            var sqlOperation = mapper.GetDeleteStatement(v);
            dao.ExecuteProcedure(sqlOperation);
        }

    }
}
