﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess.DataModels
{
    public class CareProvider : Person
    {
        public string ClinicName { get; set; }
        public string CareRoleDescription { get; set; }
    }
}