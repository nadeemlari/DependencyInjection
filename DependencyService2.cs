using System;

namespace DependencyInjection
{
    public class DependencyService2
    {
        private readonly IOperationSingletonInstance _singletoninstance;
        private readonly IOperationTransient _transent;
        private readonly IOpertionScoped _scoped;
        private readonly IOperationSingleton _ingleton;

        public DependencyService2(IOperationSingletonInstance singletoninstance,IOperationTransient transient,IOpertionScoped scoped,IOperationSingleton singleton)
        {
            _singletoninstance = singletoninstance;
            _transent = transient;
            _scoped = scoped;
            _ingleton = singleton;
        }

        public void Write()
        {
            Console.WriteLine();
            Console.WriteLine($"From {GetType().Name} ");
            Console.WriteLine($"Transient : {_transent.OperationId }");
            Console.WriteLine($"Scoped : {_scoped.OperationId }");
            Console.WriteLine($"Singleton : {_ingleton.OperationId }");
            Console.WriteLine($"Singleton  Instance : {_singletoninstance.OperationId }");

        }
    }
}
