namespace Corent.Contracts.Services
{
    /// <summary>
    /// A base contract for any microservice.
    /// </summary>
    public interface IMicroservice
    {
        /// <summary>
        /// Runs when the microservice is initialized.
        /// </summary>
        void Run();
    }
}
