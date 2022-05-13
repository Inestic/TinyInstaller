namespace TinyInstaller.Interfaces
{
    internal interface IStartupCondition
    {
        string Description { get; }
        bool IsSuccessfully { get; set; }
        string Name { get; }

        bool Invoke();
    }
}