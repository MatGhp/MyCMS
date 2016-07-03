using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.Mappers;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Web;
using MyCMS.ServiceLayer.AutoMapperProfiles;
namespace MyCMS.Web.IocConfig
{
    public class AutomapperRegistry : Registry
    {
        public AutomapperRegistry()
        {
            var platformSpecificRegistry = PlatformAdapter.Resolve<IPlatformSpecificMapperRegistry>();
            platformSpecificRegistry.Initialize();

            For<ConfigurationStore>().Singleton().Use<ConfigurationStore>()
                .Ctor<IEnumerable<IObjectMapper>>().Is(MapperRegistry.Mappers);

            For<IConfigurationProvider>().Use(ctx => ctx.GetInstance<ConfigurationStore>());

            For<IConfiguration>().Use(ctx => ctx.GetInstance<ConfigurationStore>());

            For<ITypeMapFactory>().Use<TypeMapFactory>();

            For<IMappingEngine>().Singleton().Use<MappingEngine>()
                                 .SelectConstructor(() => new MappingEngine(null));

            this.Scan(scanner =>
            {
                scanner.AssemblyContainingType<PostProfile>();
                scanner.AddAllTypesOf<Profile>().NameBy(item => item.Name);

                //scanner.AssemblyContainingType<CommentProfile>();
                //scanner.AddAllTypesOf<Profile>().NameBy(item => item.Name);
                //scanner.AssembliesFromApplicationBaseDirectory();

                scanner.ConnectImplementationsToTypesClosing(typeof(ITypeConverter<,>))
                       .OnAddedPluginTypes(t => t.HybridHttpOrThreadLocalScoped());

                //scanner.ConnectImplementationsToTypesClosing(typeof(ValueResolver<,>))
                //    .OnAddedPluginTypes(t => t.HybridHttpOrThreadLocalScoped());
            });
        }
    }
}