using FluentValidation;

namespace RealEstateCase.Business.Futures.Commands.Property.DeleteProperty
{
    public class Validation : AbstractValidator<DeletePropertyCommandRequestModel>
    {
        public Validation()
        {
            RuleFor(x => x.PropertyId)
                .NotEmpty().WithMessage("Emlak ID'si boş olamaz")
                .GreaterThan(0).WithMessage("Emlak ID'si sıfırdan büyük olmalıdır");
        }
    }
}
