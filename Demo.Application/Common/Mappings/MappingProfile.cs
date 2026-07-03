using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Demo.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var mapFromType = typeof(IMapFrom<>);

            // 1. Correctly scan for classes that implement the interface
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == mapFromType))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                // 2. Find the interface type directly applied to this class (e.g., IMapFrom<Blog>)
                var implementedInterface = type.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapFromType);

                if (implementedInterface != null)
                {
                    // 3. Extract the "Mapping" method explicitly from the interface definition
                    var methodInfo = implementedInterface.GetMethod(nameof(IMapFrom<object>.Mapping));

                    // 4. Invoke it against the instance using the current Profile context
                    methodInfo?.Invoke(instance, new object[] { this });
                }
            }
        }
    }
}