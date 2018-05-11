using System;
using System.Collections.Generic;

namespace bikes_project.Models
{
    public partial class BikeType
    {
        public BikeType()
        {
            Bike = new HashSet<Bike>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bike> Bike { get; set; }
    }
}
