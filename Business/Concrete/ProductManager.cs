﻿using Business.Abstract;
using Business.Constants;
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
                //magic string
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccsessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            // İş kodları
            return new SuccsessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccsessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId == id));
        }
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccsessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            // iki fiyat arasındak, datayı getir
            return new SuccsessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }       

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return  new SuccsessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
