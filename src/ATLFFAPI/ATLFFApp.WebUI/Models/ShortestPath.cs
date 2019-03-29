using System.Collections.Generic;

namespace ATLFFApp.WebUI.Models
{
    /// <summary>
    /// http://json2csharp.com/
    /// Website above take json result and create .NET classes
    /// </summary>
    /// 

    public class Values
    {
        public List<string> Cities { get; set; }
        public int TravelDistance { get; set; }
    }

    public class ShortestPath
    {
        public Values Values { get; set; }
        public List<string> Keys { get; set; }
    }
}
