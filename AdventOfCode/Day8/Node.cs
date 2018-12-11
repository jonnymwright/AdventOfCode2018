using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day8 {
    public class Node {
        private Node[] children;
        private int[] data;

        public Node(string unparsed) {
            IEnumerable<int> parsed = unparsed.Split(" ").Select(int.Parse);
            BuildTree(new Queue<int>(parsed));
        }
        private Node(Queue<int> input) {
            BuildTree(input);
        }
    
        private void BuildTree(Queue<int> input) {
            children = new Node[input.Dequeue()];
            data = new int[input.Dequeue()];

            for (int i = 0; i < children.Length; i++)
            {
                children[i] = new Node(input);
            }
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = input.Dequeue();
            }
        }

        public int SumMetadata () {
            return data.Sum() + children.Select(child => child.SumMetadata()).Sum();
        }

        public int SumValue() {
            if (!children.Any()) {
                return data.Sum();
            }

            return data.Where(datum => datum <= children.Length)
                .Select(datum => children[datum-1].SumValue())
                .Sum();
        }
    }
}