namespace DesignPatterns.Tests.Strategy;

using DesignPatterns.Strategy;

using FluentAssertions;

using Microsoft.Extensions.Time.Testing;

using Moq;

public class SaleTests
{
    [Fact]
    public void GetTotal_WithPercentageStrategy_ReturnCorrectTotal()
    {
        // Arrange
        var strategy = new PercentageSalePricingStrategy(10m);
        var sale = new Sale(100m, strategy);

        // Act
        var total = sale.GetTotal();

        // Assert
        total.Should().Be(90m);
    }

    [Theory]
    [InlineData("100", "100", "90")]
    [InlineData("100", "99", "99")]
    [InlineData("100", "101", "91")]
    public void GetTotal_WithThreshold_ShouldReturnExpectedTotal(string threshold, string amount, string expectedResult)
    {
        // Arrange
        var strategy = new AbsoluteDiscountOverThresholdStrategy(decimal.Parse(threshold), 10m);
        var sale = new Sale(decimal.Parse(amount), strategy);

        // Act
        var total = sale.GetTotal();

        // Assert
        total.Should().Be(decimal.Parse(expectedResult));
    }

    [Fact]
    public void GetTotal_WhenBefore12_ThenOneTimePercentageDiscount()
    {
        // Arrange
        var timeProvider = new FakeTimeProvider();
        timeProvider.SetLocalTimeZone(TimeZoneInfo.Utc);
        timeProvider.SetUtcNow(new DateTimeOffset(2025, 05, 06, 11, 59, 0, TimeSpan.Zero));
        
        var strategy = new TimeDependentDiscountPricingStrategy(10, timeProvider);
        var sale = new Sale(100m, strategy);

        // Act
        var total = sale.GetTotal();

        // Assert
        total.Should().Be(90m);
    }

    [Fact]
    public void GetTotal_WhenAfter12_ThenTwiceTimePercentageDiscount()
    {
        // Arrange
        var timeProvider = new FakeTimeProvider();
        timeProvider.SetLocalTimeZone(TimeZoneInfo.Utc);
        timeProvider.SetUtcNow(new DateTimeOffset(2025, 05, 06, 12, 01, 0, TimeSpan.Zero));

        var strategy = new TimeDependentDiscountPricingStrategy(10, timeProvider);
        var sale = new Sale(100m, strategy);

        // Act
        var total = sale.GetTotal();

        // Assert
        total.Should().Be(80);
    }
}
