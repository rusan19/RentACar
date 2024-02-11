using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailsDto> GetCustomerDetails()
        {
            using (RentACarContext context= new RentACarContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users on customer.UserId equals user.Id
                             select new CustomerDetailsDto
                             {
                                 Id = user.Id,
                                 CustomerFirstName= user.FirstName,
                                 CustomerLastName= user.LastName,
                                 CustomerEmail= user.Email,
                                 CustomerPassword= user.Password,
                                 CustomerCompanyName=customer.CompanyName,

                             };
                return result.ToList();
            }
        }
    }
}
