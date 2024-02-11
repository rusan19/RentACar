﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results
{
    public class Result : IResult
    {
        public Result(bool ısSuccess,string message):this(ısSuccess)
        {
            Message = message;   
        }

        public Result(bool ısSuccess)
        {
            IsSuccess = ısSuccess;
        }

        public bool IsSuccess { get; }
        public string Message { get; }
    }
}
