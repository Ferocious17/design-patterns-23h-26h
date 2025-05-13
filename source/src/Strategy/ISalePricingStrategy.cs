namespace DesignPatterns.Strategy;
public interface ISalePricingStrategy
{
    decimal GetTotalIncludingDiscount(Sale sale);
}
