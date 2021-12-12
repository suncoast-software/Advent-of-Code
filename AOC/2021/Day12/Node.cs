using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day12
{
    public class Node
    {
        public string Name { get; set; }
        public bool Small { get; set; }
        public IList<Node> Neighbors { get; set; }

        public Node()
        {
            Neighbors = new List<Node>();
        }
    }
}
