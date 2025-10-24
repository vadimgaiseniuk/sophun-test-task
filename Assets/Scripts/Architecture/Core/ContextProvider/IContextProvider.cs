namespace Architecture.Core
{
    public interface IContextProvider<out T> where T : class
    { 
        T Context { get; }
    }
}