namespace DesignPatternSamples.Domain.Reducer
{

    // Reducer pattern example
    public class ReducerPatternExample
    {
        // Define a state structure
        public class AppState
        {
            public int Counter { get; set; }
        }

        // Define possible actions
        public enum ActionType
        {
            Increment,
            Decrement
        }

        // Reducer function
        public static AppState Reducer(AppState state, ActionType action)
        {
            switch (action)
            {
                case ActionType.Increment:
                    return new AppState { Counter = state.Counter + 1 };
                case ActionType.Decrement:
                    return new AppState { Counter = state.Counter - 1 };
                default:
                    return state;
            }
        }


    }

}
