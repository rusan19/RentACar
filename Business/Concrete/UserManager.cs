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
    public class UserManager : IUserService
    {
        IUserDal userDal;

        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }
        public IResult Add(User user)
        {
            userDal.Add(user);
            return new SuccessResult(ResultMessages.Success);
        }

        public IResult Delete(int id)
        {
            userDal.Delete(id);
            return new SuccessResult(ResultMessages.Success);

        }

        public IDataResult<List<User>>GetAll()
        {
            return new SuccessDataResult<List<User>>(userDal.GetAll(),ResultMessages.Success);

        }

        public IDataResult<User>GetById(int id)
        {
            return new SuccessDataResult<User>(userDal.Get(u=>u.Id==id),ResultMessages.Success);
        }

        public IResult Update(User user)
        {
            userDal.Update(user);
            return new SuccessResult(ResultMessages.Success);
        }
    }
}
