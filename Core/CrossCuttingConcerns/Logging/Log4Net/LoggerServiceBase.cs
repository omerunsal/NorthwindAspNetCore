using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using log4net;
using log4net.Repository;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
	public class LoggerServiceBase
	{
		private ILog _log;

		public LoggerServiceBase(string name)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(File.OpenRead(path: "log4net.config"));

			ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
				typeof(log4net.Repository.Hierarchy.Hierarchy));
			log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);

			_log = LogManager.GetLogger(loggerRepository.Name, name);
		}

		public bool IsInfoEnabled => _log.IsInfoEnabled;
		public bool IsDebugEnabled => _log.IsDebugEnabled;
		public bool IsWarnEnabled => _log.IsWarnEnabled;
		public bool IsFatalEnabled => _log.IsFatalEnabled;
		public bool IsErrorEnabled => _log.IsErrorEnabled;

		public void Info(object logMessage)
		{
			if (IsInfoEnabled)
			{
				_log.Info(logMessage);
			}
			if (IsDebugEnabled)
			{
				_log.Debug(logMessage);
			}
			if (IsWarnEnabled)
			{
				_log.Warn(logMessage);
			}
			if (IsFatalEnabled)
			{
				_log.Fatal(logMessage);
			}
			if (IsErrorEnabled)
			{
				_log.Error(logMessage);
			}

		}
	}
}
