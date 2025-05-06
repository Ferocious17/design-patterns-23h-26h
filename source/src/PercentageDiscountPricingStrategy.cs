namespace DesignPatterns.Strategy;
public class PercentageDiscountPricingStrategy : ISalePricingStrategy
{
    private readonly decimal _percentage;

    public PercentageDiscountPricingStrategy(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal GetTotalIncludingDiscount(Sale sale)
    {
        return sale.Amount - sale.Amount / 100 * _percentage;
    }
}
