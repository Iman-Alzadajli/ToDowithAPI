﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.UserMangment
{
    public class ApplicationUser : IdentityUser
    {
        
        public string Name { get; set; }
    }
}
