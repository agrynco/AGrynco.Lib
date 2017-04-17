namespace AGrynCo.Lib.Data.DataProviders
{
    public interface IDatabaseManager
    {
        string TargetDataBaseName { get; }
        void Drop();
        void CleanUp();
    }
}