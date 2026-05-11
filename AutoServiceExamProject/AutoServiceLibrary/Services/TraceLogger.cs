using System.Diagnostics;

namespace AutoServiceLibrary.Services;

/// <summary>Настраивает запись Trace-сообщений в текстовый файл.</summary>
public static class TraceLogger
{
    private static bool isConfigured = false;

    public static void Configure()
    {
        if (isConfigured)
            return;

        string path = Path.Combine(AppContext.BaseDirectory, "autoservice_log.txt");

        Trace.Listeners.Add(new TextWriterTraceListener(path));
        Trace.AutoFlush = true;

        isConfigured = true;

        Debug.WriteLine($"Debug: Trace файл будет создан тут: {path}");
        Trace.WriteLine($"Trace: логирование настроено. Файл: {path}");
    }
}
