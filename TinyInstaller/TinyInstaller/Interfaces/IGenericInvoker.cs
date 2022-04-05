namespace TinyInstaller.Interfaces
{
    internal interface IGenericInvoker<T>
    {
        T Invoke();
    }
}