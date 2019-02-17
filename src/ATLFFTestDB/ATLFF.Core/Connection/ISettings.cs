using Neo4j.Driver.V1;

namespace ATLFF.Core.Connection
{
    public interface  ISettings
    {
        string Uri { get; }
        IAuthToken AuthToken { get; }
    }
}
