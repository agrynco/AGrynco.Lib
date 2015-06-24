#region Usings
using System.Text.RegularExpressions;
#endregion

namespace AGrynco.Lib.Validation
{
    public class EasyRegularExpressionValidator : EasyValidatorBase<string>
    {
        #region Fields (private)
        private readonly string _pattern;
        #endregion

        #region Constructors
        public EasyRegularExpressionValidator(string pattern, string validationMessage) : base(validationMessage)
        {
            _pattern = pattern;
        }
        #endregion

        #region Methods (protected)
        protected override bool DoValidate(string obj)
        {
            Match match = Regex.Match(obj, _pattern);
            return match.Success;
        }
        #endregion
    }
}