using Core.Utilites.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        public IResult Add(Car car);
        public IResult Delete(int id);
        public IResult Update(Car car);
        public IDataResult<List<Car>> GetAll();
        public IDataResult<Car> GetById(int id);
        public IDataResult<List<CarDetailsDto>> GetCarDetails();
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        public IDataResult<List<Car>> GetCarsByColorId(int colorId);
    }
}
