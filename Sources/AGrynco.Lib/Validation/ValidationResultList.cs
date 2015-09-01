#region Usings
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
#endregion

namespace AGrynCo.Lib.Validation
{
    public class ValidationResultList<TValidatedObject, TValidationResult> : BaseClass, IValidationResult, IEnumerable<TValidationResult>
        where TValidationResult : IValidationResult
    {
        #region Methods (protected)
        protected virtual void DoOnAdded(TValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                _isValid = false;
                _failedValidationResults.Add(validationResult);
            }
        }
        #endregion

        #region Fields (private)
        private readonly List<TValidationResult> _failedValidationResults;

        private readonly List<TValidationResult> _items;

        private bool _isValid;
        #endregion

        #region Constructors
        public ValidationResultList()
        {
            _items = new List<TValidationResult>();
            _failedValidationResults = new List<TValidationResult>();
            _isValid = true;
        }

        public ValidationResultList(IEnumerable<TValidationResult> validationResults)
            : this()
        {
            AddRange(validationResults);
        }
        #endregion

        #region IValidationResult Properties
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
        }

        object IValidationResult.ValidatedObject
        {
            get
            {
                return ValidatedObject;
            }
            set
            {
                ValidatedObject = (TValidatedObject)value;
            }
        }

        string IValidationResult.ValidationMessage { get; set; }
        #endregion

        #region IEnumerable<TValidationResult> Methods
        public IEnumerator<TValidationResult> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region Methods (public)
        public void Add(TValidationResult validationResult)
        {
            _items.Add(validationResult);
            DoOnAdded(validationResult);
        }

        public void AddRange(IEnumerable<TValidationResult> validationResults)
        {
            foreach (TValidationResult validationResult in validationResults)
            {
                Add(validationResult);
            }
        }

        public void AddRange(IEnumerable<IValidationResult> validationResults)
        {
            if (validationResults == null)
            {
                return;
            }

            foreach (TValidationResult validationResult in validationResults)
            {
                Add(validationResult);
            }
        }

        public ReadOnlyCollection<TValidationResult> AsReadOnly()
        {
            return _items.AsReadOnly();
        }

        public ReadOnlyCollection<TValidationResult> FailedAsReaOnly()
        {
            return _failedValidationResults.AsReadOnly();
        }
        #endregion

        #region Properties (public)
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public TValidationResult this[int index]
        {
            get
            {
                return _items[index];
            }
        }

        public TValidatedObject ValidatedObject { get; set; }
        #endregion
    }

    public class ValidationResultList : ValidationResultList<object, IValidationResult>
    {
        #region Constructors
        public ValidationResultList()
        {
        }

        public ValidationResultList(IEnumerable<IValidationResult> validationResults)
            : base(validationResults)
        {
        }
        #endregion
    }
}