using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class Node
    {
        public char character { get; set; }
        public int frequency { get; set; }

        public bool summed = false;

        public bool visited = false;

        public bool isRightChild = false;
        public Node? left { get; set; }
        public Node? right { get; set; }
        public Node? father { get; set; }  

        public Node(char character, int frequency) {
            this.character = character;
            this.frequency = frequency;
            this.right = null;
            this.left = null;
            this.father = null;
        }

        public void SetFather(Node father)
        {
            this.father = father;
        }
        public void SetRightChild(Node rightChild)
        {
            this.right = rightChild;
        }
        public void SetLeftChild(Node leftChild)
        {
            this.left = leftChild;
        }
    }
}
