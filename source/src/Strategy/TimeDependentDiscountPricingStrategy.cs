namespace DesignPatterns.Strategy;

using System;

public class TimeDependentDiscountPricingStrategy : ISalePricingStrategy
{
    private readonly decimal _percentage;
    private readonly TimeProvider _timeProvider;
    private readonly ISystemTime _systemTime;
    private readonly Func<DateTimeOffset> _getDateTime;

    public TimeDependentDiscountPricingStrategy(decimal percentage, Func<DateTimeOffset> getDateTime)
    {
        _percentage = percentage;
        _getDateTime = getDateTime;
    }

    public TimeDependentDiscountPricingStrategy(decimal percentage, ISystemTime systemTime)
    {
        _percentage = percentage;
        _systemTime = systemTime;
    }

    public TimeDependentDiscountPricingStrategy(decimal percentage, TimeProvider timeProvider)
    {
        _percentage = percentage;
        _timeProvider = timeProvider;
    }

    public decimal GetTotalIncludingDiscount(Sale sale)
    {
        //var dateTime = _getDateTime();
        //var dateTime = _systemTime.Now;
        var dateTime = _timeProvider.GetLocalNow();


        if (dateTime.Hour < 12)
        {
            return sale.Amount - sale.Amount / 100 * _percentage;
        }

        return sale.Amount - sale.Amount / 100 * 2 * _percentage;
    }
}
