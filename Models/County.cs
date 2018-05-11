using System;
using System.Collections.Generic;

namespace bikes_project.Models
{
    public partial class County
    {
        public County()
        {
            Bike = new HashSet<Bike>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bike> Bike { get; set; }
        public ICollection<User> User { get; set; }
    }
}
