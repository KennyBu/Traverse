using System.IO;

namespace ConsoleApplication.Helpers
{
    public class FileSearcher : ISearcher
    {
        public string[] GetFiles(string directory)
        {
            return Directory.GetFiles(directory);
        }

        public string[] GetSubDirectories(string directory)
        {
            return Directory.GetDirectories(directory);
        }
    }
}