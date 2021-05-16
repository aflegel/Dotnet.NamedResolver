namespace Dotnet.NamedResolver
{
    public class ServiceC : IService
    {
        public int UniqueNumber => 3;
        public string Name => "C";
    }

    public class ServiceB : IService
    {
        public int UniqueNumber => 2;
        public string Name => "B";
    }

    public class ServiceA : IService
    {
        public int UniqueNumber => 1;
        public string Name { get; set; } = "A";
    }

    public interface IService
    {
        public int UniqueNumber { get; }
        public string Name { get; }
    }
}
