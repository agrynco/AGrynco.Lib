#region Usings
using System;
using System.Collections;
using System.Collections.Generic;
#endregion

namespace AGrynco.Lib.Validation
{
    public class ValidatorMetaInfoList : IEnumerable<ValidatorMetaInfo>
    {
        #region Fields (private)
        private readonly List<ValidatorMetaInfo> _items;
        #endregion

        #region Constructors
        public ValidatorMetaInfoList()
        {
            _items = new List<ValidatorMetaInfo>();
        }
        #endregion

        #region IEnumerable<ValidatorMetaInfo> Methods
        public IEnumerator<ValidatorMetaInfo> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region Methods (public)
        public void Add(ValidatorMetaInfo item)
        {
            _items.Add(item);
        }

        public IValidator[] GetValidatorsByParent(Type typeOfValidator)
        {
            List<IValidator> result = new List<IValidator>();
            foreach (ValidatorMetaInfo item in _items)
            {
                if (item.Attribute.Parent == typeOfValidator)
                {
                    result.Add(item.Validator);
                }
            }
            return result.ToArray();
        }
        #endregion
    }
}