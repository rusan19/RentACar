using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //Console.WriteLine( rentalManager.Add(new Rental { Id = 2, CarId = 1, CustomerId = 2, RentDate = DateTime.Now }).Message);

            foreach (var i in rentalManager.GetRentalDetails().Data){
                Console.WriteLine(i.CustomerFirstName+ i.CustomerLastName);
            }

           

           
        }
    }
}