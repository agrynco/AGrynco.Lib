#region Usings
using System;
using System.Text;
#endregion

namespace AGrynco.Lib.RandomGenerators
{
    [RandomGenerator]
    public class StringRandomGenerator : BaseRandomGenerator<string>
    {
        #region Fields (private)
        private readonly char[] _consonantChars;

        private readonly Random _rnd;
        private readonly char[] _vovelChars;
        #endregion

        #region Constructors
        public StringRandomGenerator()
        {
            _rnd = new Random();
            _consonantChars = new[]
                                  {
                                      'q', 'w', 'r', 't', 'p', 's', 'd', 'f', 'g',
                                      'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm'
                                  };
            _vovelChars = new[] {'a', 'e', 'y', 'u', 'o'};
        }
        #endregion

        #region Methods (public)
        public override string Generate()
        {
            int length = _rnd.Next(3, 20);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(GetRandomChar(_consonantChars));

            bool isVolve = true;
            for (int i = 1; i < length; i++)
            {
                if (isVolve)
                {
                    stringBuilder.Append(GetRandomChar(_vovelChars));
                }
                else
                {
                    stringBuilder.Append(GetRandomChar(_consonantChars));
                }

                isVolve = !isVolve;
            }

            return stringBuilder.ToString();
        }
        #endregion

        #region Methods (private)
        private char GetRandomChar(char[] chars)
        {
            return chars[_rnd.Next(chars.GetLowerBound(0), chars.GetUpperBound(0))];
        }
        #endregion
    }
}