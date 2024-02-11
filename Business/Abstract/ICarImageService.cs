using Core.Utilites.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        public IResult Add(IFormFile file, CarImage carImage);
        public IResult Delete(int id);
        public IResult Update(IFormFile file, CarImage CarImage);
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        public IDataResult<List<CarImage>> GetAll();
    }
}
