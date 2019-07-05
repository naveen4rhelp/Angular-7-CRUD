using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private CRUDContext db = null;
        //private IDbSet<T> dbEntity = null;

        public Repository()
        {
            db = new CRUDContext();
        }
        public void Add(T model)
        {
            db.Set<T>().Add(model);

            //db.Entry<T>(model).State = EntityState.Added;
        }

        public void Delete(T model)
        {
            db.Set<T>().Remove(model);
        }

        public void Delete(int id)
        {
            T model = Find(id);
            if (model != null)
            {
                db.Set<T>().Remove(model);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        /// <summary>
        /// Inculudes in the specified data
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(string path)
        {
            return db.Set<T>().Include(path);
        }

        public T Find(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(T model)
        {
            db.Entry<T>(model).State = EntityState.Modified;
        }

    }
}