using System;

namespace DependencyInjection
{
    public interface IOperation
    {
        Guid OperationId { get;}
    }
    public interface IOperationTransient : IOperation
    {
                
    }
    public   interface IOpertionScoped: IOperation
    {
            
    }
    public  interface IOperationSingleton: IOperation   
    {
        
    }
    public interface IOperationSingletonInstance: IOperation
    {
        
    }
    public class Operation : IOperationTransient,  IOpertionScoped, IOperationSingleton, IOperationSingletonInstance
    {
        public Operation():this(Guid.NewGuid())
        {
                
        }
        public Operation(Guid guidId)
        {
            OperationId = guidId;
        }
        
        public Guid OperationId { get;  }
    }
   
}
