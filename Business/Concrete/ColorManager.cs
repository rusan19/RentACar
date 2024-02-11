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
    public class ColorManager:IColorService
    {
        IColorDal colorDal;
        public ColorManager(IColorDal colorDal)
        {
            this.colorDal = colorDal;
        }

        public IResult Add(Color brand)
        {
            colorDal.Add(brand);
            return new SuccessResult(ResultMessages.Success);
           
        }

        public IResult Delete(int colorId)
        {
            colorDal.Delete(colorId);
            return new SuccessResult(ResultMessages.Success);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>> (colorDal.GetAll(),ResultMessages.Success);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(colorDal.Get(c=>c.Id==colorId),ResultMessages.Success);
        }

        public IResult Update(Color color)
        {
            colorDal.Update(color);
            return new SuccessResult(ResultMessages.Success);
        }
    }
}
