using DependecyInversionOverview.Models.Interfaces;

namespace DependecyInversionOverview.Models
{
    internal class TestController(ISingletonService singletonService, IScopedService scopedService, ITransientService transientService)
    {
        private readonly ISingletonService _singletonService = singletonService;
        private readonly IScopedService _scopedService = scopedService;
        private readonly ITransientService _transientService = transientService;

        public (string name, Guid instanceId) TestSingletonService()
        {
            return (_singletonService.Name, _singletonService.InstanceId);
        }

        public (string name, Guid instanceId) TestTransientService()
        {
            return (_transientService.Name, _transientService.InstanceId);
        }

        public (string name, Guid instanceId) TestScopedService()
        {
            return (_scopedService.Name, _scopedService.InstanceId);
        }
    }
}
