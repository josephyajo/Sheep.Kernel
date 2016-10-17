namespace Sheep.Kernel.Serialization
{
    public abstract class SerializerFactory
    {
        public abstract IStringSerializer GetStringSerializer();

        public abstract IByteSerializer GetByteSerializer();
    }
}
