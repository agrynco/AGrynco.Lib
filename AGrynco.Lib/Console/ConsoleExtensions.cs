#region Usings
using System;
#endregion

namespace AGrynco.Lib.Console
{
    public static class ConsoleExtensions
    {
        #region Static Methods (public)
        public static void DoWriteException(Exception ex)
        {
            WriteError("(" + ex.Message);

            if (ex.InnerException != null)
            {
                DoWriteException(ex.InnerException);
            }

            WriteError(")");
        }

        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public static void WriteError(string text)
        {
            WriteText(text, ConsoleColor.Red, ConsoleColor.Black);
        }

        public static void WriteError(string text, Exception ex)
        {
            WriteError(text);
            DoWriteException(ex);
        }

        public static void WriteException(Exception ex)
        {
            if (ex.InnerException == null)
            {
                WriteError(ex.Message);
            }
            else
            {
                WriteError(ex.Message, ex.InnerException);
            }
        }

        public static void WriteInfo(string text)
        {
            WriteText(text, ConsoleColor.Green, ConsoleColor.Black);
        }

        public static void WriteText(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            System.Console.BackgroundColor = backgroundColor;
            System.Console.ForegroundColor = foregroundColor;

            System.Console.WriteLine(text);

            System.Console.ResetColor();
        }

        public static void WriteWarning(string text)
        {
            WriteText(text, ConsoleColor.Yellow, ConsoleColor.Black);
        }
        #endregion
    }
}