using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            this.customerDal = customerDal;
            
        }
        public IResult Add(Customer customer)
        {
            customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            customerDal.Delete(id);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(customerDal.Get(c=>c.Id==id),ResultMessages.Success);
        }

        public IDataResult<List<CustomerDetailsDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailsDto>>(customerDal.GetCustomerDetails());
        }
        

        public IResult Update(Customer customer)
        {
            customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
