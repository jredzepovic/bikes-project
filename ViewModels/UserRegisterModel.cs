using System;
using System.Collections.Generic;

namespace bikes_project.ViewModels
{
    public partial class UserRegisterModel
    {
        public UserRegisterModel() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string County { get; set; }
    }
}
