namespace Sheep.Kernel.Serialization
{
    public interface IByteSerializer
    {
        byte[] Serialize<T>(T target);
        T Deserialize<T>(byte[] value);
    }
}
