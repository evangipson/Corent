using System.Runtime.Serialization;

using Corent.Base.Attributes;
using Corent.Contracts.Services;

namespace Corent.Logic.Services
{
    /// <inheritdoc cref="ISerializationService"/>
    [Service(typeof(ISerializationService))]
    public class SerializationService : ISerializationService
    {
        public byte[] Serialize<ObjectType>(ObjectType objectToSerialize)
        {
            var serializer = new DataContractSerializer(typeof(ObjectType));
            try
            {
                using MemoryStream stream = new();
                serializer.WriteObject(stream, objectToSerialize);
                return stream.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ObjectType? Deserialize<ObjectType>(byte[] serializedBytes) where ObjectType : class
        {
            var serializer = new DataContractSerializer(typeof(ObjectType));
            try
            {
                using MemoryStream stream = new(serializedBytes);
                return serializer.ReadObject(stream) as ObjectType;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
