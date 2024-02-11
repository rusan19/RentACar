using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal carDal;
       
        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }
        public IResult Add(Car car)
        {
            carDal.Add(car);
            return new SuccessResult(ResultMessages.Success);
        }

        public IResult Delete(int id)
        {
            carDal.Delete(id);
            return new SuccessResult(ResultMessages.Success);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<List<Car>>(ResultMessages.Error);
            }
            return new SuccessDataResult<List<Car>>(carDal.GetAll(), ResultMessages.Success);
            
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(carDal.Get(c => c.Id == id),ResultMessages.Success);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(carDal.GetCarDetails(),ResultMessages.Success);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(carDal.GetAll(c=>c.BrandId==brandId),ResultMessages.Success);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(carDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            carDal.Update(car);
            return new SuccessResult(ResultMessages.Success); 
        }
    }
}
