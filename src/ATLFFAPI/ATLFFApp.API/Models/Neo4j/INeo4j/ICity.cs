using System;

namespace ATLFFApp.API.Models.Neo4j
{
    public interface ICity 
    {
        Guid Id { get; set; }
        string iso { get; set; }
        float Latitude { get; set; }
        float Longitude { get; set; }
        string Name { get; set; }
        bool Port { get; set; }
        int Turnaround { get; set; }
    }
}