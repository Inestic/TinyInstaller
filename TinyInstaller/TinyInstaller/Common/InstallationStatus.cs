namespace TinyInstaller.Common
{
    internal enum InstallationStatus
    {
        Idle,
        Executed,
        Completed,
        AutoInstallCountdown,
        AutoInstallExecuted,
        AutoInstallCompleted,
    }
}