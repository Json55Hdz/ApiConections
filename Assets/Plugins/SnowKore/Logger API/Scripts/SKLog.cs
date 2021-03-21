using System.Threading;
using UnityEngine;

namespace SnowKore.Logger
{
    public static class SKLog
    {
        static Thread mainThread = Thread.CurrentThread;
        private static LoggerConfig config;

        private static LoggerConfig Config
        {
            get
            {
                if (config == null)
                    config = Resources.Load<LoggerConfig>("LoggerConfig");

                return config;
            }
        }

        public static void Log(string message, LogCategory category = LogCategory.TEST, LogType type = LogType.LOG)
        {
            if (Thread.CurrentThread != mainThread)
                LogInMainThread(message, category, type);
            else
                LogInOtherThread(message, category, type);
        }

        private static void LogInMainThread(string message, LogCategory category, LogType type)
        {
            if (!Config.IsEnabled(category))
                return;

            string finalMessage = "";
            finalMessage += "<color=#" + ColorUtility.ToHtmlStringRGB(Config.GetCategoryColor(category)) + ">";
            finalMessage += "[" + category.ToString() + "]" + "</color>";
            finalMessage += " " + message;

            SendLog(finalMessage, type);
        }

        private static void LogInOtherThread(string message, LogCategory category, LogType type)
        {
            string finalMessage = "";
            finalMessage += "[" + category.ToString() + "] ";
            finalMessage += message;
            SendLog(finalMessage, type);
        }

        public static void LogWarning(string message, LogCategory category = LogCategory.UNCATEGORIZED)
        {
            Log(message, category, LogType.WARNING);
        }

        public static void LogError(string message, LogCategory category = LogCategory.UNCATEGORIZED)
        {
            Log(message, category, LogType.ERROR);
        }

        private static void SendLog(string finalMessage, LogType type)
        {
            switch (type)
            {
                case LogType.LOG:
                    Debug.Log(finalMessage);
                    break;
                case LogType.WARNING:
                    Debug.LogWarning(finalMessage);
                    break;
                case LogType.ERROR:
                    Debug.LogError(finalMessage);
                    break;
            }
        }
    }
}
