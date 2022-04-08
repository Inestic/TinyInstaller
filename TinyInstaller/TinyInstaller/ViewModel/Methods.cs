using System.Threading.Tasks;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private async void Invoke()
        {
            await Task.Run(() =>
            {
                LocalizationHelper.Invoke();
                ActiveView = StartupConditionsHelper.Invoke();
            });
        }
    }
}