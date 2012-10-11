using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TuanZhang.Core
{
    public class LogHelper
    {
        public static string ApplicationName = "TuanZhang";
        /// <summary>
        /// 记录日志消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isWriteDebug">是否打印</param>
        public static void Log(string message, bool isWriteDebug = true)
        {
            using (var service = new LoggingService(ApplicationName))
            {
                service.Enable();
                service.Write(message);
                service.Dispose();
            }
            if (isWriteDebug)
            {
                WriteDebug(message);
            }
        }
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        /// <param name="isWriteDebug"></param>
        public static void Log(string message, Exception e, bool isWriteDebug)
        {
            using (var service = new LoggingService(ApplicationName))
            {
                service.Enable();
                service.Write(e.Message);
                service.Dispose();
            }
            if (isWriteDebug)
            {
                WriteDebug(message);
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="message"></param>
        public static void WriteDebug(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void LogDeviceInfo()
        {
            using (var service = new LoggingService(ApplicationName))
            {
                service.Enable();
                service.WriteDiagnostics();
                service.Dispose();
            }
        }
    }
}
