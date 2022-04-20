using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        // ben CategoryManager olarak veri erişim katmanına bağımlıyım ama  zayıf bir bağımlılık,
        // sen DataAcsess katmanında istediğin gibi davranabilirsin
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        // İş kodları
        public List<Category> GetAll()
        {
            
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        { 
            // select * from Caregories where categoryId = ...
            return _categoryDal.Get(c=>c.CategoryId == categoryId);
        }
            
    }
}
