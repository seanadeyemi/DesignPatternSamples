using System.Text;

namespace DesignPatternSamples.Domain.Observer
{

    // Observer pattern example
    public interface IObserver
    {
        string Update(string message);
    }

    public class ConcreteObserver : IObserver
    {
        private string _name;

        public ConcreteObserver(string name)
        {
            _name = name;
        }

        public string Update(string message)
        {
            return $"{_name} received message: {message}";
        }

        public string Execute<TResult>(Func<Task<TResult>> handler, string message)
        {
            return $"{_name} executed ";
        }
    }

    public class Subject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private List<string> events = new List<string>();

        List<Func<Task<dynamic>>> handlers = new List<Func<Task<dynamic>>>();


        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public string Notify(string message)
        {
            StringBuilder observerReplies = new StringBuilder();
            foreach (var observer in _observers)
            {
                var response = observer.Update(message);
                observerReplies.AppendLine(response);

            }
            return observerReplies.ToString();
        }



        public async void On<TResult>(string method, Func<Task<TResult>>? handler)
        {
            ArgumentNullException.ThrowIfNull(handler);

            Func<Task<dynamic>> dynamicHandler = async () => await handler();
            handlers.Add(dynamicHandler);
            events.Add(method);

            await Task.CompletedTask;
        }
    }

}
