namespace DesignPatterns.Strategy;
public class PercentageSalePricingStrategy : ISalePricingStrategy
{
    private readonly decimal _percentage;

    public PercentageSalePricingStrategy(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal GetTotalIncludingDiscount(Sale sale)
    {
        return sale.Amount - sale.Amount * _percentage / 100m;
    }
}
