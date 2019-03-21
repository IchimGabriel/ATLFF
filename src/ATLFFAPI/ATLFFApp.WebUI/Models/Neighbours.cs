using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATLFFApp.WebUI.Models
{
    public class Neighbours
    {
        public List<ResultNeighbour> Result { get; set; }
        public int Id { get; set; }
        public object Exception { get; set; }
        public int Status { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCompletedSuccessfully { get; set; }
        public int CreationOptions { get; set; }
        public object AsyncState { get; set; }
        public bool IsFaulted { get; set; }
    }
    public class ValuesNeighbour
    {
        public string Node { get; set; }
        public string Neighbour { get; set; }
    }

    public class ResultNeighbour
    {
        public ValuesNeighbour Values { get; set; }
        public List<string> Keys { get; set; }
    }

}
