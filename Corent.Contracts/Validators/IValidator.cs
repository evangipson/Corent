namespace Corent.Contracts.Validators
{
    /// <summary>
    /// A base contract for any validator.
    /// </summary>
    /// <typeparam name="ValidatorType">
    /// The type of object to be validated.
    /// </typeparam>
    public interface IValidator<ValidatorType>
    {
        /// <summary>
        /// Attempts to validate a <typeparamref name="ValidatorType"/>.
        /// </summary>
        /// <param name="objectToValidate">
        /// The <typeparamref name="ValidatorType"/> to validate.
        /// </param>
        /// <param name="validity">
        /// The validity of the <typeparamref name="ValidatorType"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> which contains the success status of the
        /// <typeparamref name="ValidatorType"/> validation.
        /// </returns>
        Task<bool> TryValidate(ValidatorType objectToValidate, out bool validity);
    }
}
