﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using customer_service.Actions;

namespace customer_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateIncidentAction.ReadInput();
        }
    }
}
