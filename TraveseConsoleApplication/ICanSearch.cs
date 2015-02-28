using System.Collections.Generic;

namespace ConsoleApplication
{
    public interface ICanSearch
    {
        IEnumerable<string> Find(string folder);
    }
}