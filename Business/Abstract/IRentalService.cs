using Core.Utilites.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        public IResult Add(Rental rental);
        public IResult Delete(int id);
        public IResult Update(Rental rental);
        public IResult UpdateReturnDate(int carId);
        public IDataResult<List<Rental>> GetAll();
        public IDataResult<Rental>GetById(int rentalId);
        public IDataResult<List<RentalDetailsDto>> GetRentalDetails();
    }
}
