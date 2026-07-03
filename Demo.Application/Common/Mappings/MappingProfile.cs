using AutoMapper;
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
            var MapFromType = typeof(IMapFrom<>);
            var MappingMethodName = nameof(IMapFrom<object>.Mapping);
            bool HasInterface(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == MapFromType;
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(HasInterface))
                .ToList();

            var argumentTypes = new Type[] { typeof(Profile) };

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(MappingMethodName);

                if(methodInfo != null)
                {
                    methodInfo.Invoke(instance, new object[] { this });
                }

                else
                {
                    var interfaces = type.GetInterfaces()
                        .Where(HasInterface)
                        .ToList();
                    if (interfaces.Count > 0)
                    {
                        foreach (var @interface in interfaces)
                        {
                            var interfaceMethodInfo = @interface.GetMethod(MappingMethodName, argumentTypes);
                            interfaceMethodInfo?.Invoke(instance, new object[] { this });
                        }
                    }
                }
            }
        }
    }
}

