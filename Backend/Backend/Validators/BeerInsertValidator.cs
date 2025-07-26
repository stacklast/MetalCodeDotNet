using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators
{
    public class BeerInsertValidator: AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator() 
        {
            RuleFor(x=> x.Name).NotEmpty().WithMessage("El Nombre es obligatorio");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El Nombre debe medir de 2 a 20 caracteres");
            RuleFor(x => x.BrandID).NotNull().WithMessage(x=>"La marca es obligatoria");
            RuleFor(x => x.BrandID).GreaterThan(0).WithMessage("Error con el valor enviado en marca");
            RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage("El {PropertyName} debe ser mayor a 0");
        }
    }
}
