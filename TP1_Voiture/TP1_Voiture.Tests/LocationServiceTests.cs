using FluentAssertions;
using NUnit.Framework;
using TP1_Voiture.ApiService.Features.Locations.Reserver;

namespace TP1_Voiture.Tests;

public class LocationServiceTests
{
    private LocationService _service = null!;

    [SetUp]
    public void Setup()
    {
        _service = new LocationService();
    }

    [Test]
    public void CalculPrix_120EurosSur3Jours_Retourne360()
    {
        var debut = new DateTime(2026, 5, 1);
        var fin = new DateTime(2026, 5, 4);

        var prix = _service.CalculPrix(120m, debut, fin);

        prix.Should().Be(360m);
    }

    [Test]
    public void CalculPrix_DateFinEgaleDebut_Retourne1Jour()
    {
        var debut = new DateTime(2026, 5, 1);
        var fin = new DateTime(2026, 5, 2);

        var prix = _service.CalculPrix(50m, debut, fin);

        prix.Should().Be(50m);
    }

    [Test]
    public void CalculPrix_ChangementAnnee_RetournePrixCorrect()
    {
        var debut = new DateTime(2025, 12, 30);
        var fin = new DateTime(2026, 1, 3);

        var prix = _service.CalculPrix(100m, debut, fin);

        prix.Should().Be(400m);
    }

    [Test]
    public void CalculPrix_DateFinAvantDebut_LeveException()
    {
        var debut = new DateTime(2026, 5, 5);
        var fin = new DateTime(2026, 5, 1);

        var action = () => _service.CalculPrix(100m, debut, fin);

        action.Should().Throw<ArgumentException>();
    }
}