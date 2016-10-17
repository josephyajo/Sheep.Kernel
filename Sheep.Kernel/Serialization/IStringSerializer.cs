namespace Sheep.Kernel.Serialization
{
    public interface IStringSerializer
    {
        string Serialize<T>(T target);
        T Deserialize<T>(string value);
        T DeserializeFile<T>(string path);
    }
}
