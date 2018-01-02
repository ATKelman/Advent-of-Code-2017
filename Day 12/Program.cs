using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());

            Console.ReadKey();
        }

        public static List<Pipe> pipes;
        public static List<Pipe> group;

        public static List<Pipe> pipesInGroup;

        static int PartOne()
        {
            var input = File.ReadAllLines("input.txt").ToList();
            pipes = input.Select(x => new Pipe(x)).ToList();

            pipes.ForEach(x => x.AddPipes(input[x.id]));

            group = new List<Pipe>();
            pipesInGroup = new List<Pipe>();
            pipes[0].TraceGroup();

            return group.Count(); 
        }

        static int PartTwo()
        {
            var groupCount = 0;
            pipesInGroup = new List<Pipe>();

            for(int i = 0; i < pipes.Count(); i++)
            {
                if(!pipesInGroup.Contains(pipes[i]))
                {
                    group = new List<Pipe>();
                    pipes[i].TraceGroup();
                    groupCount++;
                }
            }

            return groupCount;
        }

        public class Pipe
        {
            public int id { get; set; }
            public List<Pipe> connections { get; set; }

            public Pipe(string input)
            {
                var words = input.Split(' ');
                connections = new List<Pipe>();

                id = int.Parse(words[0]);
            }

            public void AddPipes(string input)
            {
                var words = input.Split(' ');
                for (int i = 2; i < words.Count(); i++)
                {
                    var word = words[i].Replace(",", "");
                    var pipeId = int.Parse(word);
                    var connectedPipe = pipes.First(x => x.id == pipeId);

                    if(!connections.Contains(connectedPipe))
                    {
                        connections.Add(connectedPipe);                      
                    }
                }
            }

            public void TraceGroup()
            {
                group.Add(this);
                pipesInGroup.Add(this);

                foreach(var member in connections)
                {
                    if (!group.Contains(member))
                        member.TraceGroup();
                }
            }
        }
    }

    
}
