using System;
using System.Collections.Generic;
using bikes_project.Models;

namespace bikes_project.ViewModels
{
    public partial class AddAdvertModel
    {
        public AddAdvertModel() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TireSize { get; set; }
        public int Speeds { get; set; }
        public decimal Weight { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string County { get; set; }
        public string Condition { get; set; }
        public string Type { get; set; }
        public IList<AdditionalEquipmentModel> AdditionalEquipment { get; set; }
        public IList<AdvertTypeModel> AdvertTypes { get; set; }
    }
}
