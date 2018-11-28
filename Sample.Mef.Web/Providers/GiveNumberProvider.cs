using Sample.Mef.Api;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Sample.Mef.Web.Providers
{
    public class GiveNumberProvider : IGiveNumberProvider
    {
        public GiveNumberProvider()
        {
            Compose();
        }

        [ImportMany]
        public IEnumerable<IGiveNumber> Services { get; private set; }

        public IEnumerable<(string Id, int Value)> GetNumberFromAllFoundServices()
        {
            return Services.Select(f => new { Id = f.GetType().ToString(), Value = f.GiveInt()})
                .AsEnumerable()
                .Select(c => (c.Id, c.Value))
                .ToList();
        }

        private void Compose()
        {
            // Catalogs does not exists in Dotnet Core, so you need to manage your own.
            var assemblies = new List<Assembly>() { typeof(Program).GetTypeInfo().Assembly };
            var pluginAssemblies = Directory.GetFiles("d:\\temp\\plugins\\", "*.dll", SearchOption.TopDirectoryOnly)
                .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                // Ensure that the assembly contains an implementation for the given type.
                .Where(s => s.GetTypes().Where(p=> typeof(IGiveNumber).IsAssignableFrom(p)).Any());

            assemblies.AddRange(pluginAssemblies);

            var configuration = new ContainerConfiguration()
                .WithAssemblies(assemblies);

            using (var container = configuration.CreateContainer())
            {
                Services = container.GetExports<IGiveNumber>();
            }
        }
    }

    public interface IGiveNumberProvider
    {
        IEnumerable<(string Id, int Value)> GetNumberFromAllFoundServices();
    }
}
