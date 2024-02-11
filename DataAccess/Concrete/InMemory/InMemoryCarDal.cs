using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;
        public InMemoryCarDal()
        {
            cars = new List<Car> 
            {
                new Car {Id=1,BrandId=1,ColorId=1,DailyPrice=500,CarDescription="Hatasız",ModelYear="2020" },
                new Car {Id=2,BrandId=2,ColorId=1,DailyPrice=400,CarDescription="Çıtır Hasarlı",ModelYear="2017" },
                new Car {Id=3,BrandId=3,ColorId=2,DailyPrice=300,CarDescription="Ağır Hasarlı",ModelYear="2013" }
            };
        }
        public void Add(Car car)
        {
            cars.Add(car);
            
        }

        public void Delete(int id)
        {
             Car carToDelete = cars.First(c => c.Id == id);
             cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return cars.First(c=>c.Id == id); 
            
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = cars.First(c => c.Id == car.Id);
            carToUpdate = car;
        }

     
    }
}
