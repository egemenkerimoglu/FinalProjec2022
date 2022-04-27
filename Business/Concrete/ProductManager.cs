using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // İş katmanı somut sınıfı
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        // IResult dan geri dönüş aldırdık
        public IResult Add(Product product)
        {
            if (product.ProductName.Length <2)
            {
                return new ErrorResult("Ürün ismi min 2 karakter olmalıdır");
            }
            _productDal.Add(product);
            return new SuccsessResult("Ürün eklendi");
        }

        public List<Product> GetAll()
        {
            // İş kodları
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId == id);
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            // iki fiyat arasındak, datayı getir
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<= max);
        }

        public Product GetById(int productId)
        {
           return  _productDal.Get(p=>p.ProductId == productId);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
