using AOC._2021.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day12
{
    public class Day12: Day
    {
        private IDictionary<string, Node> _nodes;
        public async Task<int> Part_One()
        {
            string caves = await GetInputForDayAsync(12);
            var nodes = new Dictionary<string, Node>();
            var lines = caves.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Node GetNode(string name)
            {
                if (nodes.ContainsKey(name)) return nodes[name];
                var node = new Node { Name = name, Small = name.All(char.IsLower) };
                nodes.Add(name, node);
                return node;
            }
            foreach (var line in lines)
            {
                var segments = line.Split("-").ToArray();
                var a = GetNode(segments[0]);
                var b = GetNode(segments[1]);

                a.Neighbors.Add(b);
                b.Neighbors.Add(a);
            }
            _nodes = nodes;

            var paths = FindPathes();
            return paths.Count();
        }

        public async Task<int> Part_Two()
        {
            string caves = await GetInputForDayAsync(12);
            var nodes = new Dictionary<string, Node>();
            var lines = caves.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Node GetNode(string name)
            {
                if (nodes.ContainsKey(name)) return nodes[name];
                var node = new Node { Name = name, Small = name.All(char.IsLower) };
                nodes.Add(name, node);
                return node;
            }
            foreach (var line in lines)
            {
                var segments = line.Split("-").ToArray();
                var a = GetNode(segments[0]);
                var b = GetNode(segments[1]);

                a.Neighbors.Add(b);
                b.Neighbors.Add(a);
            }
            _nodes = nodes;

            var paths = FindPathesAllowingRevisitingASingleSmallCave();
            return paths.Count();

        }

        public IEnumerable<IList<Node>> FindPathes()
        {
            var queue = new Queue<(Node, List<Node>)>();
            queue.Enqueue((_nodes["start"], new List<Node>()));

            while (queue.Count > 0)
            {
                var (node, history) = queue.Dequeue();

                history.Add(node);

                if (node.Name == "end")
                {
                    yield return history;
                    continue;
                }

                foreach (var neighbor in node.Neighbors)
                {
                    if (neighbor.Small && history.Contains(neighbor))
                        continue;
                    queue.Enqueue((neighbor, new List<Node>(history)));
                }
            }
        }

        public IEnumerable<IList<Node>> FindPathesAllowingRevisitingASingleSmallCave()
        {
            var queue = new Queue<(Node, List<Node>, bool smallCaveVisitedTwice)>();
            queue.Enqueue((_nodes["start"], new List<Node>(), false));

            while (queue.Count > 0)
            {
                var (node, history, smallCaveVisitedTwice) = queue.Dequeue();

                history.Add(node);

                if (node.Name == "end")
                {
                    yield return history;
                    continue;
                }

                foreach (var neighbor in node.Neighbors)
                {
                    if (neighbor.Name == "start")
                        continue;

                    if (neighbor.Small)
                    {
                        if (history.Contains(neighbor))
                        {
                            if (smallCaveVisitedTwice)
                                continue;
                            queue.Enqueue((neighbor, new List<Node>(history), true));
                        }
                        else
                        {
                            queue.Enqueue((neighbor, new List<Node>(history), smallCaveVisitedTwice));
                        }
                    }
                    else
                    {
                        queue.Enqueue((neighbor, new List<Node>(history), smallCaveVisitedTwice));
                    }
                }
            }
        }
    }
}
