namespace DesignPatterns;

public interface ISalePricingStrategy
{
    decimal GetTotalIncludingDiscount(Sale sale);
}
