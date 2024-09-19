using RulesEngine.Models;

namespace RulesEngine.Rules;

public interface IDiscountRule
{
    DiscountRule Type { get; }
    decimal Apply(Customer customer, decimal currentDiscount);
}

public enum DiscountRule
{
    PlanDiscountRule,
    LoyaltyDiscountRule,
    CouponDiscountRule
}
