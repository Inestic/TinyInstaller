namespace TinyInstaller.Models
{
    public abstract class ModelBase
    {
        public void Initialize<TParameter>(TParameter parameter)
        {
        }

        public void Initialize()
        {
        }
    }
}