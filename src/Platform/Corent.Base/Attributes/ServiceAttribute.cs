using Microsoft.Extensions.DependencyInjection;

namespace Corent.Base.Attributes
{
    /// <summary>
    /// The <c>[Service]</c> attribute which enables services
    /// to be registered with the dependency injection container,
    /// with a defined attribute target and lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ServiceAttribute(Type serviceType) : Attribute
    {
        /// <summary>
        /// The <see cref="ServiceLifetime"/> of a service,
        /// defaults to <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Singleton;

        /// <summary>
        /// The type of a service.
        /// </summary>
        public Type ServiceType { get; set; } = serviceType;
    }
}
