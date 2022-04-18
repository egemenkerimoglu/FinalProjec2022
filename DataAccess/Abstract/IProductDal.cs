using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // Soyut
    //Product Tablosu ile ilgili veri tabana erişim -CRUD
    public interface IProductDal:IEntityRepository<Product>
    {

        /* İlk hali böyle idi       
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAllByCategory(int categoryId);
         */

    }
}
