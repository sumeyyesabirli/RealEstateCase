using RealEstateCase.Core.Entities;

namespace RealEstateCase.Entity.Main
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
