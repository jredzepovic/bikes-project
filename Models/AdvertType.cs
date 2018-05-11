using System;
using System.Collections.Generic;

namespace bikes_project.Models
{
    public partial class AdvertType
    {
        public AdvertType()
        {
            BikeAdvertType = new HashSet<BikeAdvertType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BikeAdvertType> BikeAdvertType { get; set; }
    }
}
