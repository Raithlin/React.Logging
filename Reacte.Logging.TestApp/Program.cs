using System;
using React.Logging;

namespace React.Logging.TestApp
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Logger logger = new Logger("testlogger.log", Logger.Level.Info);

			logger.Debug("Debug Message Test");
			logger.Info("Info Message Test");
			logger.Error("Error Message Test");

			logger.Info("Demo of Logger starting");

			for (int i = 0; i < 5; i++)
			{
				logger.Info($"i = {i}");
			}

			logger.Info("Demo of logger complete");
			logger.Dispose();
		}
	}
}