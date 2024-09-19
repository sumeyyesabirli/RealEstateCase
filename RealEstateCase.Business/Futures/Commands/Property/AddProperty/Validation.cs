using FluentValidation;

namespace RealEstateCase.Business.Futures.Commands.Property.AddProperty
{
    public class Validation : AbstractValidator<AddPropertyCommandRequestModel>
    {
        public Validation()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.AdvertisementTypeId).NotEmpty();
            RuleForEach(x => x.PropertyDetails.Title).NotEmpty();
        }
    }
}
   