using System;
using System.Collections.Generic;

namespace bikes_project.Models
{
    public partial class BikeCondition
    {
        public BikeCondition()
        {
            Bike = new HashSet<Bike>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bike> Bike { get; set; }
    }
}
