using System.Reflection;

namespace Bjay.Api.Host;

public class VersionInfo
{
    public static string GetVersion()
    {
        return typeof(VersionInfo).Assembly.GetName().Version?.ToString()
            ?? Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
            ?? "unknown";
    }
}
