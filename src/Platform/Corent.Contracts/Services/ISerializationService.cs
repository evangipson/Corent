namespace Corent.Contracts.Services
{
    /// <summary>
    /// A service that serializes and deserializes objects.
    /// </summary>
    public interface ISerializationService
    {
        /// <summary>
        /// Serializes an object of <typeparamref name="ObjectType"/>
        /// into an array of <see cref="byte"/>.
        /// </summary>
        /// <typeparam name="ObjectType">
        /// The type of object to serialize.
        /// </typeparam>
        /// <param name="objectToSerialize">
        /// The object to serialize.
        /// </param>
        /// <returns>
        /// An array of serialized <see cref="byte"/>.
        /// </returns>
        byte[] Serialize<ObjectType>(ObjectType objectToSerialize);

        /// <summary>
        /// Deserializes an array of serialized <see cref="byte"/>
        /// into an object of <typeparamref name="ObjectType"/>.
        /// </summary>
        /// <typeparam name="ObjectType">
        /// The type of object to deserialize into.
        /// </typeparam>
        /// <param name="serializedBytes">
        /// The serialized array of <see cref="byte"/> to deserialize.
        /// </param>
        /// <returns>
        /// An object of <typeparamref name="ObjectType"/> if
        /// deserialization was successful, defaults to <c>null</c>.
        /// </returns>
        ObjectType? Deserialize<ObjectType>(byte[] serializedBytes) where ObjectType : class;
    }
}
