using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApplication.Helpers;

namespace ConsoleApplication
{
    public class Searcher : ICanSearch
    {
        private readonly List<string> _filenames;
        private int _deepestDepth;
        private int _currentDepth;
        private readonly ISearcher _searcher;

        public Searcher(ISearcher searcher)
        {
            _searcher = searcher;
            _filenames = new List<string>();
        }

        public IEnumerable<string> Find(string folder)
        {
            Guard.StringIsNotNullOrEmpty(folder, "folder");
            
            Search(folder);

            return _filenames;
        }

        private void Search(string folder)
        {
            _currentDepth++;
            
            var files = _searcher.GetFiles(folder);

            if (files.Any())
            {
                SetFileNames(files);    
            }
            
            var subFolders = _searcher.GetSubDirectories(folder);
            foreach (var subFolder in subFolders)
            {
                Find(subFolder);
                _currentDepth--;
            }
        }
        
        private void SetFileNames(IEnumerable<string> files)
        {
            if (_currentDepth > _deepestDepth)
            {
                _filenames.Clear();
                _deepestDepth = _currentDepth;
            }

            if (_currentDepth >= _deepestDepth)
            {
               SetFiles(files);
            }
        }

        private void SetFiles(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                _filenames.Add(Path.GetFileName(file));
            }
        }
    }
}