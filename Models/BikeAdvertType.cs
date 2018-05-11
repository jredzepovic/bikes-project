using System;
using System.Collections.Generic;

namespace bikes_project.Models
{
    public partial class BikeAdvertType
    {
        public int IdBike { get; set; }
        public int IdAdvertType { get; set; }

        public AdvertType IdAdvertTypeNavigation { get; set; }
        public Bike IdBikeNavigation { get; set; }
    }
}
