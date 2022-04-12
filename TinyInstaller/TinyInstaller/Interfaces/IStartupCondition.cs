namespace TinyInstaller.Interfaces
{
    internal interface IStartupCondition
    {
        public string Description { get; set; }
        public bool IsSuccessfully { get; set; }
        public string Name { get; set; }

        public bool Invoke();

        public void TryFix();
    }
}