using System;
using System.Collections.Generic;

namespace bikes_project.Models
{
    public partial class AdditionalEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public int IdBike { get; set; }

        public Bike IdBikeNavigation { get; set; }
    }
}
