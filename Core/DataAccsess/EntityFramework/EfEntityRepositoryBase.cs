using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccsess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        //kurallar bunlar
        where TEntity : class, IEntity, new()
       where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {

            using (TContext context = new TContext())
            {
                //git demek bir nesneye eşleştir ekleyecek 
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();


            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //git demek bir nesneye eşleştir silecek 
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();


            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //filitresi yoksa tümünü getir değilse bunları yap gibisinden 
                return filter == null ? context.Set<TEntity>().ToList() ://evetse bu 
                    context.Set<TEntity>().Where(filter).ToList();//hayırsa bu filitre yerine ne yazarssan onu getirir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //git demek bir nesneye eşleştir güncelleyecek 
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();


            }
        }
    }
}
