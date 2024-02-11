using Core.Utilites.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        public IResult Add(Brand brand);
        public IResult Delete(int brandId);
        public IResult Update(Brand brand);
        public IDataResult<Brand> GetById(int id);
        public IDataResult<List<Brand>> GetAll();
    }
}
