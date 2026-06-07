using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace Sistema.Utilidades
{
    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warn = 2,
        Error = 3,
        Fatal = 4
    }

    /// <summary>
    /// Logger minimalista con rolling files diarios. Thread-safe, sin dependencias externas.
    /// Pensado para migrar a Serilog cuando esté disponible la cadena de NuGet.
    /// </summary>
    public static class Log
    {
        private static readonly object _lock = new object();
        private static StreamWriter _writer;
        private static string _logsPath;
        private static LogLevel _minLevel = LogLevel.Info;
        private static string _currentDate = string.Empty;

        public static void Configure(string logsPath, LogLevel minLevel = LogLevel.Info)
        {
            lock (_lock)
            {
                _logsPath = logsPath;
                _minLevel = minLevel;
                Directory.CreateDirectory(_logsPath);
                OpenWriterForToday();
            }
        }

        public static void Shutdown()
        {
            lock (_lock)
            {
                if (_writer != null)
                {
                    try { _writer.Flush(); _writer.Dispose(); }
                    catch { /* ignorar */ }
                    _writer = null;
                }
            }
        }

        public static void Debug(string message) => Write(LogLevel.Debug, null, message, null);
        public static void Info(string message) => Write(LogLevel.Info, null, message, null);
        public static void Warn(string message) => Write(LogLevel.Warn, null, message, null);
        public static void Error(string message) => Write(LogLevel.Error, null, message, null);
        public static void Fatal(string message) => Write(LogLevel.Fatal, null, message, null);

        public static void Debug(string message, object properties) => Write(LogLevel.Debug, null, message, properties);
        public static void Info(string message, object properties) => Write(LogLevel.Info, null, message, properties);
        public static void Warn(string message, object properties) => Write(LogLevel.Warn, null, message, properties);
        public static void Error(string message, object properties) => Write(LogLevel.Error, null, message, properties);
        public static void Fatal(string message, object properties) => Write(LogLevel.Fatal, null, message, properties);

        public static void Error(Exception ex, string message) => Write(LogLevel.Error, ex, message, null);
        public static void Fatal(Exception ex, string message) => Write(LogLevel.Fatal, ex, message, null);

        private static void Write(LogLevel level, Exception ex, string message, object properties)
        {
            if (level < _minLevel) return;

            string line = FormatLine(level, ex, message, properties);

            lock (_lock)
            {
                try
                {
                    string today = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    if (today != _currentDate) OpenWriterForToday();
                    if (_writer != null)
                    {
                        _writer.WriteLine(line);
                        _writer.Flush();
                    }
                }
                catch
                {
                    /* no propagar excepciones de logging */
                }
            }
        }

        private static string FormatLine(LogLevel level, Exception ex, string message, object properties)
        {
            var sb = new StringBuilder(256);
            sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
            sb.Append(" [").Append(level.ToString().ToUpperInvariant()).Append("]");
            sb.Append(" [T:").Append(Thread.CurrentThread.ManagedThreadId).Append("]");
            if (!string.IsNullOrEmpty(message)) sb.Append(' ').Append(message);
            if (properties != null) AppendProperties(sb, properties);
            if (ex != null)
            {
                sb.Append(" | ex=").Append(ex.GetType().Name);
                if (!string.IsNullOrEmpty(ex.Message)) sb.Append(": ").Append(ex.Message);
                sb.Append(" | stack=").Append(ex.StackTrace);
            }
            return sb.ToString();
        }

        private static void AppendProperties(StringBuilder sb, object properties)
        {
            if (properties == null) return;
            foreach (var p in properties.GetType().GetProperties())
            {
                object val;
                try { val = p.GetValue(properties, null); }
                catch { continue; }
                sb.Append(" | ").Append(p.Name).Append('=').Append(val ?? "null");
            }
        }

        private static void OpenWriterForToday()
        {
            try
            {
                if (string.IsNullOrEmpty(_logsPath)) return;
                _currentDate = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                string filename = Path.Combine(_logsPath, "galeno-" + _currentDate + ".log");
                var stream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite | FileShare.Delete);
                _writer = new StreamWriter(stream, Encoding.UTF8);
            }
            catch
            {
                _writer = null;
            }
        }
    }
}
