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
    public interface ICustomerService
    {
        public IResult Add(Customer customer);
        public IResult Delete(int id);
        public IResult Update(Customer customer);
        public IDataResult<List<Customer>> GetAll();
        public IDataResult<Customer> GetById(int id);
        public IDataResult<List<CustomerDetailsDto>> GetCustomerDetails();

    }
}
