using System;
using System.IO;

namespace Vossie.Utilities
{
    public class LogWriter
    {
        protected string _logDirectory;

        public LogWriter(string logDirectory)
        {
            LogDirectory = logDirectory;
        }

        /// <summary>
        /// Directory to use for log files
        /// </summary>
        public string LogDirectory
        {
            get { return _logDirectory; }
            set { _logDirectory = value; }
        }

        /// <summary>
        /// Write text to the log file.
        /// File name will be set to LogDirectory + DateTime.Now.ToString("yyyyMMdd") + ".log"
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            Write(text, null);
        }

        /// <summary>
        /// Write text to the log file.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fileName"></param>
        public void Write(string text, string fileName)
        {
            String filePath;
            if (fileName == null)
            {
                filePath = LogDirectory + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            }
            else
            {
                filePath = LogDirectory;
                if (LogDirectory.LastIndexOf("\\") < (LogDirectory.Length - 1))
                {
                    filePath += "\\";
                }

                filePath += fileName;
            }

            var fileStream = new FileStream(filePath, FileMode.Append);
            Exception exception = null;

            try
            {
                var streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(text);
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                fileStream.Close();
                if (exception != null)
                {
                    throw exception;
                }
            }
        }
    }
}