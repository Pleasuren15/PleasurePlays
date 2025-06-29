using DependecyInversionOverview.Models.Interfaces;

namespace DependecyInversionOverview.Models
{
    internal class TestController(ISingletonService singletonService, IScopedService scopedService, ITransientService transientService)
    {
        private readonly ISingletonService _singletonService = singletonService;
        private readonly IScopedService _scopedService = scopedService;
        private readonly ITransientService _transientService = transientService;

        public void TestSingletonService()
        {
            Console.WriteLine("Name: {0}", _singletonService.Name);
            //Console.WriteLine("Description: {0}", _singletonService.Description);
            Console.WriteLine("InstanceId: {0}", _singletonService.InstanceId);
        }

        public void TestTransientService()
        {
            Console.WriteLine("Name: {0}", _transientService.Name);
            //Console.WriteLine("Description: {0}", _transientService.Description);
            Console.WriteLine("InstanceId: {0}", _transientService.InstanceId);
        }

        public void TestScopedService()
        {
            Console.WriteLine("Name: {0}", _scopedService.Name);
            //Console.WriteLine("Description: {0}", _scopedService.Description);
            Console.WriteLine("InstanceId: {0}", _scopedService.InstanceId);
        }
    }
}
