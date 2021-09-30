﻿using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ICoreService
{
    public interface ICoreService<T> where T : BaseEntity
    {
        //Add
        string Add(T model);

        //Add List
        string Add(List<T> models);

        //Get
        T GetById(int id);

        //Get List
        List<T> GetList();

        //Update
        string Update(T model);


        //Any
        bool Any(Expression<Func<T, bool>> exp);


        //GetDefault
        List<T> GetDefault(Expression<Func<T, bool>> exp);

        void RemoveForce(T model);
    }
}
