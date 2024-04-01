using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModels.Validations
{
    public class SalesViewModel_QuantityProper : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;

            if
                (salesViewModel != null)
            {
                if (salesViewModel.QuantityToSell <= 0)
                {
                    return new ValidationResult("The quantity being sold must exceed zero.");
                }
                else
                {
                    var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
                    if (product != null)
                    {
                        if(product.Quantity < salesViewModel.QuantityToSell)
                        {
                            return new ValidationResult($"{product.Name} has a remaining stock of {product.Quantity}.");
                        }
                    }
                    else
                    {
                        return new ValidationResult ("The poduct you have selected does not exist.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
