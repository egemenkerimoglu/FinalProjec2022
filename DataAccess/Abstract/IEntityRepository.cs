using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // Base Repostory  -- Tekrarlayan verileri IEntityRepository ile tek bir yerden yönetiyoruz

    // generic constraint  :  T ye verilecekleri sınırlandırıyoruz : referans tip ve IEntity olmalı
    // class : referans tip
    // IEntity: IEntity olabilir veya IEntity implemente eden bir nesene olabilir
    // new() : new() lenebilir olacak

    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
        // GetAll da filtre verebilmek için Expression kullanıyoruz
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
