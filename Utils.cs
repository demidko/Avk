using System;
using System.Timers;

/// <summary>
/// Здесь хранятся вспомогательные методы
/// </summary>
internal static class Utils
{
    public static void Schedule(this TimeSpan timeSpan, Action f) =>
        new Timer(timeSpan.TotalMilliseconds) {AutoReset = true, Enabled = true}
            .Elapsed += (s, e) => f.Invoke();
}