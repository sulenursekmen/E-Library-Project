﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Domain.Entities
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string? ConfirmCode { get; set; }
        public bool? IsActive { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        public ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>(); 
    }
}
