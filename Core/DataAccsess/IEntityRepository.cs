﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccsess
{          //generic constraint kısıtlama
          //class: referans tip
          //IEntity olabilir veya IEntity implemente eden bir nesne olabilir
          //new() : new lenebilir olması gerek 
   public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add( T entity);
        void Update(T entity);
        void Delete(T entity);

        //kategori listeleme  Expression<Func<T,bool>> filter
    }
}
