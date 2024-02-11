using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailsDto:IDto
    {
        public int RentalId { get; set; }
        public string CarColorName { get; set; }
        public string CarBrandName { get; set; }
        public string CarModelYear { get; set; }
        public string CarDescription { get; set; }
        public decimal DailyPrice { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }



    }
}
