using Core.Utilites.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        public IResult Add(Color brand);
        public IResult Delete(int colorId);
        public IResult Update(Color color);
        public IDataResult<List<Color>> GetAll();
        public IDataResult<Color>GetById(int colorId);
    }
}
