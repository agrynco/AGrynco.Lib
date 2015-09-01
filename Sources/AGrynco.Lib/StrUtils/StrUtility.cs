#region Usings
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using AGrynCo.Lib.Exceptions;
#endregion

namespace AGrynCo.Lib.StrUtils
{
    public static class StrUtility
    {
        #region Static Methods (private)
        private static string Format(string s, string pattern, int startPos, int level, params object[] args)
        {
            if (level == args.Length)
            {
                return string.Empty;
            }
            int patternPos = s.IndexOf(pattern, startPos);
            string pieceOfResult = s.Substring(startPos, patternPos + pattern.Length - startPos);
            string result = pieceOfResult.Replace(pattern, args[level].ToString());
            result += Format(s, pattern, patternPos + pattern.Length, level + 1, args);
            return result;
        }
        #endregion

        #region Static Methods (public)
        public static string BuildString(string part, int countOfParts)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < countOfParts; i++)
            {
                stringBuilder.Append(part);
            }
            return stringBuilder.ToString();
        }

        public static string Concat(string[] strings, int startIndex, string separator)
        {
            return Concat(strings, startIndex, strings.Length - 1, separator);
        }

        public static string Concat(string[] strings, string separator)
        {
            return Concat(strings, 0, strings.Length - 1, separator);
        }

        public static string Concat(string[] strings, int startIndex, int endIndex, string separator)
        {
            StringBuilder result = new StringBuilder();

            for (int i = startIndex; i < endIndex; i++)
            {
                result.Append(strings[i]);
                if (result.Length > 0)
                {
                    result.Append(separator);
                }
            }

            result.Append(strings[endIndex]);

            return result.ToString();
        }

        public static string Concat(object[] objects, string propertyName, string separator)
        {
            string[] strings = new string[objects.Length];

            for (int i = 0; i < objects.Length; i++)
            {
                strings[i] = PropertyValueManager.GetValue(propertyName, objects[i]).ToString();
            }

            return Concat(strings, separator);
        }

        /// <summary>
        /// Replace every pattern in string with related argument. 
        /// Count of <see cref="args"/> must be equal or less than count of <see cref="pattern"/> in input string.
        /// </summary>
        /// <param name="s">Input string</param>
        /// <param name="pattern">Pattern to replace</param>
        /// <param name="args">Arguments</param>
        /// <returns>String with replaceds <see cref="pattern"/> pattern by related argument from <see cref="args"/></returns>
        public static string Format(string s, string pattern, params object[] args)
        {
            return Format(s, pattern, 0, 0, args);
        }

        public static string GetByRegExp(string messageContent, string regExpPattern, bool throwException)
        {
            Match match = Regex.Match(messageContent, regExpPattern);
            if (!match.Success)
            {
                if (throwException)
                {
                    throw new RegularExpressionException(string.Format("Can not find value in '{0}' by pattern='{1}'", messageContent, regExpPattern));
                }

                return string.Empty;
            }

            return match.Value;
        }

        public static int IndexOfAny(string[] strings, string source, int startIndex = 0)
        {
            int result = -1;
            foreach (string str in strings)
            {
                int indexOf = source.IndexOf(str, startIndex);
                if (indexOf != -1)
                {
                    result = result == -1 ? indexOf : Math.Min(result, indexOf);
                }
            }

            return result;
        }

        public static bool IsASCII(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new NullReferenceException("String should not be null or empty");
            }
            return IsASCII(s[0]);
        }

        public static bool IsASCII(char c)
        {
            int code = Convert.ToInt32(c);
            return ((code > 32) && (code < 127)) || ((code > 127) && (code < 176));
        }

        public static string LeaveRegExp(string source, string pattern)
        {
            MatchCollection matchCollection = Regex.Matches(source, pattern);
            StringBuilder result = new StringBuilder();
            foreach (Match match in matchCollection)
            {
                result.Append(match.Value);
            }

            return result.ToString();
        }

        public static string RemoveChars(string source, params char[] charsToRemove)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in source)
            {
                if (Array.IndexOf(charsToRemove, c) == -1)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }

        public static string RemoveFirstAfterSeparator(string str, string separator)
        {
            int index = str.IndexOf(separator);
            string result = str.Remove(0, index + separator.Length);
            return result;
        }

        public static string Replace(string inputString, IList<Match> matches, string replaceOn)
        {
            if (matches.Count == 0)
            {
                return inputString;
            }

            StringBuilder newContent = new StringBuilder();
            for (int i = matches.Count - 1; i >= 0; i--)
            {
                int endIndex = matches[i].Index + matches[i].Length;

                int length = i == matches.Count - 1 ? inputString.Length - endIndex : matches[i + 1].Index - endIndex;
                newContent.Insert(0, inputString.Substring(endIndex, length));
                newContent.Insert(0, replaceOn);
            }
            newContent.Insert(0, inputString.Substring(0, matches[0].Index));

            return newContent.ToString();
        }

        public static string ToLowerFirstChar(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            return s.Substring(0, 1).ToLower() + s.Substring(1);
        }

        public static string Trim(string str)
        {
            return string.IsNullOrEmpty(str) ? str : str.Trim();
        }

        public static string[] Trim(string[] strings, params char[] trimChars)
        {
            string[] result = new string[strings.Length];
            for (int index = 0; index < strings.Length; index++)
            {
                result[index] = strings[index].Trim(trimChars);
            }
            return result;
        }

        public static string TrimStr(string str, string trimString)
        {
            string result = str;
            if (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length, result.Length - trimString.Length);
            }
            if (result.EndsWith(trimString))
            {
                result = result.Substring(0, result.Length - trimString.Length);
            }
            return result;
        }
        #endregion
    }
}