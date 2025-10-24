namespace Architecture.Core.ContextProvider
{
    public interface IContextProvider<out T> where T : class
    { 
        T Context { get; }
    }
}