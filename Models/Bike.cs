using System;
using System.Collections.Generic;

namespace bikes_project.Models
{
    public partial class Bike
    {
        public Bike()
        {
            AdditionalEquipment = new HashSet<AdditionalEquipment>();
            BikeAdvertType = new HashSet<BikeAdvertType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TireSize { get; set; }
        public int? Speeds { get; set; }
        public decimal? Weight { get; set; }
        public string Color { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public decimal Price { get; set; }
        public int IdUser { get; set; }
        public int IdCounty { get; set; }
        public int IdBikeCondition { get; set; }
        public int IdBikeType { get; set; }

        public BikeCondition IdBikeConditionNavigation { get; set; }
        public BikeType IdBikeTypeNavigation { get; set; }
        public County IdCountyNavigation { get; set; }
        public User IdUserNavigation { get; set; }
        public ICollection<AdditionalEquipment> AdditionalEquipment { get; set; }
        public ICollection<BikeAdvertType> BikeAdvertType { get; set; }
    }
}
