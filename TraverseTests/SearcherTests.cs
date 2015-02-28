using System.Linq;
using ConsoleApplication;
using ConsoleApplication.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TraverseTests
{
    [TestClass]
    public class SearcherTests
    {
        [TestMethod]
        public void SearcherTest()
        {
            const string directory = "c:\test";
            const string fileToFind = "test.txt";
            
            var mock = new Mock<ISearcher>();
            mock.Setup(s => s.GetFiles(directory)).Returns(new[] { fileToFind });
            mock.Setup(s => s.GetSubDirectories(directory)).Returns(new string[0]);

            var searcher = new Searcher(mock.Object);
            var results = searcher.Find(directory);

            Assert.IsTrue(results.First() == fileToFind);
        }

        [TestMethod]
        public void SearcherTestFail()
        {
            const string directory = "c:\test";

            var mock = new Mock<ISearcher>();
            mock.Setup(s => s.GetFiles(directory)).Returns(new string[0]);
            mock.Setup(s => s.GetSubDirectories(directory)).Returns(new string[0]);

            var searcher = new Searcher(mock.Object);
            var results = searcher.Find(directory);

            Assert.IsFalse(results.Any());
        }
    }
}