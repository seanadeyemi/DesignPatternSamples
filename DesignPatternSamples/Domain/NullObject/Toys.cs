namespace DesignPatternSamples.Domain.NullObject
{
    public class Toys
    {
        public interface IToy
        {
            string Display();
        }
        public class RealToy : IToy
        {
            private string name;

            public string Name => name;

            public RealToy(string name)
            {
                this.name = name;
            }

            public string Display()
            {
                return $"This is a real toy called {name}.";
            }
        }
        public class NullToy : IToy
        {
            public string Name => "Unnamed";
            public string Display()
            {
                return "Sorry, this toy doesn't exist in the collection.";
            }
        }
        public class ToyCollection
        {
            private Dictionary<string, IToy> toys;

            public ToyCollection()
            {
                toys = new Dictionary<string, IToy>();
            }

            public void AddToy(IToy toy, string toyName)
            {
                //toys[toy.GetType().Name] = toy;
                toys[toyName] = toy;
            }

            public IToy GetToyByName(string name)
            {
                if (toys.ContainsKey(name))
                {
                    return toys[name];
                }
                return new NullToy();
            }
        }


    }
}
