﻿using RealEstateCase.Core.Entities;

namespace RealEstateCase.Entity.Main
{
    public class UserRole : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
