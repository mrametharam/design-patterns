using RulesEngine.Models;

namespace RulesEngine.Rules;

internal class CouponDiscountRule : IDiscountRule
{
    public DiscountRule Type => DiscountRule.CouponDiscountRule;

    public decimal Apply(Customer customer, decimal currentDiscount)
    {
        decimal retVal = currentDiscount;

        if (customer.Years < 5)
        {
            if (customer.Coupon.Discount + currentDiscount > 0.2m)
            {
                retVal = 0.20m;
            }
            else
            {
                retVal += customer.Coupon.Discount;
            }
        }
        else
        {
            if (customer.Coupon.Discount + currentDiscount > 0.25m)
            {
                retVal = 0.25m;
            }
            else
            {
                retVal += customer.Coupon.Discount;
            }
        }

        return retVal;
    }
}
