namespace AGrynCo.Lib.Data.Repository
{
    public class DummyIdentifier : BaseMultiKey
    {
        public override object Clone()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsEquals(BaseMultiKey multiKey)
        {
            throw new System.NotImplementedException();
        }

        protected override IKey[] BuildPrimaryKeys()
        {
            return new IKey[]{};
        }
    }
}