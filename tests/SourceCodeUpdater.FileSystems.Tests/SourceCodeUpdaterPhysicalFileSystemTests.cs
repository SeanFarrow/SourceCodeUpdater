using NUnit.Framework;
using System;
using System.Reflection;
using System.IO;

namespace SourceCodeUpdater.FileSystems.Tests
{
    /// <summary>
    /// Tests the <see cref"SourceCodeUpdaterFileSystem"/>
    /// </summary>
    [TestFixture]
    public class SourceCodeUpdaterPhysicalFileSystemTests
    {
        /// <summary>
        /// Test that the <see cref="DirectoryExists"/> method throws an <see cref="ArgumentNullException"/> when the <see cref="path"/> parameter is <c>null</c>.
        /// </summary>
        [Test]
        public void DirectoryExists_ThrowsAnArgumentNullExceptionWhenThePathIsNull()
        {
            SourceCodeUpdaterPhysicalFileSystem pfs =new SourceCodeUpdaterPhysicalFileSystem();
            Assert.Throws<ArgumentNullException>(() =>pfs.DirectoryExists(null));
        }
        
        /// <summary>
        /// Test that the <see cref="DirectoryExists"/> method throws an <see cref="ArgumentException"/> when the <see cref="path"/> parameter is an empty string.
        /// </summary>
        [Test]
        public void DirectoryExists_ThrowsAnArgumentExceptionWhenThePathPassedInIsAnEmptyString()
        {
            SourceCodeUpdaterPhysicalFileSystem pfs = new SourceCodeUpdaterPhysicalFileSystem();
            Assert.Throws<ArgumentException>(() => pfs.DirectoryExists(String.Empty));
        }

        /// <summary>
        /// Tests that the <see cref="DirectoryExists"/> returns <c>false</c> when the directory passed in does not exist.
        /// </summary>
        [Test]
        public void DirectoryExists_ReturnsFalseWhenTheDirectoryPassedInDoesNotExist()
        {
            string path = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath), "test");
            SourceCodeUpdaterPhysicalFileSystem pfs = new SourceCodeUpdaterPhysicalFileSystem();
            Assert.False(pfs.DirectoryExists(path));
        }
        
        /// <summary>
        /// Tests that the <see cref="DirectoryExists"/> returns <c>true</c> when the directory passed in exists.
        /// </summary>
        [Test]
        public void DirectoryExists_ReturnsTrueWhenTheDirectoryPassedInExists()
        {
            string path = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath), "test");
            Directory.CreateDirectory(path);
            SourceCodeUpdaterPhysicalFileSystem pfs = new SourceCodeUpdaterPhysicalFileSystem();
            Assert.True(pfs.DirectoryExists(path));
        Directory.Delete(path);
        }
        
        /// <summary>
        /// Test that the <see cref="EnumerateDirectories"/> method throws an <see cref="ArgumentNullException"/> when the <see cref="parentDirectory"/> parameter is <c>null</c>.
        /// </summary>
        [Test]
        public void EnumerateDirectories_ThrowsAnArgumentNullExceptionWhenTheParentDirectoryIsNull()
        {
            SourceCodeUpdaterPhysicalFileSystem pfs = new SourceCodeUpdaterPhysicalFileSystem();
            Assert.Throws<ArgumentNullException>(() => pfs.EnumerateDirectories(null));
        }
        
        /// <summary>
        /// Test that the <see cref="EnumerateDirectories"/> method throws an <see cref="ArgumentException"/> when the <see cref="parentDirectory"/> parameter is an empty string.
        /// </summary>
        [Test]
        public void EnumerateDirectories_ThrowsAnArgumentExceptionWhenTheParentDirectoryPassedInIsAnEmptyString()
        {
            SourceCodeUpdaterPhysicalFileSystem pfs = new SourceCodeUpdaterPhysicalFileSystem();
            Assert.Throws<ArgumentException>(() => pfs.EnumerateDirectories(String.Empty));
        }
        
        /// <summary>
        /// Test that the <see cref="EnumerateDirctories"/> returns an empty collection if the <c>parentDirectory</c> passed in contains no directories.
        /// </summary>
        [Test]
        public void EnumerateDirectories_ReturnsAnEmptyCollectionIfTheParentDirectoryContainsNoDirectories()
        {
            string path = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath), "test");
            Directory.CreateDirectory(path);
            SourceCodeUpdaterPhysicalFileSystem pfs =new SourceCodeUpdaterPhysicalFileSystem();           
            Assert.IsEmpty(pfs.EnumerateDirectories(path));
        Directory.Delete(path);
        }
        /// <summary>
        /// Test that the <see cref="EnumerateDirectories/> method returns a populated collection when the parent directory passed in contains directories.
        /// </summary>
        [Test]
        public void EnumerateDirectories_ReturnsAPopulatedCollectionWhenDirectoriesExistInTheParentDirectoryPassedIn()
        {
            string path = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            int lastBackslashIndex = path.LastIndexOf('\\');
            path =path.Remove(lastBackslashIndex);
            SourceCodeUpdaterPhysicalFileSystem pfs =new SourceCodeUpdaterPhysicalFileSystem();
            Assert.IsNotEmpty(pfs.EnumerateDirectories(path));
        }
    }
}