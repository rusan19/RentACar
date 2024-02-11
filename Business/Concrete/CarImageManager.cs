using Business.Abstract;
using Business.Constants;
using Core.Utilites.Business;
using Core.Utilites.Helpers.FileHelper;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal carImageDal;
        IFileHelper fileHelper;
        ICarService carService;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper, ICarService carService)
        {
            this.carImageDal = carImageDal;
            this.fileHelper = fileHelper;
            this.carService = carService;

        }
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CarImageLimit(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult();

            }
            carImage.ImagePath = fileHelper.Upload(file, PathConstant.ImagesPath);
            carImage.Date = DateTime.Now;
            carImageDal.Add(carImage);
            return new SuccessResult();

        }

        public IResult Delete(int id)
        {
            var carImage = carImageDal.Get(c => c.Id == id);
            fileHelper.Delete(Path.Combine(PathConstant.ImagesPath, carImage.ImagePath));
            carImageDal.Delete(id);
            return new SuccessResult();

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var car = carService.GetById(carId);
            if (car.Data!=null)
            {
                var result = BusinessRules.Run(CheckCarImage(carId));
                if (result == null)
                {
                    return GetDefaultCarImage(carId);
                }
                return new SuccessDataResult<List<CarImage>>(carImageDal.GetAll(c => c.CarId == carId));
            }
            return new ErrorDataResult<List<CarImage>>("Sistemde böyle bir araba yok");
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = fileHelper.Update(file, Path.Combine(PathConstant.ImagesPath, carImage.ImagePath), PathConstant.ImagesPath);
            carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CarImageLimit(int carId)
        {
            if (carImageDal.GetAll(c => c.CarId == carId).Count >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckCarImage(int carId)
        {
            var result = carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> GetDefaultCarImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();
            var carImage = new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" };
            carImages.Add(carImage);
            return new SuccessDataResult<List<CarImage>>(carImages);
        }


    }
}
