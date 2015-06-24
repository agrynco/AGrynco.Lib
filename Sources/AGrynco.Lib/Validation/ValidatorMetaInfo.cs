#region Usings
#endregion

#region Usings
#endregion

namespace AGrynco.Lib.Validation
{
    public class ValidatorMetaInfo
    {
        #region Fields (private)
        private readonly ValidatorAttribute _attribute;
        private readonly IValidator _validator;
        #endregion

        #region Constructors
        public ValidatorMetaInfo(ValidatorAttribute attribute, IValidator validator)
        {
            _attribute = attribute;
            _validator = validator;
        }
        #endregion

        #region Properties (public)
        public ValidatorAttribute Attribute
        {
            get { return _attribute; }
        }

        public IValidator Validator
        {
            get { return _validator; }
        }
        #endregion
    }
}