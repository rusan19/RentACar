using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            this.brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            brandDal.Add(brand);
            return new SuccessResult(ResultMessages.Success);
        }

        public IResult Delete(int brandId)
        {
            brandDal.Delete(brandId);
            return new SuccessResult(ResultMessages.Success);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(brandDal.GetAll(),ResultMessages.Success);
            
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(brandDal.Get(b => b.Id == id),ResultMessages.Success);
        }

        public IResult Update(Brand brand)
        {
            brandDal.Update(brand);
            return new SuccessResult(ResultMessages.Success);

        }

      
    }
}
