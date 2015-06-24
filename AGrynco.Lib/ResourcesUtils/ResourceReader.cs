#region Usings
using System;
using System.IO;
using System.Reflection;
using System.Text;
#endregion

namespace AGrynco.Lib.ResourcesUtils
{
    public static class ResourceReader
    {
        #region Static Methods (public)
        public static Stream GetStream(Type resourceIdentifierType, string name)
        {
            Assembly executeingAssembly = Assembly.GetAssembly(resourceIdentifierType);
            Stream stream = executeingAssembly.GetManifestResourceStream(name);
            if (stream == null)
            {
                throw new NullReferenceException(string.Format("There is no embedded resource with name '{0}'",
                                                               name));
            }
            return stream;
        }

        public static byte[] ReadAsBytes(Type resourceIdentifierType, string name)
        {
            Stream stream = GetStream(resourceIdentifierType, name);

            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        public static string ReadAsString(Type resourceIdentifierType, string name)
        {
            return ReadAsString(resourceIdentifierType, name, Encoding.Default);
        }

        public static string ReadAsString(Type resourceIdentifierType, string name, Encoding encoding)
        {
            Stream stream = GetStream(resourceIdentifierType, name);
            StreamReader sr = new StreamReader(stream, encoding);
            return sr.ReadToEnd();
        }
        #endregion
    }
}