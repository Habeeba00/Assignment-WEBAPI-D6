using Assignment_WEBAPI_D6.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_WEBAPI_D6.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository(CompanyDbContext db)
        {
            Db = db;
        }

        public CompanyDbContext Db { get; }

        public List<TEntity>selectall()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetByid(int id) 
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity) 
        {
            Db.Set<TEntity>().Add(entity);

        }

        public void Edit(TEntity entity) 
        {
            Db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id ) 
        { 
            TEntity entity=GetByid(id);
            Db.Set<TEntity>().Remove(entity);

        }
        //public void save()
        //{
        //    Db.SaveChanges();
        //}


    }
}
