using System;
using System.Collections.Generic;

namespace bikes_project.Models
{
    public partial class User
    {
        public User()
        {
            Bike = new HashSet<Bike>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Oib { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }
        public int IdCounty { get; set; }

        public County IdCountyNavigation { get; set; }
        public Role IdRoleNavigation { get; set; }
        public ICollection<Bike> Bike { get; set; }
    }
}
