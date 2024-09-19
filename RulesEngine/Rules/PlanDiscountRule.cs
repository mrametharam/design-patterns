using RulesEngine.Models;

namespace RulesEngine.Rules;

internal class PlanDiscountRule : IDiscountRule
{
    public DiscountRule Type => DiscountRule.PlanDiscountRule;

    public decimal Apply(Customer customer, decimal currentDiscount)
    {
        decimal retVal = currentDiscount;

        if (customer.Plan is Plan.Internet or Plan.Phone)
        {
            retVal += 0.10m;
        }
        else
        {
            retVal += 0.15m;
        }

        return retVal;
    }
}
