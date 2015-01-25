using Autofac;
using SourceCodeUpdater.Contracts.FileSystem;

namespace SourceCodeUpdater.FileSystems
{
    /// <summary>
    /// Register all available file systems.
    /// </summary>
    public class SourceCodeUpdaterFileSystemsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<SourceCodeUpdaterPhysicalFileSystem>().As<ISourceCodeUpdaterFileSystem>();
        }
    }
}