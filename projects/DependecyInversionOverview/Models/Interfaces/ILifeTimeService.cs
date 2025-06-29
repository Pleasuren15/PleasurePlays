namespace DependecyInversionOverview.Models.Interfaces
{
    internal interface IScopedService : ILifeTimeBase { }
    internal interface ITransientService : ILifeTimeBase { }
    internal interface ISingletonService : ILifeTimeBase { }
}
