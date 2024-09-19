using RulesEngine.Models;
using System.Reflection;

namespace RulesEngine.Rules;

internal class DiscountEngine
{
    private IEnumerable<IDiscountRule> _rules;

    public DiscountEngine()
    {
        _rules = GetRules();
    }

    public decimal Run(Customer customer)
    {
        decimal retVal = 0;

        foreach(var rule in _rules)
        {
            retVal = rule.Apply(customer, retVal);
        }

        return retVal;
    }

    private static IEnumerable<IDiscountRule> GetRules()
    {
        var type = typeof(IDiscountRule);

        var rules = Assembly
            .GetExecutingAssembly()
        .GetTypes()
        .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
        .Select(x => Activator.CreateInstance(x) as IDiscountRule)
        .OrderBy(x => x?.Type)
        .ToList();

        return rules ?? [];
    }
}
