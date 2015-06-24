namespace AGrynco.Lib.Data.DataProviders
{
    public interface IDatabaseManager
    {
        string TargetDataBaseName { get; }
        void Drop();
    }
}