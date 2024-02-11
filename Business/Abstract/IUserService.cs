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
    public interface IUserService
    {
        public IResult Add(User user);
        public IResult Delete(int id);
        public IResult Update(User user);
        public IDataResult<User>GetById(int id);
        public IDataResult<List<User>> GetAll();
      
    }
}
