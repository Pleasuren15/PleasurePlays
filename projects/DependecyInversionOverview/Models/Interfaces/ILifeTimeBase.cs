namespace DependecyInversionOverview.Models.Interfaces
{
    /// <summary>
    /// Represents a dependency in the system.
    /// </summary>
    internal interface ILifeTimeBase
    {
        public Guid InstanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
