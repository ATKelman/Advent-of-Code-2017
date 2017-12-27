using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_07
{
    class Program
    {
        static void Main(string[] args)
        {
            var parent = CalculateParent("");
            Console.WriteLine(parent);
            Console.ReadKey();
        }
        
        static string CalculateParent(string input)
        {
            List<Node> nodes = new List<Node>();
            List<string> nodeNames = new List<string>();

            var lines = File.ReadAllLines("input.txt");

            foreach(var line in lines)
            {
                var words = line.Split(null);
                Node instance;
                if(nodeNames.Contains(words[0]))
                {
                    instance = nodes.Where(x => x.name == words[0]).Single();
                }
                else
                {
                    instance = new Node();
                    nodes.Add(instance);
                    nodeNames.Add(words[0]);
                }


                instance.name = words[0];
                instance.weight = int.Parse(words[1].Trim(new char[] { '(', ')' }));

                if(words.Length > 3)
                {
                    for(int i = 3; i < words.Length; i++)
                    {
                        var name = words[i].Trim(',');
                        instance.childrenNames.Add(name);

                        Node child;
                        if(nodeNames.Contains(name))
                        {
                            child = nodes.Where(x => x.name == name).Single();
                        }
                        else
                        {
                            child = new Node();
                        }

                        
                        child.parent = instance;
                        child.name = name;
                        instance.children.Add(child);
                        nodeNames.Add(child.name);
                        nodes.Add(child);
                    }
                }
            }

            var currentNode = nodes[0];
            while(currentNode.parent != null)
            {
                currentNode = currentNode.parent;
            }

            return currentNode.name;
        }
    }

    public class Node
    {
        public string name;
        public Node parent;
        public List<string> childrenNames;
        public List<Node> children;
        public int weight;

        public Node()
        {
            childrenNames = new List<string>();
            children = new List<Node>();
            parent = null;
        }
    }
}
