using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.CQRS.Commands.ApplicationUserCommands
{
    public class ApplicationUserRegisterCommand
    {
        //[Required(ErrorMessage ="İsim Alanı Zorunludur")]
        //[Display(Name="İsim")]
        //[MaxLength(30,ErrorMessage="İsim en fazla 30 karakter olmalı")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }

    }
}
