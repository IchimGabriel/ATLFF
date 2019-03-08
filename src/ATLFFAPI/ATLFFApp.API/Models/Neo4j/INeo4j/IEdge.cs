namespace ATLFFApp.API.Models.Neo4j
{
    public interface IEdge
    {
        City ArrivalCity { get; }
        City DepartureCity { get; }
        int Distance { get; set; }
        float Emission { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        int Speed { get; set; }
    }
}