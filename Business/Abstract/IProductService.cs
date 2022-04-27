using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    // iş katmanında kullanacağımız servis katmanı
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); // Aynı zamanda işlem sonucu Data yı döndürüyoruz
        IDataResult<List<Product>> GetAllByCategoryId(int id);// Kategori id sine göre ürünleri getir
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max); // min ve max fiyat arasındaki data
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        
    }
}
