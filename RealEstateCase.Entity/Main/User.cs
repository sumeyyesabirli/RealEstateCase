using RealEstateCase.Core.Entities;

namespace RealEstateCase.Entity.Main
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }
}
