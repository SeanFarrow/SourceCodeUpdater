using System;
using System.Collections.Generic;

namespace SourceCodeUpdater.Contracts.FileSystem
{
    /// <summary>
    /// Provides access to a FileSystem.
    /// </summary>
    public interface ISourceCodeUpdaterFileSystem
    {
        /// <summary>rwww.google.co.uk
        /// Determine whether a directory exists.
        /// </summary>
        /// <param name="path">Th who existence is to be checked.</param>
        ///<exception cref="ArgumentNullException">Thrown when the <see cref="path"/> is <c>null</c>.</exception>
        ///<exception cref="ArgumentException">Thrown when the <see cref="path"/> is an empty string.</exception>
        ///<returns><c>true</c> if the directory exists, <c>false</c> otherwise.</returns>
        bool DirectoryExists(string path);

        /// <summary>
        /// List all the directories in a parent dorectory.
        /// </summary>
        /// <param name="parentDirectory">The directory from which to list subdirectories.</param>
        ///<exception cref="ArgumentNullException">Thrown when the <see cref="path"/> is <c>null</c>.</exception>
        ///<exception cref="ArgumentException">Thrown when the <see cref="path"/> is an empty string.</exception>
        /// <returnsThe list of directories.</returns>
        IEnumerable<String> EnumerateDirectories(string parentDirectory);
    }
}
