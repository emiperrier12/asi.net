using FluentValidation.TestHelper;
using TP1_Voiture.ApiService.Features.Locations.Reserver;

namespace TP1_Voiture.Tests;

public class ReserverRequestValidatorTests
{
    private ReserverRequestValidator _validator = null!;

    [SetUp]
    public void Setup()
    {
        _validator = new ReserverRequestValidator();
    }

    [Test]
    public void Immatriculation_FormatValide_PasErreur()
    {
        var request = new ReserverRequest("AB-123-CD", 1,
            new DateTime(2026, 5, 1),
            new DateTime(2026, 5, 5));

        var result = _validator.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(x => x.Immatriculation);
    }

    [Test]
    public void Immatriculation_FormatInvalide_RetourneErreur()
    {
        var request = new ReserverRequest("abc123", 1,
            new DateTime(2026, 5, 1),
            new DateTime(2026, 5, 5));

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(x => x.Immatriculation);
    }

    [Test]
    public void LoueurId_Absent_RetourneErreur()
    {
        var request = new ReserverRequest("AB-123-CD", 0,
            new DateTime(2026, 5, 1),
            new DateTime(2026, 5, 5));

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(x => x.LoueurId);
    }

    [Test]
    public void DateFin_AvantDateDebut_RetourneErreur()
    {
        var request = new ReserverRequest("AB-123-CD", 1,
            new DateTime(2026, 5, 5),
            new DateTime(2026, 5, 1));

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(x => x.DateFin);
    }
}