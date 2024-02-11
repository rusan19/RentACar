using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this.rentalDal = rentalDal; 
        }
        public IResult Add(Rental rental) //araba kiralama metodu
        {
            var isCarRented = rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (isCarRented != null)
            {
                return new ErrorResult(ResultMessages.Error);
            }
            rental.RentDate= DateTime.Now; 
            rentalDal.Add(rental);
            return new SuccessResult(ResultMessages.Success);
        }

        public IResult Delete(int id)
        {
            rentalDal.Delete(id);
            return new SuccessResult(ResultMessages.Success);
        }

        public IDataResult<List<Rental>> GetAll()
        {
           return new SuccessDataResult<List<Rental>>(rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(rentalDal.Get(r=>r.Id==rentalId));
        }

        public IDataResult<List<RentalDetailsDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            rentalDal.Update(rental);
            return new SuccessResult(ResultMessages.Success);
        }

        public IResult UpdateReturnDate(int carId)
        {
            var result = rentalDal.Get(r => r.CarId==carId&&r.ReturnDate==null);//arabayı teslim etme metodu
            if(result != null)
            {
                result.ReturnDate = DateTime.Now;
                rentalDal.Update(result);
                return new SuccessResult(ResultMessages.Success);
            }
          
            return new ErrorResult(ResultMessages.Error);
        }
    }
}
