﻿using System;
using System.Collections.Generic;
using DataAccess.Mapper;
using DataAccess.Dao;
using Entities;

namespace DataAccess.Crud
{
    public class AppMessageCrudFactory : CrudFactory
    {
        AppMessageMapper mapper;

        public AppMessageCrudFactory() : base()
        {
            mapper = new AppMessageMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
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
            var lstMessages = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var m in objs)
                {
                    lstMessages.Add((T)Convert.ChangeType(m, typeof(T)));
                }
            }

            return lstMessages;
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
