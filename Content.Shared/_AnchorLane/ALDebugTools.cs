using System.Diagnostics;
using Robust.Shared.Utility;

namespace Content.Client._AL;

public static class ALDebugTools
{
    //[Conditional("DEBUG")]
    public static void AssertContains<T>(ICollection<T> container, T value)
    {
        if (!container.Contains(value))
            throw new DebugAssertException($"The input {container} did not contain {value}");
    }
}
