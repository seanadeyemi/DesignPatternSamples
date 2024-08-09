namespace DesignPatternSamples.Domain.Decorator
{
    public interface IIceCream
    {
        string Make();
    }
    public class BasicIceCream : IIceCream
    {
        public string Make()
        {
            return "Basic Ice Cream";
        }
    }
    public class ChocolateFlavor : IIceCream
    {
        private readonly IIceCream iceCream;

        public ChocolateFlavor(IIceCream iceCream)
        {
            this.iceCream = iceCream;
        }

        public string Make()
        {
            return iceCream.Make() + " + Chocolate Flavor";
        }
    }

    public class SprinklesTopping : IIceCream
    {
        private readonly IIceCream iceCream;

        public SprinklesTopping(IIceCream iceCream)
        {
            this.iceCream = iceCream;
        }

        public string Make()
        {
            return iceCream.Make() + " + Sprinkles Topping";
        }
    }

}
