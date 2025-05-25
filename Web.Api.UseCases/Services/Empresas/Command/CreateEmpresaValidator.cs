using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.UseCases.Services.Empresas.Command
{
    public class CreateEmpresaValidator : AbstractValidator<CreateEmpresaCommand>
    {
        public CreateEmpresaValidator() { 
            RuleFor(x=> x.ruc).NotEmpty().MaximumLength(11).MinimumLength(11).WithMessage("El RUC debe tener 11 digitos.");
            RuleFor(x => x.razon_social).NotEmpty().WithMessage("Ingresa la razón social.");
            RuleFor(x => x.direccion).NotEmpty().WithMessage("Ingresa la dirección."); ;
        }
    }
}
