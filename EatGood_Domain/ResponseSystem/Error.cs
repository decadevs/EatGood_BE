﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatGood_Domain.ResponseSystem
{
    public class Error
    {
        public int Code { get; set; }
        public string? Type { get; set; }
        public string? Message { get; set; }
    }
}
