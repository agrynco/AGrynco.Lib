using System;

namespace AGrynco.Lib.Data.Repository
{
    [Serializable]
    public class IdentifierInt : BaseMultiKey
    {
        #region Constructors
        public IdentifierInt()
        {
            this.Value = null;
        }

        public IdentifierInt(Int64? value)
        {
            this.Value = value;
        }

        public IdentifierInt(string value) : base(value)
        {
        }
        #endregion

        #region Methods (public)
        public override object Clone()
        {
            return new IdentifierInt(this.Value);
        }

        public override bool IsEquals(BaseMultiKey multiKey)
        {
            return this.Value == ((IdentifierInt) multiKey).Value;
        }
        #endregion

        #region Methods (protected)
        protected override IKey[] BuildPrimaryKeys()
        {
            return new IKey[]
                       {
                           new KeyInt()
                       };
        }
        #endregion

        #region Properties (public)
        public Int64? Value
        {
            get { return (Int64?)this[KeyInt.IDENTIFIER_KEY_NAME].Value; }
            set { this[KeyInt.IDENTIFIER_KEY_NAME].Value = value; }
        }
        #endregion
    }
}