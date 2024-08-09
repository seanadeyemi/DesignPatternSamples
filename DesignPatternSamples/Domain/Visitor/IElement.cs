namespace DesignPatternSamples.Domain.Visitor
{
    using System;

    // Visitor pattern example
    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    class ConcreteElementA : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void OperationA()
        {
            Console.WriteLine("ConcreteElementA operation");
        }
    }

    class ConcreteElementB : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void OperationB()
        {
            Console.WriteLine("ConcreteElementB operation");
        }
    }

    interface IVisitor
    {
        void Visit(ConcreteElementA element);
        void Visit(ConcreteElementB element);
    }

    class ConcreteVisitor : IVisitor
    {
        public void Visit(ConcreteElementA element)
        {
            Console.WriteLine("Visitor visiting ConcreteElementA");
            element.OperationA();
        }

        public void Visit(ConcreteElementB element)
        {
            Console.WriteLine("Visitor visiting ConcreteElementB");
            element.OperationB();
        }
    }


}
