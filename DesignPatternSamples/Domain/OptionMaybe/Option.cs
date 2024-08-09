namespace DesignPatternSamples.Domain.OptionMaybe
{
    public class Option<T> where T : class
    {
        private readonly T value;

        private Option(T value)
        {
            this.value = value;
        }

        public static Option<T> Some(T value)
        {
            return new Option<T>(value);
        }

        public static Option<T> None()
        {
            return new Option<T>(default(T)!);
        }

        public bool HasValue => !EqualityComparer<T>.Default.Equals(value, default(T));

        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("Option has no value.");
                }
                return value;
            }
        }
    }

}
