using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;

namespace MVCCV.Repositories
{
    public class GenericRepository<T> where T:class , new()
    {
        DbCvEntities1 database = new DbCvEntities1();
        public List<T> List()
        {
            return database.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            database.Set<T>().Add(p);
            database.SaveChanges();
        }
        public void TDelete(T p)
        {
            database.Set<T>().Remove(p);
            database.SaveChanges();
        }
        public T TGet(int id)
        {
            return database.Set<T>().Find(id);
        }
        public void TUpdate(T p)
        {
            
            database.SaveChanges();
        } 
        public T Find(Expression<Func<T, bool>> where)
        {
            return database.Set<T>().FirstOrDefault(where);
        }
       
    }
}