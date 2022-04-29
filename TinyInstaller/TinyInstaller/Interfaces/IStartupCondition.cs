namespace TinyInstaller.Interfaces
{
    internal interface IStartupCondition
    {
        public string Description { get; }
        public bool IsSuccessfully { get; set; }
        public string Name { get; }

        public void Invoke();

        public void TryFix();
    }
}