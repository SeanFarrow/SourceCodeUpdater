using System;
using System.Collections.Generic;
using System.Linq;
using SourceCodeUpdater.Contracts.FileSystem;
using System.IO;

namespace SourceCodeUpdater.FileSystems
{
    /// <summary>
    /// Provides access to a physical file system.
    /// </summary>
    public class SourceCodeUpdaterPhysicalFileSystem: ISourceCodeUpdaterFileSystem
    {
        /// <summary>rwww.google.co.uk
        /// Determine whether a directory exists.
        /// </summary>
        /// <param name="path">Th who existence is to be checked.</param>
        ///<exception cref="ArgumentNullException">Thrown when the <see cref="path"/> is <c>null</c>.</exception>
        ///<exception cref="ArgumentException">Thrown when the <see cref="path"/> is an empty string.</exception>
        ///<returns><c>true</c> if the directory exists, <c>false</c> otherwise.</returns>
        public bool DirectoryExists(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("The path passed in cannot be null.");
            }
            
            if (!path.Any())
            {
                throw new ArgumentException("The path pass in is an empty string.");
            }

            return Directory.Exists(path);
        }
        
        /// <summary>
        /// List all the directories in a parent dorectory.
        /// </summary>
        /// <param name="parentDirectory">The directory from which to list subdirectories.</param>
        ///<exception cref="ArgumentNullException">Thrown when the <see cref="path"/> is <c>null</c>.</exception>
        ///<exception cref="ArgumentException">Thrown when the <see cref="path"/> is an empty string.</exception>
        /// <returnsThe list of directories.</returns>
        public IEnumerable<string> EnumerateDirectories(string parentDirectory)
        {
            if (parentDirectory == null)
            {
                throw new ArgumentNullException("The parent directory passed in cannot be null.");
            }

            if (!parentDirectory.Any())
            {
                throw new ArgumentException("The parent directory pass in is an empty string.");
            }

            return Directory.GetDirectories(parentDirectory);
        }
    }
}
