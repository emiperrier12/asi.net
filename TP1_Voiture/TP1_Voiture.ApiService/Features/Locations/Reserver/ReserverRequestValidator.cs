using FluentValidation;

namespace TP1_Voiture.ApiService.Features.Locations.Reserver;

public class ReserverRequestValidator : AbstractValidator<ReserverRequest>
{
    public ReserverRequestValidator()
    {
        RuleFor(x => x.Immatriculation)
            .NotEmpty().WithMessage("L'immatriculation est obligatoire.")
            .Matches(@"^[A-Z]{2}-\d{3}-[A-Z]{2}$")
            .WithMessage("Format invalide. Ex: AA-123-BB");

        RuleFor(x => x.LoueurId)
            .GreaterThan(0).WithMessage("Le LoueurId est obligatoire.");

        RuleFor(x => x.DateFin)
            .GreaterThan(x => x.DateDebut)
            .WithMessage("La date de fin doit être après la date de début.");
    }
}