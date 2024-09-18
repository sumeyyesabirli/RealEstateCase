using FluentValidation;

namespace RealEstateCase.Business.Futures.Commands.Product.AddProduct
{
    public class Validation : AbstractValidator<AddProductCommandRequestModel>
    {
        public Validation()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleForEach(x => x.ProductDetails.Title).NotEmpty();
        }
    }
}
   