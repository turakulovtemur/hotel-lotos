﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelApplication.Models
{
    public class User:IdentityUser
    {
        public string PhoneNumber { get; set; }
    }
}
