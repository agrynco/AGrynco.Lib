#region Usings
using System;

using AGrynco.Lib.Exceptions;
#endregion

namespace AGrynco.Lib.Console.CommandLineParameters
{
    public abstract class BaseCommandLineParameter<TValue> : BaseClass, ICommandLineParameter<TValue>
    {
        #region Abstract Methods
        protected abstract TValue DoParseValueFromString(string value);
        #endregion

        #region Constructors
        protected BaseCommandLineParameter(string name, string example, bool required)
            : this(name, example)
        {
            Required = required;
        }

        protected BaseCommandLineParameter(string name)
            : this(name, string.Empty)
        {
            Name = name;
        }

        protected BaseCommandLineParameter(string name, string example)
        {
            Name = name;
            Example = example;
            Required = true;
        }
        #endregion

        #region ICommandLineParameter<TValue> Properties
        object ICommandLineParameter.Example
        {
            get
            {
                return Example;
            }
        }

        public string Example { get; private set; }

        public string Name { get; set; }

        object ICommandLineParameter.Value
        {
            get
            {
                return Value.ToString();
            }
        }

        public bool Required { get; set; }

        public TValue Value { get; protected set; }
        #endregion

        #region ICommandLineParameter<TValue> Methods
        public string BuildExample()
        {
            return string.Format("{0}={1}", Name, Example);
        }

        public void ParseValueFromString(string value)
        {
            try
            {
                Value = DoParseValueFromString(value);
            }
            catch (Exception ex)
            {
                throw new ParseCommandLineParameterException(Name, typeof(int), value, ex);
            }
        }
        #endregion
    }
}