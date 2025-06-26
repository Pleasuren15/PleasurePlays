namespace CustomCLI.Services
{
    /// <summary>
    /// Interface for a service that sends SMS messages using Infobip API.
    /// </summary>
    internal interface IInfobioService
    {
        /// <summary>
        /// Interface for a service that sends SMS messages using Infobip API.
        /// </summary>
        /// <returns></returns>
        public Task SendJokeToRecipientAsync();
    }
}
