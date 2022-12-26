using System.Collections.ObjectModel;
using static ASP.NET_MVC_Core_Lesson_4.ElasticsearchLogSaver;

namespace ASP.NET_MVC_Core_Lesson_4
{
    internal class _Adapter
    {
        /// <summary>
        /// Adapter
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            LogEntry logEntry = new LogEntry
            {
                DateTime = DateTime.Now,
                Message = "Hello, GeekBrains!"
            };

            LogErrorEntry logErrorEntry = new LogErrorEntry()
            {
                 DateTime = DateTime.Now,
                 Exception = new Exception("Error.")
            };

            new ElasticsearchLogSaverAdapter().Save(logErrorEntry);
            new ElasticsearchLogSaverAdapter().Save(logEntry);
            new LogSaverAdapter().Save(logEntry);

            Console.ReadKey(true);
        }
    }

    public class LogEntry : BaseLogEntry
    {
        public override DateTime DateTime { get; set; }
        public override string Message { get; set; }
    }

    public class LogErrorEntry : BaseLogEntry, IBaseErrorLogEntry
    {
        public override DateTime DateTime { get; set; }
        public override string Message { get; set; }
        public Exception Exception { get; set; }
    }

    public interface IBaseErrorLogEntry
    {
        public DateTime DateTime { get; set; }
        public Exception Exception { get; set; }
    }

    public abstract class BaseLogEntry
    {
        public abstract DateTime DateTime { get; set; }
        public abstract string Message { get; set; }
    }

    public class LogSaver
    {
        public void SaveLog(DateTime dateTime, string message)
        {
            
        }

        public void SaveException(DateTime dateTime, Exception exception)
        {
            
        }
    }

    public class ElasticsearchLogSaver
    {
        public class SimpleLogSaver
        {
            public DateTime DateTime { get; set; }
            public string Message { get; set; }

        }

        public class ExceptionLogSaver
        {
            public Exception Exception { get; set; }
            public DateTime DateTime { get; set; }
        }

        public void Save(SimpleLogSaver simpleLogSaver)
        {
            Console.WriteLine($"{simpleLogSaver.DateTime.ToShortDateString()} >>> {simpleLogSaver.Message}");
        }

        public void SaveEx(ExceptionLogSaver exceptionLogSaver)
        {
            Console.WriteLine($"{exceptionLogSaver.DateTime.ToShortDateString()} >>> {exceptionLogSaver.Exception}");
        }
    }

    #region Adapters

    public interface ILogAdapter
    {
        void Save(BaseLogEntry logEntry);
    }

    public class ElasticsearchLogSaverAdapter : ILogAdapter
    {
        private readonly ElasticsearchLogSaver elasticsearchLogSaver = new ElasticsearchLogSaver();

        public void Save(BaseLogEntry logEntry)
        {
            var errorLogEntry = logEntry as IBaseErrorLogEntry;
            if (errorLogEntry != null)
            {
                elasticsearchLogSaver.SaveEx(new ElasticsearchLogSaver.ExceptionLogSaver
                {
                    DateTime = errorLogEntry.DateTime,
                    Exception = errorLogEntry.Exception
                });
            }
            else
            {
                elasticsearchLogSaver.Save(new ElasticsearchLogSaver.SimpleLogSaver
                {
                    DateTime = logEntry.DateTime,
                    Message = logEntry.Message
                });
            }
        }
    }

    public class LogSaverAdapter : ILogAdapter
    {
        public void Save(BaseLogEntry logEntry)
        {
            
        }
    }
    #endregion
}