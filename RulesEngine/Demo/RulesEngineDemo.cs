using RulesEngine.Models;
using RulesEngine.Rules;
using RulesEngine.Services;

namespace RulesEngine.Demo;

internal class RulesEngineDemo
{
    static List<Customer> customers = new ()
        {
            new()
            {
                Name = "Adam",
                Plan = Plan.Internet,
                Years = 4,
                Coupon = new Coupon(0.05m)
            },

            new()
            {
                Name = "Bartholomew",
                Plan = Plan.Phone,
                Years = 3,
                Coupon = new Coupon(0.15m)
            },

            new()
            {
                Name = "Charles",
                Plan = Plan.PhoneAndInternet,
                Years = 1,
                Coupon = new Coupon(0.15m)
            },

            new()
            {
                Name = "Dave",
                Plan = Plan.Internet,
                Years = 5,
                Coupon = new Coupon(0.1m)
            },
        };


    public static void Run()
    {
        var discountService = new DiscountService();

        DiscountEngine discountEngine = new DiscountEngine();

        foreach (var customer in customers.OrderBy(o => o.Plan).ToList())
        {
            var discount = discountService.Calculate(customer);
            Console.WriteLine($"{customer.Name} has a plan of {customer.Plan} and a discount of {discount}");

            var discount2 = discountEngine.Run(customer);
            Console.WriteLine($"{customer.Name} has a plan of {customer.Plan} and a discount of {discount2}");

            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
