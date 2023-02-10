using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api.Intuit.Application.Models.Clients.Request.Validations
{
    public class PostClientRequestModelValidation : AbstractValidator<PostClientRequestModel>
    {
        public PostClientRequestModelValidation()
        {
            RuleFor(model => model.name)
                .NotNull().WithMessage("El nombre es obligatorio...")
                .Length(3, 30).WithMessage("El nombre debe tener entre 3 y 30 caracteres...")
                .Must(name => ValidationName(name)).WithMessage("El nombre solo puede tener letras y apostrofes");
            RuleFor(x => x.surname).NotEmpty().NotNull().WithMessage("El apellido es requerido");
            RuleFor(x => x.birthdate).NotEmpty().WithMessage("La fecha de nacimiento es requerida");
            RuleFor(x => x.birthdate)
           .Must(ValidDate)
           .WithMessage("El campo fecha de nacimiento debe ser una fecha válida");
            RuleFor(x => x.cuit).NotEmpty().WithMessage("El cuit es requerido").Length(11, 13);
            RuleFor(x => x.address).NotEmpty().WithMessage("La direccion es requerida");
            RuleFor(x => x.phone).NotEmpty().NotNull().WithMessage("El telefono es requerido");
            RuleFor(model => model.email)
               .NotNull().WithMessage("El email es obligatorio")
               .Length(4, 60).WithMessage("El email debe tener entre 3 y 60 caracteres...")
               .Must(email => EmailFormatValid(email)).WithMessage("El formato del Email es invalido");
        }

        private bool EmailFormatValid(string email)
        {
            return Regex.Match(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$").Success;
        }
        private bool ValidationName(string nombre)
        {
            //Controlamos que no tengan los siguientes simbolos
            return !Regex.IsMatch(nombre, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
        }
        private bool ValidDate(DateTime birthdate)
        {
            return birthdate != default(DateTime);
        }
    }
}
