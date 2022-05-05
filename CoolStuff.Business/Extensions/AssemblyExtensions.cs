using System.Reflection;

namespace CoolStuff.Business.Extensions;

public static class AssemblyExtensions
{
    public static IEnumerable<Type> SafeLoadTypes(this Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException e)
        {
            return e.Types.Where(t => t != null)!;
        }
    }

    internal static string GetResourceAsString(this Assembly assembly, string path)
    {
        using var stream = assembly.GetManifestResourceStream(path);
        using var reader = new StreamReader(stream ?? throw new InvalidOperationException());
        return reader.ReadToEnd();
    }
}