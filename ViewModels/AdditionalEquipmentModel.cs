using System;
using System.Collections.Generic;
using bikes_project.Models;

namespace bikes_project.ViewModels
{
    public partial class AdditionalEquipmentModel
    {
        public AdditionalEquipmentModel() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
