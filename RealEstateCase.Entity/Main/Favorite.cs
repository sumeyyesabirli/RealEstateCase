﻿using RealEstateCase.Core.Entities;

namespace RealEstateCase.Entity.Main
{
    public class Favorite : BaseEntity
    {   
        public int UserId { get; set; }
        public User User { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
