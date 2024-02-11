﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailsDto:IDto
    {
        public int CarId { get; set; }
        public string CarDescription { get; set; }
        public string CarBrandName { get; set; }
        public string CarColorName { get; set; }
    }
}