namespace ConsoleApplication.Helpers
{
    public interface ISearcher
    {
        string[] GetFiles(string directory);
        string[] GetSubDirectories(string directory);
    }
}