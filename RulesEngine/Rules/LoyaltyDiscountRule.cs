using RulesEngine.Models;

namespace RulesEngine.Rules;

internal class LoyaltyDiscountRule : IDiscountRule
{
    public DiscountRule Type => DiscountRule.LoyaltyDiscountRule;

    public decimal Apply(Customer customer, decimal currentDiscount)
    {
        decimal retVal = currentDiscount;

        if (customer.Years > 3)
        {
            retVal += 0.05m;
        }

        return retVal;
    }
}
