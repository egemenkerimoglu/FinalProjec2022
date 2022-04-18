using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // 1. NuGet 'dan DataAccsess üzerine entity framework core.sql  kurulur.
    // 2. Entites/Concrete altındaki nesnelerimi veri tabanı ile ilişkilendirme 
    //  Contex yapısı kuruyoruz.
    public class EfProductDal : IProductDal
    {
        
        public void Add(Product entity)
        {
            // IDisposable pattern implementation of c#  :  iş bitince belleği temizliyor
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); // Referansı yakala
                addedEntity.State = EntityState.Added; // Ekle
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted; 
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //  filtre yoksa hepsini varsa ona göre getir
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
