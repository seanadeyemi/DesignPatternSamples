namespace DesignPatternSamples.Domain.ChainOfResponsibility
{
    using System;

    // Chain of responsibility pattern example
    abstract class Handler
    {
        protected Handler _nextHandler;

        public void SetNextHandler(Handler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void HandleRequest(int request);
    }

    class ConcreteHandlerA : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request <= 10)
            {
                Console.WriteLine($"Request {request} handled by ConcreteHandlerA");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }

    class ConcreteHandlerB : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request > 10 && request <= 20)
            {
                Console.WriteLine($"Request {request} handled by ConcreteHandlerB");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }

    class ConcreteHandlerC : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request > 20)
            {
                Console.WriteLine($"Request {request} handled by ConcreteHandlerC");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }

    class ChainOfResponsibilityPatternExample
    {
        static void Main(string[] args)
        {

        }
    }

}
