using FluentValidation;

namespace RealEstateCase.Business.Futures.Commands.Property.AddProperty
{
    public class Validation : AbstractValidator<AddPropertyCommandRequestModel>
    {
        public Validation()
        {
            #region AddProperty Validations
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz");
            RuleFor(x => x.PropertyPrice).GreaterThan(0).WithMessage("Emlak fiyatı sıfırdan büyük olmalı");
            RuleFor(x => x.AdvertisementTypeId).NotEmpty().WithMessage("İlan tipi boş olamaz");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı ID boş olamaz");
            #endregion

            #region PropertyDetails Validations
            RuleFor(x => x.PropertyDetails.Title).NotEmpty().WithMessage("Emlak başlığı boş olamaz");
            RuleFor(x => x.PropertyDetails.Description).NotEmpty().WithMessage("Emlak açıklaması boş olamaz");
            RuleFor(x => x.PropertyDetails.Type).NotEmpty().WithMessage("Emlak tipi boş olamaz");
            RuleFor(x => x.PropertyDetails.Status).NotEmpty().WithMessage("Durum boş olamaz");
            RuleFor(x => x.PropertyDetails.Location).NotEmpty().WithMessage("Konum boş olamaz");
            RuleFor(x => x.PropertyDetails.Bedrooms).GreaterThanOrEqualTo(0).WithMessage("Yatak odası sayısı negatif olamaz");
            RuleFor(x => x.PropertyDetails.Bathrooms).GreaterThanOrEqualTo(0).WithMessage("Banyo sayısı negatif olamaz");
            RuleFor(x => x.PropertyDetails.Floors).GreaterThanOrEqualTo(0).WithMessage("Kat sayısı negatif olamaz");
            RuleFor(x => x.PropertyDetails.Garages).GreaterThanOrEqualTo(0).WithMessage("Garaj sayısı negatif olamaz");
            RuleFor(x => x.PropertyDetails.Area).GreaterThan(0).WithMessage("Alan sıfırdan büyük olmalı");
            RuleFor(x => x.PropertyDetails.Size).GreaterThan(0).WithMessage("Büyüklük sıfırdan büyük olmalı");
            RuleFor(x => x.PropertyDetails.SaleOrRentPrice).GreaterThan(0).WithMessage("Satış veya kira fiyatı sıfırdan büyük olmalı");
            RuleFor(x => x.PropertyDetails.BeforePriceLabel).NotEmpty().When(x => !string.IsNullOrEmpty(x.PropertyDetails.BeforePriceLabel)).WithMessage("Fiyat önceki etiket boş olamaz");
            RuleFor(x => x.PropertyDetails.AfterPriceLabel).NotEmpty().When(x => !string.IsNullOrEmpty(x.PropertyDetails.AfterPriceLabel)).WithMessage("Fiyat sonraki etiket boş olamaz");
            RuleFor(x => x.PropertyDetails.Address).NotEmpty().WithMessage("Adres boş olamaz");
            RuleFor(x => x.PropertyDetails.Country).NotEmpty().WithMessage("Ülke boş olamaz");
            RuleFor(x => x.PropertyDetails.City).NotEmpty().WithMessage("Şehir boş olamaz");
            RuleFor(x => x.PropertyDetails.State).NotEmpty().WithMessage("Eyalet boş olamaz");
            RuleFor(x => x.PropertyDetails.ZipCode).NotEmpty().WithMessage("Posta kodu boş olamaz");
            RuleFor(x => x.PropertyDetails.Neighborhood).NotEmpty().WithMessage("Mahalle boş olamaz");
            #endregion
        }
    }
}
