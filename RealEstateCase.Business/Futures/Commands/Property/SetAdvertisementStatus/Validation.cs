using FluentValidation;
using RealEstateCase.Business.Futures.Commands.Property.ApproveProperty;

namespace RealEstateCase.Business.Futures.Commands.Property.SetAdvertisementStatus
{
    public class Validation : AbstractValidator<SetAdvertisementStatusCommandRequestModel>
    {
        public Validation()
        {
            RuleFor(x => x.PropertyId)
                .NotEmpty().WithMessage("Emlak ID'si boş olamaz")
                .GreaterThan(0).WithMessage("Emlak ID'si sıfırdan büyük olmalıdır");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Geçersiz ilan durumu");
        }
    }
}
