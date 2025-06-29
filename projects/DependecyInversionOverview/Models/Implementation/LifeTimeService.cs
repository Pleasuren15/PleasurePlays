using DependecyInversionOverview.Models.Interfaces;

namespace DependecyInversionOverview.Models.Implementation
{
    public class ScopedService() : IScopedService
    {
        public Guid InstanceId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = nameof(ScopedService);
        public string Description { get; set; } = "One instance for the entire application lifetime.";
    }

    public class TransientService() : ITransientService
    {
        public Guid InstanceId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = nameof(TransientService);
        public string Description { get; set; } = "A new instance is created every time the service is requested.";
    }

    public class SingletonService() : ISingletonService
    {
        public Guid InstanceId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = nameof(SingletonService);
        public string Description { get; set; } = "The same instance is used throughout a single HTTP request, but a new one is created for each new request.";
    }
}
