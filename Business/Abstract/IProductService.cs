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
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);// Kategori id sine göre ürünleri getir

        List<Product> GetAllByUnitPrice(decimal min, decimal max); // min ve max fiyat arasındaki data

        List<ProductDetailDto> GetProductDetails();
    }
}
