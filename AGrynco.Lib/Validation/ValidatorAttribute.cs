#region Usings
using System;
using System.Diagnostics;
#endregion

namespace AGrynco.Lib.Validation
{
    /// <summary>
    /// ������� ��� ������� ��� ������� �������� ����������� <see cref="ValidatorBase{TValidatedObj,TValidationResult}"/>/>
    /// </summary>
    public class ValidatorAttribute : Attribute
    {
        #region Fields (private)
        private readonly Type _parent;
        #endregion

        #region Constructors
        public ValidatorAttribute()
            : this(null)
        {
        }

        public ValidatorAttribute(Type dependedFrom)
        {
            _parent = dependedFrom;
        }
        #endregion

        #region Properties (public)
        public Type Parent
        {
            [DebuggerStepThrough]
            get { return _parent; }
        }
        #endregion
    }
}