using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Huffman;
public class Program
{
    public static List<Node> tree = new List<Node>();
    public static Dictionary<char,string> newSymbols = new Dictionary<char,string>();
    public static string text;
    public static int father = 0;
    public static void Main()
    {
        int Choice = 0;

        while (Choice != 3)
        {
          UserInterface.ShowIntroduction();
          UserInterface.ShowMenu();
          Choice = Convert.ToInt16(Console.ReadLine());

          switch (Choice) 
          {
            case 1:
            string? filename = Console.ReadLine();
            StreamReader file = new StreamReader(filename);
            text = file.ReadToEnd();
            AddLeafs();
            foreach (var node in tree)
            {
                Console.WriteLine(node.frequency + " " + node.character + " " + node.summed + " " + node.visited);
            }

            Console.WriteLine("------------");


            CreateUpperNodes();

            foreach (var node in tree)
            {
                if (node != null && node.right != null && node.left != null)
                    Console.WriteLine("Node: " + " " + node.frequency + " Left: " + node.left.frequency + " " + " Right: " + node.right.frequency);
            }


            Node root = tree[father];
            string code = "";
            CreateCode(root, code);  //will put each character and its corresponding
            foreach (var dicItem in newSymbols)
            {
                Console.WriteLine(dicItem.Key + " " + dicItem.Value);
            }
            break;

            case 2:

            break;
            
            case 3:
                    Console.WriteLine("Thanks for using my application...");
            break;

            default:
                    Console.WriteLine("Please enter an valid option");
            break;
          }
        }
    }

    public static void CreateUpperNodes()
    {
        /*by the time we call this function, the tree musst contain all leaf nodes*/
        int maximumFrequency = 0;
        while (maximumFrequency < text.Length)
        {
            int min = Min(); //its an index of tree
            int min2 = Min2(min);
            //values of min e min2 are only assigned to an index of node if said node have summed equal to false
            Node newNode = new Node('$', tree[min].frequency + tree[min2].frequency); //$ indicates no character
            if(tree[min2].frequency == tree[min].frequency)
            {
                if (tree[min2].character == '$')
                {
                    newNode.right = tree[min2];
                    newNode.left = tree[min];
                    tree[min2].isRightChild = true;
                }
                else
                {
                    newNode.left = tree[min2];
                    newNode.right = tree[min];
                    tree[min].isRightChild = true;
                }
            }
            if (tree[min2].frequency > tree[min].frequency)
            {
                newNode.right = tree[min2];
                newNode.left = tree[min];
                tree[min2].isRightChild = true;
            }
            else if(tree[min2].frequency < tree[min].frequency)
            {
                newNode.left = tree[min2];
                newNode.right = tree[min];
                tree[min].isRightChild = true;
            }
            tree[min].father = newNode;
            tree[min2].father = newNode;
            tree[min].summed = true; 
            tree[min2].summed = true;
            tree.Add(newNode);

/*
            foreach (var node in tree)
            {
                Console.WriteLine(node.frequency + " " + node.character + " " + node.summed + " " + node.visited);
            }
*/
            maximumFrequency = tree[min].frequency + tree[min2].frequency;
            if (newNode.frequency == text.Length) father = tree.IndexOf(newNode);
    
        }

    }

    public static int Min()
    {
        int lowest = 0; //index of first tree node
        for(int i = 0; i < tree.Count(); i++)
        {
            if ((tree[i].frequency < tree[lowest].frequency) && tree[i].summed == false)  //&& tree[i].summed == false
            {
                lowest = i;
            }
        }
        return lowest;
    }
    public static int Min2(int lowest)     //gets to find the second smallest frequency on tree, given the smallest by Min()
    {
        int sndLowest;
        if (lowest == 0)
        {
            sndLowest = 1;
            while (tree[sndLowest].summed == true)
            {
                sndLowest++;
            }
        }
        else
        {
            sndLowest = 0;
            while (tree[sndLowest].summed == true)
            {
                sndLowest++;
            }
        }
        
        for (int i = sndLowest; i < tree.Count(); i++)
        {
            if ( i != lowest) 
            {
                if ((tree[i].frequency < tree[sndLowest].frequency) && tree[i].summed == false ) 
                    sndLowest = i;
             
            }
        }
        return sndLowest;
    }
    public static void AddToTree(Node node)
    {
       tree.Add(node);
    }
    public static void AddLeafs()
    {
        foreach(var character in text)
        {
            int index = tree.FindIndex(x => x.character == character);

            if (index != -1)
            {
                tree[index].frequency = (tree[index].frequency + 1);
            }
            else
            {
                AddToTree(new Node(character,1));
            }
        }
    }

    public static void CreateCode(Node father, string code)
    {
        if (father != null)
        {
            if (father.character != '$')
            {
                if(!newSymbols.ContainsKey(father.character))
                newSymbols.Add(father.character, code);
            }
            CreateCode(father.right, code + "1");
            CreateCode(father.left, code + "0");
        }
    }
    

}
