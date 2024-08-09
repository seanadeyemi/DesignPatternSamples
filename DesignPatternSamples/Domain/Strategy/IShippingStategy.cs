namespace DesignPatternSamples.Domain.Strategy
{
    // Strategy pattern example
    public interface IShippingStrategy
    {
        double CalculateShippingCost(double weight);
    }

    public class StandardShippingStrategy : IShippingStrategy
    {
        public double CalculateShippingCost(double weight)
        {
            return weight * 2.5;
        }
    }

    public class ExpressShippingStrategy : IShippingStrategy
    {
        public double CalculateShippingCost(double weight)
        {
            return weight * 5.0;
        }
    }

    public class ShoppingCart
    {
        private IShippingStrategy _shippingStrategy;

        public ShoppingCart(IShippingStrategy shippingStrategy)
        {
            _shippingStrategy = shippingStrategy;
        }

        public double CalculateTotalCost(double cartTotal, double weight)
        {
            double shippingCost = _shippingStrategy.CalculateShippingCost(weight);
            return cartTotal + shippingCost;
        }
    }



}
