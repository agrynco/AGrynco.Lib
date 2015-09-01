#region Usings
using System.Diagnostics;
#endregion

namespace AGrynCo.Lib.Validation
{
    public class EasyValidationResultSummary<TValidatedObject> : EasyValidationResultList<TValidatedObject>
    {
        #region Fields (private)
        private readonly EasyValidationResultList<TValidatedObject> _rows;
        #endregion

        #region Constructors
        public EasyValidationResultSummary()
        {
            _rows = new EasyValidationResultList<TValidatedObject>();
        }
        #endregion

        #region Properties (public)
        public EasyValidationResultList<TValidatedObject> Rows
        {
            [DebuggerStepThrough]
            get { return _rows; }
        }
        #endregion
    }
}