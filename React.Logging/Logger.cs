using System;
using System.IO;

namespace React.Logging
{
	public partial class Logger : IDisposable
	{
		private readonly string logFile;
		private readonly Level level;
		private bool disposedValue;

		public Logger(string filePath, Logger.Level logLevel)
		{
			logFile = filePath;
			level = logLevel;

			if (!File.Exists(filePath))
				using (StreamWriter newFile = File.CreateText(filePath))
				{
					newFile.Write("");
				}

			WriteToFile("Logger Initialized");
		}

		public void Info(string message)
		{
			if (level >= Level.Info)
				WriteToFile($"INF {message}");
		}

		public void Debug(string message)
		{
			if (level >= Level.Debug)
				WriteToFile($"DBG {message}");
		}

		public void Error(string message)
		{
			if (level >= Level.Error)
				WriteToFile($"ERR {message}");
		}

		private void WriteToFile(string text)
		{
			using (StreamWriter file = File.AppendText(logFile))
			{
				file.WriteLine($"{DateTime.Now:yyyy.MM.dd HH:mm:ss} {text}");
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// Managed objects disposed here. Nothing to see, move along.
				}
				WriteToFile("Logger Destroyed");
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}