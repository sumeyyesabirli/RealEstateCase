using RealEstateCase.Core.Entities;

namespace RealEstateCase.Entity.Main
{
    public class PropertyImage : BaseEntity
    {
        public string ImageUrl { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }

}
